﻿namespace EU.Core.Model.Systems.DataBase;

public class DbColumnInfoOutput
{
    public string TableName { get; set; }

    public int TableId { get; set; }

    public string DbColumnName { get; set; }

    public string PropertyName { get; set; }

    public string DataType { get; set; }

    public int Length { get; set; }

    public string ColumnDescription { get; set; }

    public string DefaultValue { get; set; }

    public bool IsNullable { get; set; }

    public bool IsIdentity { get; set; }

    public bool IsPrimarykey { get; set; }

    public object Value { get; set; }

    public int DecimalDigits { get; set; }

    public int Scale { get; set; }

    public bool IsArray { get; set; }

    internal bool IsJson { get; set; }
}