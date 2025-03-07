﻿/*  代码由框架生成,任何更改都可能导致被代码生成器覆盖，可自行修改。
* SmCompany.cs
*
* 功 能： N / A
* 类 名： SmCompany
*
* Ver    变更日期 负责人  变更内容
* ───────────────────────────────────
* V0.01  2025/2/27 18:30:37  SahHsiao   初版
*
* Copyright(c) 2025 EU Corporation. All Rights Reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　作者：SahHsiao                                                  │
*└──────────────────────────────────┘
*/

namespace EU.Core.Model.Entity;

/// <summary>
/// 组织 (Model)
/// </summary>
[SugarTable("SmCompany", "组织"), Entity(TableCnName = "组织", TableName = "SmCompany")]
public class SmCompany : BasePoco
{

    /// <summary>
    /// 代码
    /// </summary>
    [Display(Name = "CompanyCode"), Description("代码"), SugarColumn(IsNullable = true, Length = 50)]
    public string CompanyCode { get; set; }

    /// <summary>
    /// 简称
    /// </summary>
    [Display(Name = "CompanyShortName"), Description("简称"), SugarColumn(IsNullable = true, Length = 50)]
    public string CompanyShortName { get; set; }

    /// <summary>
    /// 名称
    /// </summary>
    [Display(Name = "CompanyName"), Description("名称"), SugarColumn(IsNullable = true, Length = 50)]
    public string CompanyName { get; set; }
}
