﻿/*  代码由框架生成,任何更改都可能导致被代码生成器覆盖，可自行修改。
* BdMaterialType.cs
*
*功 能： N / A
* 类 名： BdMaterialType
*
* Ver    变更日期 负责人  变更内容
* ───────────────────────────────────
*V0.01  2024/4/23 20:13:32  SimonHsiao   初版
*
* Copyright(c) 2024 EU Corporation. All Rights Reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　作者：SimonHsiao                                                  │
*└──────────────────────────────────┘
*/
namespace EU.Core.Model.Models;


/// <summary>
/// 物料类型 (Model)
/// </summary>
[SugarTable("BdMaterialType", "BdMaterialType"), Entity(TableCnName = "物料类型", TableName = "BdMaterialType")]
public class BdMaterialType : BasePoco
{

    /// <summary>
    /// 类型编号
    /// </summary>
    [Display(Name = "MaterialTypeNo"), Description("类型编号"), MaxLength(64, ErrorMessage = "类型编号 不能超过 64 个字符")]
    public string MaterialTypeNo { get; set; }

    /// <summary>
    /// 类型名称
    /// </summary>
    [Display(Name = "MaterialTypeNames"), Description("类型名称"), MaxLength(64, ErrorMessage = "类型名称 不能超过 64 个字符")]
    public string MaterialTypeNames { get; set; }

    /// <summary>
    /// 排序号
    /// </summary>
    public int? TaxisNo { get; set; }

    /// <summary>
    /// 备注
    /// </summary>
    [Display(Name = "Remark"), Description("备注"), MaxLength(2000, ErrorMessage = "备注 不能超过 2000 个字符")]
    public string Remark { get; set; }

    /// <summary>
    /// 上级ID
    /// </summary>
    public Guid? ParentTypeId { get; set; }
}
