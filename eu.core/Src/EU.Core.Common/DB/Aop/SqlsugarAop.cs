using EU.Core.Model.Models.RootTkey;
using EU.Core.Model.Tenants;
using SqlSugar;
using StackExchange.Profiling;
using Serilog;
using EU.Core.Common.LogHelper;
using EU.Core.Model;

namespace EU.Core.Common.DB.Aop;

public static class SqlSugarAop
{
    public static void OnLogExecuting(ISqlSugarClient sqlSugarScopeProvider, string user, string table, string operate, string sql, SugarParameter[] p, ConnectionConfig config)
    {
        try
        {
            MiniProfiler.Current.CustomTiming($"ConnId:[{config.ConfigId}] SQL：", GetParas(p) + "【SQL语句】：" + sql);

            if (!AppSettings.app(["AppSettings", "SqlAOP", "Enabled"]).ObjToBool()) return;

            if (AppSettings.app(["AppSettings", "SqlAOP", "LogToConsole", "Enabled"]).ObjToBool() ||
                AppSettings.app(["AppSettings", "SqlAOP", "LogToFile", "Enabled"]).ObjToBool() ||
                AppSettings.app(["AppSettings", "SqlAOP", "LogToDB", "Enabled"]).ObjToBool())
            {
                using (LogContextExtension.Create.SqlAopPushProperty(sqlSugarScopeProvider))
                {
                    Log.Information("------------------ \r\n User:[{User}]  Table:[{Table}]  Operate:[{Operate}] ConnId:[{ConnId}]【SQL语句】: \r\n {Sql}",
                        user, table, operate, config.ConfigId, UtilMethods.GetNativeSql(sql, p));
                }
            }
        }
        catch (Exception e)
        {
            Log.Error("Error occured OnLogExcuting:" + e);
        }
    }

    public static void DataExecuting(object oldValue, DataFilterModel entityInfo)
    {
        if (entityInfo.EntityValue is RootEntityTkey<Guid> rootEntity)
            if (rootEntity.ID == Guid.Empty)
                rootEntity.ID = Guid.NewGuid();

        if (entityInfo.EntityValue is BaseEntity baseEntity)
        {
            // 新增操作
            if (entityInfo.OperationType == DataFilterType.InsertByObject)
                if (baseEntity.CreatedTime == DateTime.MinValue || baseEntity.CreatedTime is null)
                    baseEntity.CreatedTime = DateTime.Now;

            if (entityInfo.OperationType == DataFilterType.UpdateByObject)
                baseEntity.UpdateTime = DateTime.Now;

            if (App.User?.ID != null)
            {
                if (baseEntity is ITenantEntity tenant && App.User.TenantId > 0)
                {
                    if (tenant.TenantId == 0)
                        tenant.TenantId = App.User.TenantId;
                }

                switch (entityInfo.OperationType)
                {
                    case DataFilterType.UpdateByObject:
                        baseEntity.UpdateBy = App.User.ID;
                        //baseEntity.UpdateBy = App.User.Name;
                        break;
                    case DataFilterType.InsertByObject:
                        if (baseEntity.CreatedBy.IsNullOrEmpty() || baseEntity.CreatedBy is null)
                        {
                            baseEntity.CreatedBy = App.User.ID;
                            //baseEntity.CreatedBy = App.User.Name;
                        }

                        break;
                }
            }
        }
        else
        {
            //兼容以前的表 
            //这里要小心 在AOP里用反射 数据量多性能就会有问题
            //要么都统一使用基类
            //要么考虑老的表没必要兼容老的表
            //

            var getType = entityInfo.EntityValue.GetType();

            switch (entityInfo.OperationType)
            {
                case DataFilterType.InsertByObject:
                    var dyCreatedBy = getType.GetProperty("CreatedBy");
                    var dyCreateTime = getType.GetProperty("CreatedTime");

                    if (App.User?.ID != null && dyCreatedBy != null && dyCreatedBy.GetValue(entityInfo.EntityValue) == null)
                        dyCreatedBy.SetValue(entityInfo.EntityValue, App.User.ID);

                    if ((dyCreateTime != null && dyCreateTime.GetValue(entityInfo.EntityValue) is null) || (dyCreateTime != null && dyCreateTime.GetValue(entityInfo.EntityValue) != null && (DateTime)dyCreateTime.GetValue(entityInfo.EntityValue) == DateTime.MinValue))
                        dyCreateTime.SetValue(entityInfo.EntityValue, DateTime.Now);

                    break;
                case DataFilterType.UpdateByObject:
                    var UpdateBy = getType.GetProperty("UpdateBy");
                    var dyModifyTime = getType.GetProperty("UpdateTime");

                    if (App.User?.ID != null && UpdateBy != null)
                        UpdateBy.SetValue(entityInfo.EntityValue, App.User.ID);

                    if (dyModifyTime != null)
                        dyModifyTime.SetValue(entityInfo.EntityValue, DateTime.Now);
                    break;
            }
        }
    }

    private static string GetWholeSql(SugarParameter[] paramArr, string sql)
    {
        foreach (var param in paramArr)
        {
            sql = sql.Replace(param.ParameterName, $@"'{param.Value.ObjToString()}'");
        }

        return sql;
    }

    private static string GetParas(SugarParameter[] pars)
    {
        string key = "【SQL参数】：";
        foreach (var param in pars)
        {
            key += $"{param.ParameterName}:{param.Value}\n";
        }

        return key;
    }
}