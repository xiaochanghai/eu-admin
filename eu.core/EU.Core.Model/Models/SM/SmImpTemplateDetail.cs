﻿/*  代码由框架生成,任何更改都可能导致被代码生成器覆盖，可自行修改。
* SmImpTemplateDetail.cs
*
*功 能： N / A
* 类 名： SmImpTemplateDetail
*
* Ver    变更日期 负责人  变更内容
* ───────────────────────────────────
*V0.01  2024/4/24 22:43:01  SimonHsiao   初版
*
* Copyright(c) 2024 EU Corporation. All Rights Reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　作者：SimonHsiao                                                  │
*└──────────────────────────────────┘
*/
namespace EU.Core.Model.Models;


/// <summary>
/// 导入模板定义明细 (Model)
/// </summary>
[SugarTable("SmImpTemplateDetail", "SmImpTemplateDetail"), Entity(TableCnName = "导入模板定义明细", TableName = "SmImpTemplateDetail")]
public class SmImpTemplateDetail : BasePoco
{

    /// <summary>
    /// 模板ID
    /// </summary>
    public Guid? ImpTemplateId { get; set; }

    /// <summary>
    /// Execl列号
    /// </summary>
    public int? ColumnNo { get; set; }

    /// <summary>
    /// 列名称
    /// </summary>
    [Display(Name = "ColumnCode"), Description("列名称"), MaxLength(32, ErrorMessage = "列名称 不能超过 32 个字符")]
    public string ColumnCode { get; set; }

    /// <summary>
    /// 是否唯一
    /// </summary>
    public bool? IsUnique { get; set; }

    /// <summary>
    /// 是否插入
    /// </summary>
    public bool? IsInsert { get; set; }

    /// <summary>
    /// 格式
    /// </summary>
    [Display(Name = "DateFormate"), Description("格式"), MaxLength(32, ErrorMessage = "格式 不能超过 32 个字符")]
    public string DateFormate { get; set; }

    /// <summary>
    /// 最大长度
    /// </summary>
    public int? MaxLength { get; set; }

    /// <summary>
    /// 允许为空
    /// </summary>
    public bool? IsAllowNull { get; set; }

    /// <summary>
    /// 加密
    /// </summary>
    public bool? IsEncrypt { get; set; }

    /// <summary>
    /// 参数代码
    /// </summary>
    [Display(Name = "LovCode"), Description("参数代码"), MaxLength(32, ErrorMessage = "参数代码 不能超过 32 个字符")]
    public string LovCode { get; set; }

    /// <summary>
    /// 映射表
    /// </summary>
    [Display(Name = "CorresTableCode"), Description("映射表"), MaxLength(32, ErrorMessage = "映射表 不能超过 32 个字符")]
    public string CorresTableCode { get; set; }

    /// <summary>
    /// 映射字段
    /// </summary>
    [Display(Name = "CorresColumnCode"), Description("映射字段"), MaxLength(32, ErrorMessage = "映射字段 不能超过 32 个字符")]
    public string CorresColumnCode { get; set; }

    /// <summary>
    /// 转换字段
    /// </summary>
    [Display(Name = "TransColumnCode"), Description("转换字段"), MaxLength(32, ErrorMessage = "转换字段 不能超过 32 个字符")]
    public string TransColumnCode { get; set; }

    /// <summary>
    /// 备注
    /// </summary>
    [Display(Name = "Remark"), Description("备注"), MaxLength(2000, ErrorMessage = "备注 不能超过 2000 个字符")]
    public string Remark { get; set; }
}