﻿/*  代码由框架生成,任何更改都可能导致被代码生成器覆盖，可自行修改。
* ArCheckDetail.cs
*
*功 能： N / A
* 类 名： ArCheckDetail
*
* Ver    变更日期 负责人  变更内容
* ───────────────────────────────────
*V0.01  2024/4/30 18:09:47  SimonHsiao   初版
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
    /// 应收对账单明细 (Model)
    /// </summary>
    [SugarTable("ArCheckDetail", "ArCheckDetail"), Entity(TableCnName = "应收对账单明细", TableName = "ArCheckDetail")]
    public class ArCheckDetail : BasePoco
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
        /// 订单来源
        /// </summary>
        [Display(Name = "OrderSource"), Description("订单来源"), MaxLength(32, ErrorMessage = "订单来源 不能超过 32 个字符")]
        public string OrderSource { get; set; }

        /// <summary>
        /// 来源订单ID
        /// </summary>
        public Guid? SourceOrderId { get; set; }

        /// <summary>
        /// 来源订单号
        /// </summary>
        [Display(Name = "SourceOrderNo"), Description("来源订单号"), MaxLength(32, ErrorMessage = "来源订单号 不能超过 32 个字符")]
        public string SourceOrderNo { get; set; }

        /// <summary>
        /// 销售单号
        /// </summary>
        [Display(Name = "SalesOrderNo"), Description("销售单号"), MaxLength(32, ErrorMessage = "销售单号 不能超过 32 个字符")]
        public string SalesOrderNo { get; set; }

        /// <summary>
        /// 来源单日期
        /// </summary>
        public DateTime? SourceOrderDate { get; set; }

        /// <summary>
        /// 出库订单明细ID
        /// </summary>
        public Guid? SourceOrderDetailId { get; set; }

        /// <summary>
        /// 来源订单明细序号
        /// </summary>
        public int? SourceSerialNumber { get; set; }

        /// <summary>
        /// 物料ID
        /// </summary>
        public Guid? MaterialId { get; set; }

        /// <summary>
        /// 交易数量
        /// </summary>
        [Display(Name = "TradeQTY"), Description("交易数量"), Column(TypeName = "decimal(20,8)")]
        public decimal? TradeQTY { get; set; }

        /// <summary>
        /// 已对账数量
        /// </summary>
        [Display(Name = "HasCheckQTY"), Description("已对账数量"), Column(TypeName = "decimal(20,8)")]
        public decimal? HasCheckQTY { get; set; }

        /// <summary>
        /// 未对账数量
        /// </summary>
        [Display(Name = "NoCheckQTY"), Description("未对账数量"), Column(TypeName = "decimal(20,8)")]
        public decimal? NoCheckQTY { get; set; }

        /// <summary>
        /// 对账数量
        /// </summary>
        [Display(Name = "CheckQTY"), Description("对账数量"), Column(TypeName = "decimal(20,8)")]
        public decimal? CheckQTY { get; set; }

        /// <summary>
        /// 单价
        /// </summary>
        [Display(Name = "Price"), Description("单价"), Column(TypeName = "decimal(20,2)")]
        public decimal? Price { get; set; }

        /// <summary>
        /// 税率
        /// </summary>
        [Display(Name = "TaxRate"), Description("税率"), Column(TypeName = "decimal(20,6)")]
        public decimal? TaxRate { get; set; }

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
}