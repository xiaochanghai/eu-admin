import { DatabaseOutlined, ProductOutlined } from "@ant-design/icons";
import { Mode } from "./dsl/base";

//显示的依赖定义
export type deps = {
  field: string; //依赖的属性
  value: any[]; //依赖的值 满足其中之一即可
};
export interface designProp {
  name: string; //title
  icon?: any;
  type: "select" | "input" | "switch" | "buttonGroup" | "form" | "textArea" | "comboGrid" | "inputNumber"; //设置组件的类型
  tag?: "basic" | "layout"; //所在分组标签
  mode?: Mode[] | Mode; //使用场景
  deps?: deps | deps[]; //字段显示依赖,如果是数组都需要满足
  tooltip?: string; //提示语 label
  comboGridCode?: string; //提示语 label
  items?: {
    //多选时的内容
    icon?: any;
    tooltip?: string; //提示语 label
    label: string;
    default?: boolean; //是否默认值
    value?: any; //嵌套一个，尤它进行值得选择
    mode?: Mode;
    deps?: deps | deps[]; // 满足得一项，或者多项都满足
  }[]; //子项显示依赖
}
export interface SchemaClz {
  [key: string]: designProp; //扩展字段
}
export const types: { title: string; value: string; icon?: any }[] = [
  { title: "数据属性", value: "basic", icon: DatabaseOutlined },
  { title: "布局样式", value: "layout", icon: ProductOutlined }
];

export const schemaDef: SchemaClz = {
  FormTitle: {
    name: "标题",
    type: "input",
    tag: "basic"
  },
  DataIndex: {
    name: "表栏位字段",
    type: "input",
    tag: "basic"
  },
  DefaultValue: {
    name: "默认值",
    type: "input",
    tag: "basic",
    deps: { field: "FieldType", value: ["Input", "InputNumber", "TextArea"] },
    mode: Mode.form
  },
  HideInForm: {
    name: "隐藏",
    type: "switch",
    tag: "layout",
    mode: Mode.form
  },
  Required: {
    name: "必填",
    type: "switch",
    tag: "basic",
    mode: Mode.form
  },
  Disabled: {
    name: "只读",
    type: "switch",
    tag: "layout",
    mode: Mode.form
  },
  // listHide: {
  //   name: "列表",
  //   type: "switch",
  //   tag: "layout",
  // },
  Validator: {
    name: "限定输入格式",
    type: "select",
    mode: Mode.form,
    tag: "basic",
    deps: { field: "FieldType", value: ["Input", "TextArea"] },
    items: [
      { label: "email", value: "email" },
      { label: "phone", value: "phone" },
      { label: "number", value: "number" },
      { label: "idcard", value: "idcard" },
      { label: "采用正则校验", value: "pattern" }
    ]
  },
  ValidPattern: {
    name: "正则表达式",
    type: "input",
    tag: "basic",
    mode: Mode.form,
    tooltip: "必须是正则表达式",
    deps: { field: "Validator", value: ["pattern"] }
  },
  vlife_message: {
    name: "校验提醒",
    type: "input",
    tag: "basic",
    mode: Mode.form,
    deps: { field: "Validator", value: ["pattern"] }
  },
  IsUnique: {
    name: "不允许重复",
    type: "switch",
    mode: Mode.form,
    tag: "basic",
    deps: { field: "FieldType", value: ["Input"] }
  },
  MaxLength: {
    name: "最大长度",
    type: "input",
    tag: "basic",
    mode: Mode.form,
    deps: { field: "FieldType", value: ["Input", "TextArea"] }
  },
  MinLength: {
    name: "最小长度",
    type: "input",
    tag: "basic",
    mode: Mode.form,
    deps: { field: "FieldType", value: ["Input", "TextArea"] }
  },
  Maximum: {
    name: "最大值",
    type: "inputNumber",
    tag: "basic",
    mode: Mode.form,
    deps: { field: "FieldType", value: ["InputNumber"] }
  },
  Minimum: {
    name: "最小值",
    type: "inputNumber",
    tag: "basic",
    mode: Mode.form,
    deps: { field: "FieldType", value: ["InputNumber"] }
  },
  Placeholder: {
    name: "填写占位符",
    type: "textArea",
    mode: Mode.form,
    tag: "basic",
    deps: { field: "FieldType", value: ["Input", "InputNumber", "TextArea"] }
  },
  CreateHide: {
    //保存时才会触发数据产生，无法实时预览
    name: "新增时隐藏",
    tooltip: "保存后生效",
    type: "switch",
    mode: Mode.form,
    tag: "basic"
  },
  ModifyDisabled: {
    name: "修改时只读",
    tooltip: "保存后生效",
    type: "switch",
    mode: Mode.form,
    tag: "basic"
  },
  // hideLabel: {
  //   name: "标签隐藏",
  //   type: "switch",
  //   tag: "layout",
  // },
  // divider: {
  //   name: "分组名称",
  //   type: "switch",
  //   tag: "layout",
  // },
  // dividerLabel: {
  //   name: "",//分组名称
  //   type: "input",
  //   tag: "layout",
  //   deps: { field: "divider", value: [true] },
  // },
  // x_decorator_props$layout: {
  //   name: "标签位置",
  //   type: "buttonGroup",
  //   tag: "layout",
  //   items: [
  //     {
  //       label: "顶部",
  //       value: "vertical",
  //     },
  //     {
  //       label: "水平",
  //       value: "horizontal",
  //     },
  //   ],
  // },
  // x_decorator_props$labelAlign: {
  //   name: "标签对齐",
  //   type: "buttonGroup",
  //   tag: "layout",
  //   deps: { field: "x_decorator_props$layout", value: ["vertical"] },
  //   items: [
  //     {
  //       label: "居左",
  //       value: "left",
  //     },
  //     {
  //       label: "居右",
  //       value: "right",
  //     },
  //   ],
  // },
  formTabCode: {
    name: "所在页签",
    type: "buttonGroup",
    mode: Mode.form,
    tag: "layout",
    // deps://有数量才显示
    // deps: { field: "x_decorator_props$layout", value: ["vertical"] },
    items: []
  },
  GridSpan: {
    name: "字段占比",
    type: "buttonGroup",
    tag: "layout",
    mode: Mode.form
    // items: [
    //   { value: 25, label: "25" },
    //   { value: 50, label: "50" },
    //   { value: 100, label: "100" }
    // ]
  },
  ComboBoxDataSource: {
    name: "数据来源",
    type: "comboGrid",
    tag: "basic",
    comboGridCode: "SmLov",
    deps: { field: "FieldType", value: ["ComboBox"] },
    mode: Mode.form
  },
  ComboGridDataSource: {
    name: "数据来源",
    type: "comboGrid",
    tag: "basic",
    comboGridCode: "SmCommonListSql",
    deps: { field: "FieldType", value: ["ComboGrid"] },
    mode: Mode.form
  },
  Remark: {
    name: "备注",
    type: "input",
    tag: "basic"
  }
  // HideInForm: {
  //   name: "yinc",
  //   type: "input",
  //   tag: "basic"
  // }
};
export default schemaDef;