﻿/*  代码由框架生成,任何更改都可能导致被代码生成器覆盖，可自行修改。
* PdReturnOrder.cs
*
*功 能： N / A
* 类 名： PdReturnOrder
*
* Ver    变更日期 负责人  变更内容
* ───────────────────────────────────
*V1.0  2024/5/6 14:40:05  SimonHsiao   初版
*
* Copyright(c) 2024 SUZHOU EU Corporation. All Rights Reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：苏州一优信息技术有限公司                                │
*└──────────────────────────────────┘
*/ 
using EU.Core.IServices.BASE;
using EU.Core.Model.Models;

namespace EU.Core.IServices
{	
	/// <summary>
	/// PdReturnOrder(自定义服务接口)
	/// </summary>	
    public interface IPdReturnOrderServices :IBaseServices<PdReturnOrder, PdReturnOrderDto, InsertPdReturnOrderInput, EditPdReturnOrderInput>
	{
    }
}