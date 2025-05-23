﻿/*  代码由框架生成,任何更改都可能导致被代码生成器覆盖，可自行修改。
* SdOrder.cs
*
* 功 能： N / A
* 类 名： SdOrder
*
* Ver    变更日期 负责人  变更内容
* ───────────────────────────────────
* V0.01  2025/2/27 18:30:20  SahHsiao   初版
*
* Copyright(c) 2025 EU Corporation. All Rights Reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　作者：SahHsiao                                                  │
*└──────────────────────────────────┘
*/

namespace EU.Core.Model.Entity;

/// <summary>
/// 销售单 (Model)
/// </summary>
[SugarTable("SdOrder", "销售单"), Entity(TableCnName = "销售单", TableName = "SdOrder")]
public class SdOrder : BasePoco
{

    /// <summary>
    /// 销售单号
    /// </summary>
    [Display(Name = "OrderNo"), Description("销售单号"), SugarColumn(IsNullable = true, Length = 32)]
    public string OrderNo { get; set; }

    /// <summary>
    /// 订单日期/订购日期
    /// </summary>
    [Display(Name = "OrderDate"), Description("订单日期/订购日期"), SugarColumn(IsNullable = true)]
    public DateTime? OrderDate { get; set; }

    /// <summary>
    /// 交货日期
    /// </summary>
    [Display(Name = "DeliveryDate"), Description("交货日期"), SugarColumn(IsNullable = true)]
    public DateTime? DeliveryDate { get; set; }

    /// <summary>
    /// 订单等级
    /// </summary>
    [Display(Name = "OrderLevel"), Description("订单等级"), SugarColumn(IsNullable = true, Length = 32)]
    public string OrderLevel { get; set; }

    /// <summary>
    /// 订单类别 正式订单、样品订单、其他订单（默认正式订单）
    /// </summary>
    [Display(Name = "OrderCategory"), Description("订单类别 正式订单、样品订单、其他订单（默认正式订单）"), SugarColumn(IsNullable = true, Length = 32)]
    public string OrderCategory { get; set; }

    /// <summary>
    /// 客户ID
    /// </summary>
    [Display(Name = "CustomerId"), Description("客户ID"), SugarColumn(IsNullable = true)]
    public Guid? CustomerId { get; set; }

    /// <summary>
    /// 客户单号
    /// </summary>
    [Display(Name = "CustomerOrderNo"), Description("客户单号"), SugarColumn(IsNullable = true, Length = 64)]
    public string CustomerOrderNo { get; set; }

    /// <summary>
    /// 业务员
    /// </summary>
    [Display(Name = "SalesmanId"), Description("业务员"), SugarColumn(IsNullable = true)]
    public Guid? SalesmanId { get; set; }

    /// <summary>
    /// 税别，参数值：TaxType
    /// </summary>
    [Display(Name = "TaxType"), Description("税别，参数值：TaxType"), SugarColumn(IsNullable = true, Length = 32)]
    public string TaxType { get; set; }

    /// <summary>
    /// 税率
    /// </summary>
    [Display(Name = "TaxRate"), Description("税率"), Column(TypeName = "decimal(20,6)"), SugarColumn(IsNullable = true, Length = 20, DecimalDigits = 6)]
    public decimal? TaxRate { get; set; }

    /// <summary>
    /// 未税金额
    /// </summary>
    [Display(Name = "NoTaxAmount"), Description("未税金额"), Column(TypeName = "decimal(20,2)"), SugarColumn(IsNullable = true, Length = 20, DecimalDigits = 2)]
    public decimal? NoTaxAmount { get; set; }

    /// <summary>
    /// 税额
    /// </summary>
    [Display(Name = "TaxAmount"), Description("税额"), Column(TypeName = "decimal(20,2)"), SugarColumn(IsNullable = true, Length = 20, DecimalDigits = 2)]
    public decimal? TaxAmount { get; set; }

    /// <summary>
    /// 含税金额
    /// </summary>
    [Display(Name = "TaxIncludedAmount"), Description("含税金额"), Column(TypeName = "decimal(20,2)"), SugarColumn(IsNullable = true, Length = 20, DecimalDigits = 2)]
    public decimal? TaxIncludedAmount { get; set; }

    /// <summary>
    /// 结算方式
    /// </summary>
    [Display(Name = "SettlementWayId"), Description("结算方式"), SugarColumn(IsNullable = true)]
    public Guid? SettlementWayId { get; set; }

    /// <summary>
    /// 结算方式
    /// </summary>
    [Display(Name = "SettlementWay"), Description("结算方式"), SugarColumn(IsNullable = true, Length = 32)]
    public string SettlementWay { get; set; }

    /// <summary>
    /// 收货人
    /// </summary>
    [Display(Name = "Contact"), Description("收货人"), SugarColumn(IsNullable = true, Length = 32)]
    public string Contact { get; set; }

    /// <summary>
    /// 收货地址
    /// </summary>
    [Display(Name = "Address"), Description("收货地址"), SugarColumn(IsNullable = true, Length = 128)]
    public string Address { get; set; }

    /// <summary>
    /// 收货电话
    /// </summary>
    [Display(Name = "Phone"), Description("收货电话"), SugarColumn(IsNullable = true, Length = 32)]
    public string Phone { get; set; }

    /// <summary>
    /// 币别
    /// </summary>
    [Display(Name = "CurrencyId"), Description("币别"), SugarColumn(IsNullable = true)]
    public Guid? CurrencyId { get; set; }

    /// <summary>
    /// 订单状态（作废）
    /// </summary>
    [Display(Name = "SalesOrderStatus"), Description("订单状态（作废）"), SugarColumn(IsNullable = true, Length = 32)]
    public string SalesOrderStatus { get; set; }

    /// <summary>
    /// 备注
    /// </summary>
    [Display(Name = "Remark"), Description("备注"), SugarColumn(IsNullable = true, Length = 2000)]
    public string Remark { get; set; }
}
