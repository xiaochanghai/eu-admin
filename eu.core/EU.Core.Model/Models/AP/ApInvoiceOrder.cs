﻿/*  代码由框架生成,任何更改都可能导致被代码生成器覆盖，可自行修改。
* ApInvoiceOrder.cs
*
*功 能： N / A
* 类 名： ApInvoiceOrder
*
* Ver    变更日期 负责人  变更内容
* ───────────────────────────────────
*V0.01  2024/4/26 17:45:08  SimonHsiao   初版
*
* Copyright(c) 2024 EU Corporation. All Rights Reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　作者：SimonHsiao                                                  │
*└──────────────────────────────────┘
*/ 
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SqlSugar;

namespace EU.Core.Model.Models
{

    /// <summary>
    /// 应付发票单 (Model)
    /// </summary>
    [SugarTable("ApInvoiceOrder", "ApInvoiceOrder"), Entity(TableCnName = "应付发票单", TableName = "ApInvoiceOrder")]
    public class ApInvoiceOrder : BasePoco
    {

        /// <summary>
        /// 单号
        /// </summary>
        [Display(Name = "OrderNo"), Description("单号"), MaxLength(32, ErrorMessage = "单号 不能超过 32 个字符")]
        public string OrderNo { get; set; }

        /// <summary>
        /// 订单日期
        /// </summary>
        public DateTime? OrderDate { get; set; }

        /// <summary>
        /// 单据类型
        /// </summary>
        [Display(Name = "ApInvoiceOrderType"), Description("单据类型"), MaxLength(32, ErrorMessage = "单据类型 不能超过 32 个字符")]
        public string ApInvoiceOrderType { get; set; }

        /// <summary>
        /// 供应商ID
        /// </summary>
        public Guid? SupplierId { get; set; }

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
        /// 发票金额
        /// </summary>
        [Display(Name = "InvoiceAmount"), Description("发票金额"), Column(TypeName = "decimal(20,6)")]
        public decimal? InvoiceAmount { get; set; }

        /// <summary>
        /// 发票差额
        /// </summary>
        [Display(Name = "InvoiceDiffAmount"), Description("发票差额"), Column(TypeName = "decimal(20,6)")]
        public decimal? InvoiceDiffAmount { get; set; }

        /// <summary>
        /// 付款时间
        /// </summary>
        public DateTime? PayTime { get; set; }

        /// <summary>
        /// 订单状态
        /// </summary>
        [Display(Name = "ApInvoiceOrderStatus"), Description("订单状态"), MaxLength(32, ErrorMessage = "订单状态 不能超过 32 个字符")]
        public string ApInvoiceOrderStatus { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [Display(Name = "Remark"), Description("备注"), MaxLength(2000, ErrorMessage = "备注 不能超过 2000 个字符")]
        public string Remark { get; set; }
    }
}