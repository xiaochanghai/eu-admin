﻿/*  代码由框架生成,任何更改都可能导致被代码生成器覆盖，可自行修改。
* SmConfigGroup.cs
*
* 功 能： N / A
* 类 名： SmConfigGroup
*
* Ver    变更日期 负责人  变更内容
* ───────────────────────────────────
* V0.01  2025/2/27 18:30:41  SahHsiao   初版
*
* Copyright(c) 2025 EU Corporation. All Rights Reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　作者：SahHsiao                                                  │
*└──────────────────────────────────┘
*/

namespace EU.Core.Model.Base;

/// <summary>
/// 系统配置组 (Dto.Base)
/// </summary>
public class SmConfigGroupBase : BasePoco
{

    /// <summary>
    /// 上级ID
    /// </summary>
    [Display(Name = "ParentId"), Description("上级ID")]
    public Guid? ParentId { get; set; }

    /// <summary>
    /// 名称
    /// </summary>
    [Display(Name = "Name"), Description("名称"), MaxLength(32, ErrorMessage = "名称 不能超过 32 个字符")]
    public string Name { get; set; }

    /// <summary>
    /// 类型
    /// </summary>
    [Display(Name = "Type"), Description("类型"), MaxLength(32, ErrorMessage = "类型 不能超过 32 个字符")]
    public string Type { get; set; }

    /// <summary>
    /// 排序
    /// </summary>
    [Display(Name = "Sequence"), Description("排序")]
    public int? Sequence { get; set; }

    /// <summary>
    /// 备注
    /// </summary>
    [Display(Name = "Remark"), Description("备注"), MaxLength(2000, ErrorMessage = "备注 不能超过 2000 个字符")]
    public string Remark { get; set; }
}
