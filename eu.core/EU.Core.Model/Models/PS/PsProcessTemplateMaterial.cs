﻿/*  代码由框架生成,任何更改都可能导致被代码生成器覆盖，可自行修改。
* PsProcessTemplateMaterial.cs
*
*功 能： N / A
* 类 名： PsProcessTemplateMaterial
*
* Ver    变更日期 负责人  变更内容
* ───────────────────────────────────
*V0.01  2024/5/6 14:58:33  SimonHsiao   初版
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
    /// PsProcessTemplateMaterial (Model)
    /// </summary>
    [SugarTable("PsProcessTemplateMaterial", "PsProcessTemplateMaterial"), Entity(TableCnName = "PsProcessTemplateMaterial", TableName = "PsProcessTemplateMaterial")]
    public class PsProcessTemplateMaterial : BasePoco
    {

        /// <summary>
        /// 模板ID
        /// </summary>
        public Guid? TemplateId { get; set; }

        /// <summary>
        /// 物料ID
        /// </summary>
        public Guid? MaterialId { get; set; }

        /// <summary>
        /// 批量
        /// </summary>
        [Display(Name = "BulkQty"), Description("批量"), Column(TypeName = "decimal(20,6)")]
        public decimal? BulkQty { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [Display(Name = "Remark"), Description("备注"), MaxLength(2000, ErrorMessage = "备注 不能超过 2000 个字符")]
        public string Remark { get; set; }
    }
}