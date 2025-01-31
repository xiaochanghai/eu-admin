﻿/*  代码由框架生成,任何更改都可能导致被代码生成器覆盖，可自行修改。
* IvCheckDetail.cs
*
* 功 能： N / A
* 类 名： IvCheckDetail
*
* Ver    变更日期 负责人  变更内容
* ───────────────────────────────────
* V1.0  2024/12/18 15:50:12  SimonHsiao   初版
*
* Copyright(c) 2024 SUZHOU EU Corporation. All Rights Reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：苏州一优信息技术有限公司                                │
*└──────────────────────────────────┘
*/

namespace EU.Core.Services;

/// <summary>
/// 库存盘点单明细 (服务)
/// </summary>
public class IvCheckDetailServices : BaseServices<IvCheckDetail, IvCheckDetailDto, InsertIvCheckDetailInput, EditIvCheckDetailInput>, IIvCheckDetailServices
{
    private readonly IBaseRepository<IvCheckDetail> _dal;
    private readonly IBdMaterialServices _materialServices;
    public IvCheckDetailServices(IBaseRepository<IvCheckDetail> dal, IBdMaterialServices materialServices)
    {
        this._dal = dal;
        base.BaseDal = dal;
        _materialServices = materialServices;
    }

    #region 更新
    public override async Task<IvCheckDetailDto> UpdateReturn(Guid Id, object entity1)
    {
        try
        {
            var dict = JsonHelper.JsonToObj<Dictionary<string, object>>(entity1.ToString());
            var orderId = dict["masterId"].ObjToGuid();
            var entity = await Query(Id);
            var model = ConvertToEntity(entity1);

            if (entity is null)
                await base.Add(new InsertIvCheckDetailInput() { OrderId = orderId }, Id);

            var lstColumns = new ModuleSqlColumn("IV_OUT_DETAIL_MNG").GetModuleTableEditableColumns();

            await Update(model, lstColumns, ["OrderId"], $"ID='{Id}'");

            var model1 = Mapper.Map(model).ToANew<IvCheckDetailDto>();

            var material = await _materialServices.QueryDto(model.MaterialId);
            model1.MaterialName = material.MaterialName + "（" + material.MaterialNo + "）";
            model1.Specifications = material.Specifications;
            model1.UnitName = material.UnitName;
            await IVChangeHelper.UpdataOrderDetailSerialNumber(Db, "IvCheckDetail", orderId);

            return model1;
        }
        catch (Exception)
        {
            throw;
        }
    }
    #endregion
}