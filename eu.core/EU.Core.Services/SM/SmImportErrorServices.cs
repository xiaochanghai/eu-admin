﻿/*  代码由框架生成,任何更改都可能导致被代码生成器覆盖，可自行修改。
* SmImportError.cs
*
*功 能： N / A
* 类 名： SmImportError
*
* Ver    变更日期 负责人  变更内容
* ───────────────────────────────────
*V1.0  2024/4/22 9:44:16  SimonHsiao   初版
*
* Copyright(c) 2024 SUZHOU EU Corporation. All Rights Reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：苏州一优信息技术有限公司                                │
*└──────────────────────────────────┘
*/

namespace EU.Core.Services;

/// <summary>
/// 系统导入模板异常信息 (服务)
/// </summary>
public class SmImportErrorServices : BaseServices<SmImportError, SmImportErrorDto, InsertSmImportErrorInput, EditSmImportErrorInput>, ISmImportErrorServices
{
    private readonly IBaseRepository<SmImportError> _dal;
    public SmImportErrorServices(IBaseRepository<SmImportError> dal)
    {
        this._dal = dal;
        base.BaseDal = dal;
    }
}