﻿/*  代码由框架生成,任何更改都可能导致被代码生成器覆盖，可自行修改。
* SmCompany.cs
*
*功 能： N / A
* 类 名： SmCompany
*
* Ver    变更日期 负责人  变更内容
* ───────────────────────────────────
*V0.01  2024/4/24 16:25:44  SimonHsiao   初版
*
* Copyright(c) 2024 EU Corporation. All Rights Reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　作者：SimonHsiao                                                  │
*└──────────────────────────────────┘
*/
namespace EU.Core.Model.Models;


/// <summary>
/// 组织 (Dto.Base)
/// </summary>
public class SmCompanyBase
{

    /// <summary>
    /// CompanyCode
    /// </summary>
    [Display(Name = "CompanyCode"), Description("CompanyCode"), MaxLength(50, ErrorMessage = "CompanyCode 不能超过 50 个字符")]
    public string CompanyCode { get; set; }

    /// <summary>
    /// CompanyShortName
    /// </summary>
    [Display(Name = "CompanyShortName"), Description("CompanyShortName"), MaxLength(50, ErrorMessage = "CompanyShortName 不能超过 50 个字符")]
    public string CompanyShortName { get; set; }

    /// <summary>
    /// CompanyName
    /// </summary>
    [Display(Name = "CompanyName"), Description("CompanyName"), MaxLength(50, ErrorMessage = "CompanyName 不能超过 50 个字符")]
    public string CompanyName { get; set; }
}