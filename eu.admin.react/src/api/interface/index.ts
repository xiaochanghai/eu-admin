// Request response parameters (excluding data)
import type { ProColumns } from "@ant-design/pro-components";
export interface Result {
  Status: number;
  Message: string;
}

// Request response parameters (including data)
export interface ResultData<T = any> extends Result {
  Data: T;
  Success: boolean;
}

export interface ResultPage {
  current: number;
  data: [];
  message: string;
  pageSize: number;
  total: number;
  pageCount: number;
  status: number;
  success: boolean;
}
// paging request parameters
export interface ReqPage {
  current?: number;
  pageSize?: number;
}

// paging response parameters
export interface ResPage<T> {
  list: T[];
  current: number;
  pageSize: number;
  total: number;
}

export interface ReqLogin {
  username: string;
  password: string;
}

export interface ResLogin {
  Token: string;
  UserId: string;
}

export interface UserList {
  id: string;
  username: string;
  gender: 1 | 2;
  age: number;
  idCard: string;
  email: string;
  address: string;
  createTime: string;
  status: boolean;
  avatar: string;
}
export interface ModuleInfo {
  IsShowAudit: boolean;
  Success: boolean;
  UserModuleColumn: {};
  actionCount: number;
  actionData: [];
  actions: [];
  beforeActions: ModuleInfoBeforeAction[];
  children: [];
  columns: ProColumns[];
  dropActions: [];
  formColumns: [];
  formPage: string;
  formPageWidth: number;
  hideMenu: [];
  isDetail: false;
  masterColumn: string;
  menuData: [];
  moduleId: string;
  moduleName: string;
  moduleCode: string;
  moduleType: string;
  openType: string;
  url: string;
}
export interface ModuleInfoBeforeAction {
  id: string;
  taxisNo: number;
}
export interface RecordLogData {
  TableName: string;
  ID: string;
  CreatedBy: string;
  UpdateBy: string;
  CreatedTime: string;
  UpdateTime: string;
}
export interface SmLovData {
  key: string;
  value: string;
}
/**
 * ts数据类型
 */
export enum ModifyType {
  Add = "Add", //新增模式
  Edit = "Edit", //修改模式。
  View = "View", //修改模式。
  Delete = "Delete", //删除模式
  Insert = "Insert", //插入模式
  AuditPass = "AuditPass" //审核通过模式
}