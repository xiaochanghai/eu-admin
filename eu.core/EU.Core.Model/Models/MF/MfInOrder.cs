﻿/*  代码由框架生成,任何更改都可能导致被代码生成器覆盖，可自行修改。
* MfInOrder.cs
*
*功 能： N / A
* 类 名： MfInOrder
*
* Ver    变更日期 负责人  变更内容
* ───────────────────────────────────
*V0.01  2024/5/6 14:30:03  SimonHsiao   初版
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
    /// MfInOrder (Model)
    /// </summary>
    [SugarTable("MfInOrder", "MfInOrder"), Entity(TableCnName = "MfInOrder", TableName = "MfInOrder")]
    public class MfInOrder : BasePoco
    {

        /// <summary>
        /// 单号
        /// </summary>
        [Display(Name = "OrderNo"), Description("单号"), MaxLength(32, ErrorMessage = "单号 不能超过 32 个字符")]
        public string OrderNo { get; set; }

        /// <summary>
        /// 建立日期
        /// </summary>
        public DateTime? OrderDate { get; set; }

        /// <summary>
        /// 仓库ID
        /// </summary>
        public Guid? StockId { get; set; }

        /// <summary>
        /// 货位ID
        /// </summary>
        public Guid? GoodsLocationId { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [Display(Name = "Remark"), Description("备注"), MaxLength(2000, ErrorMessage = "备注 不能超过 2000 个字符")]
        public string Remark { get; set; }
    }
}