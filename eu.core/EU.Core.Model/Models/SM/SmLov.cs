﻿/*  代码由框架生成,任何更改都可能导致被代码生成器覆盖，可自行修改。
* SmLov.cs
*
* 功 能： N / A
* 类 名： SmLov
*
* Ver    变更日期 负责人  变更内容
* ───────────────────────────────────
* V0.01  2024/12/10 9:21:46  SimonHsiao   初版
*
* Copyright(c) 2024 EU Corporation. All Rights Reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　作者：SimonHsiao                                                  │
*└──────────────────────────────────┘
*/

namespace EU.Core.Model.Models;

/// <summary>
/// 字典管理 (Model)
/// </summary>
[SugarTable("SmLov", "字典管理"), Entity(TableCnName = "字典管理", TableName = "SmLov")]
public class SmLov : BasePoco
{

    /// <summary>
    /// 字典代码
    /// </summary>
    [Display(Name = "LovCode"), Description("字典代码"), MaxLength(32, ErrorMessage = "字典代码 不能超过 32 个字符")]
    public string LovCode { get; set; }

    /// <summary>
    /// 字典名称
    /// </summary>
    [Display(Name = "LovName"), Description("字典名称"), MaxLength(32, ErrorMessage = "字典名称 不能超过 32 个字符")]
    public string LovName { get; set; }

    /// <summary>
    /// 生效时间
    /// </summary>
    [Display(Name = "InureTime"), Description("生效时间")]
    public DateTime? InureTime { get; set; }

    /// <summary>
    /// 失效时间
    /// </summary>
    [Display(Name = "AbateTime"), Description("失效时间")]
    public DateTime? AbateTime { get; set; }

    /// <summary>
    /// 是否标签显示
    /// </summary>
    [Display(Name = "IsTagDisplay"), Description("是否标签显示")]
    public bool? IsTagDisplay { get; set; }

    /// <summary>
    /// 备注
    /// </summary>
    [Display(Name = "Remark"), Description("备注"), MaxLength(2000, ErrorMessage = "备注 不能超过 2000 个字符")]
    public string Remark { get; set; }
}
