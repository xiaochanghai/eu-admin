﻿/*  代码由框架生成,任何更改都可能导致被代码生成器覆盖，可自行修改。
* PoOrderDetail.cs
*
*功 能： N / A
* 类 名： PoOrderDetail
*
* Ver    变更日期 负责人  变更内容
* ───────────────────────────────────
*V0.01  2024/9/9 17:43:22  SimonHsiao   初版
*
* Copyright(c) 2024 EU Corporation. All Rights Reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　作者：SimonHsiao                                                  │
*└──────────────────────────────────┘
*/

namespace EU.Core.Model.Models;

/// <summary>
/// 采购单明细 (Model)
/// </summary>
[SugarTable("PoOrderDetail", "PoOrderDetail"), Entity(TableCnName = "PoOrderDetail", TableName = "PoOrderDetail")]
public class PoOrderDetail : BasePoco
{

    /// <summary>
    /// 订单ID
    /// </summary>
    public Guid? OrderId { get; set; }

    /// <summary>
    /// 序号
    /// </summary>
    public int? SerialNumber { get; set; }

    /// <summary>
    /// 采购来源，请购单/销售单
    /// </summary>
    [Display(Name = "OrderSource"), Description("采购来源，请购单/销售单"), MaxLength(32, ErrorMessage = "采购来源，请购单/销售单 不能超过 32 个字符")]
    public string OrderSource { get; set; }

    /// <summary>
    /// 来源订单ID
    /// </summary>
    public Guid? SourceOrderId { get; set; }

    /// <summary>
    /// 来源订单明细ID
    /// </summary>
    public Guid? SourceOrderDetailId { get; set; }

    /// <summary>
    /// 货品编号
    /// </summary>
    public Guid? MaterialId { get; set; }

    /// <summary>
    /// 数量
    /// </summary>
    [Display(Name = "QTY"), Description("数量"), Column(TypeName = "decimal(20,8)")]
    public decimal? QTY { get; set; }

    /// <summary>
    /// 单价
    /// </summary>
    [Display(Name = "Price"), Description("单价"), Column(TypeName = "decimal(20,2)")]
    public decimal? Price { get; set; }

    /// <summary>
    /// 未税金额
    /// </summary>
    [Display(Name = "NoTaxAmount"), Description("未税金额"), Column(TypeName = "decimal(20,2)")]
    public decimal? NoTaxAmount { get; set; }

    /// <summary>
    /// 税额
    /// </summary>
    [Display(Name = "TaxAmount"), Description("税额"), Column(TypeName = "decimal(20,2)")]
    public decimal? TaxAmount { get; set; }

    /// <summary>
    /// 含税金额
    /// </summary>
    [Display(Name = "TaxIncludedAmount"), Description("含税金额"), Column(TypeName = "decimal(20,2)")]
    public decimal? TaxIncludedAmount { get; set; }

    /// <summary>
    /// 送达日期
    /// </summary>
    public DateTime? DeliveryDate { get; set; }

    /// <summary>
    /// 已通知数量
    /// </summary>
    [Display(Name = "NoticeQTY"), Description("已通知数量"), Column(TypeName = "decimal(20,2)")]
    public decimal? NoticeQTY { get; set; }

    /// <summary>
    /// 已入库数量
    /// </summary>
    [Display(Name = "InQTY"), Description("已入库数量"), Column(TypeName = "decimal(20,2)")]
    public decimal? InQTY { get; set; }

    /// <summary>
    /// 退货数量
    /// </summary>
    [Display(Name = "ReturnQTY"), Description("退货数量"), Column(TypeName = "decimal(20,2)")]
    public decimal? ReturnQTY { get; set; }

    /// <summary>
    /// 备注
    /// </summary>
    [Display(Name = "Remark"), Description("备注"), MaxLength(2000, ErrorMessage = "备注 不能超过 2000 个字符")]
    public string Remark { get; set; }

    /// <summary>
    /// 备注
    /// </summary>
    [Display(Name = "ExtRemark1"), Description("备注"), MaxLength(2000, ErrorMessage = "备注 不能超过 2000 个字符")]
    public string ExtRemark1 { get; set; }

    /// <summary>
    /// 备注
    /// </summary>
    [Display(Name = "ExtRemark2"), Description("备注"), MaxLength(2000, ErrorMessage = "备注 不能超过 2000 个字符")]
    public string ExtRemark2 { get; set; }

    /// <summary>
    /// 备注
    /// </summary>
    [Display(Name = "ExtRemark3"), Description("备注"), MaxLength(2000, ErrorMessage = "备注 不能超过 2000 个字符")]
    public string ExtRemark3 { get; set; }

    /// <summary>
    /// 备注
    /// </summary>
    [Display(Name = "ExtRemark4"), Description("备注"), MaxLength(2000, ErrorMessage = "备注 不能超过 2000 个字符")]
    public string ExtRemark4 { get; set; }
}