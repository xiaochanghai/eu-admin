﻿/*  代码由框架生成,任何更改都可能导致被代码生成器覆盖，可自行修改。
* BdSettlementWay.cs
*
*功 能： N / A
* 类 名： BdSettlementWay
*
* Ver    变更日期 负责人  变更内容
* ───────────────────────────────────
*V0.01  2024/4/25 19:29:36  SimonHsiao   初版
*
* Copyright(c) 2024 EU Corporation. All Rights Reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　作者：SimonHsiao                                                  │
*└──────────────────────────────────┘
*/
namespace EU.Core.Model.Models;


/// <summary>
/// 结算方式 (Dto.Base)
/// </summary>
public class BdSettlementWayBase
{

    /// <summary>
    /// 结算编号
    /// </summary>
    [Display(Name = "SettlementNo"), Description("结算编号"), MaxLength(32, ErrorMessage = "结算编号 不能超过 32 个字符")]
    public string SettlementNo { get; set; }

    /// <summary>
    /// 账款类型 
    /// </summary>
    [Display(Name = "SettlementAccountType"), Description("账款类型 不能超过 32 个字符")]
    public string SettlementAccountType { get; set; }

    /// <summary>
    /// 账期天数
    /// </summary>
    public int? Days { get; set; }

    /// <summary>
    /// 收付款（收-Get、付-Out选择）
    /// </summary>
    [Display(Name = "SettlementBillType"), Description("收付款（收-Get、付-Out选择）"), MaxLength(32, ErrorMessage = "收付款（收-Get、付-Out选择） 不能超过 32 个字符")]
    public string SettlementBillType { get; set; }

    /// <summary>
    /// 备注
    /// </summary>
    [Display(Name = "Remark"), Description("备注"), MaxLength(2000, ErrorMessage = "备注 不能超过 2000 个字符")]
    public string Remark { get; set; }

    /// <summary>
    /// 结算名称
    /// </summary>
    [Display(Name = "SettlementName"), Description("结算名称"), MaxLength(32, ErrorMessage = "结算名称 不能超过 32 个字符")]
    public string SettlementName { get; set; }
}
