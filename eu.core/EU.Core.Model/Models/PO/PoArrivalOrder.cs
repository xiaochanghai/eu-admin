﻿/*  代码由框架生成,任何更改都可能导致被代码生成器覆盖，可自行修改。
* PoArrivalOrder.cs
*
*功 能： N / A
* 类 名： PoArrivalOrder
*
* Ver    变更日期 负责人  变更内容
* ───────────────────────────────────
*V0.01  2024/9/13 16:11:50  SimonHsiao   初版
*
* Copyright(c) 2024 EU Corporation. All Rights Reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　作者：SimonHsiao                                                  │
*└──────────────────────────────────┘
*/

namespace EU.Core.Model.Models;

/// <summary>
/// 采购到货通知单 (Model)
/// </summary>
[SugarTable("PoArrivalOrder", "PoArrivalOrder"), Entity(TableCnName = "采购到货通知单", TableName = "PoArrivalOrder")]
public class PoArrivalOrder : BasePoco
{

    /// <summary>
    /// 单号
    /// </summary>
    [Display(Name = "OrderNo"), Description("单号"), MaxLength(32, ErrorMessage = "单号 不能超过 32 个字符")]
    public string OrderNo { get; set; }

    /// <summary>
    /// 作业日期
    /// </summary>
    public DateTime? OrderDate { get; set; }

    /// <summary>
    /// 采购员ID
    /// </summary>
    public Guid? UserId { get; set; }

    /// <summary>
    /// 部门ID
    /// </summary>
    public Guid? DepartmentId { get; set; }

    /// <summary>
    /// 供应商ID
    /// </summary>
    public Guid? SupplierId { get; set; }

    /// <summary>
    /// 到货日期 
    /// </summary>
    public DateTime? ArrivalTime { get; set; }

    /// <summary>
    /// 采购合同号
    /// </summary>
    [Display(Name = "ContractNo"), Description("采购合同号"), MaxLength(32, ErrorMessage = "采购合同号 不能超过 32 个字符")]
    public string ContractNo { get; set; }

    /// <summary>
    /// 送货单号
    /// </summary>
    [Display(Name = "DeliveryOrderNo"), Description("送货单号"), MaxLength(32, ErrorMessage = "送货单号 不能超过 32 个字符")]
    public string DeliveryOrderNo { get; set; }

    /// <summary>
    /// 条码
    /// </summary>
    [Display(Name = "BarCode"), Description("条码"), MaxLength(32, ErrorMessage = "条码 不能超过 32 个字符")]
    public string BarCode { get; set; }

    /// <summary>
    /// 备注
    /// </summary>
    [Display(Name = "Remark"), Description("备注"), MaxLength(2000, ErrorMessage = "备注 不能超过 2000 个字符")]
    public string Remark { get; set; }

    /// <summary>
    /// 订单状态
    /// </summary>
    [Display(Name = "OrderStatus"), Description("订单状态"), MaxLength(32, ErrorMessage = "订单状态 不能超过 32 个字符")]
    public string OrderStatus { get; set; }
}