/* eslint-disable @typescript-eslint/no-unused-vars */
import React, { useEffect, useState } from "react";
import { useDispatch } from "@/redux";
import { Popconfirm, Button } from "antd";
import { EditableProTable } from "@ant-design/pro-components";
import { Loading } from "@/components/Loading/index";
import { getModuleInfo } from "@/api/modules/module";
import { RootState, useSelector } from "@/redux";
import { ModuleInfo, ModifyType } from "@/api/interface/index";
import { setModuleInfo } from "@/redux/modules/module";
import http from "@/api";
import { pagination1 } from "@/config/proTable";
import { query } from "@/api/modules/module";
import { message } from "@/hooks/useMessage";
import { Icon } from "@/components/Icon";

const ProTableEditable: React.FC<any> = props => {
  const dispatch = useDispatch();
  const [isLoading, setIsLoading] = useState(true);
  const moduleInfos = useSelector((state: RootState) => state.module.moduleInfos);
  let { moduleCode, modifyType, masterId, tableRef, editableCallBack, addCallBack } = props;
  let moduleInfo = moduleInfos[moduleCode] as ModuleInfo;
  let { masterColumn, url } = moduleInfo || {};

  useEffect(() => {
    const getModuleInfo1 = async () => {
      let { Data } = await getModuleInfo(moduleCode);
      dispatch(setModuleInfo(Data));
    };
    if (!moduleInfo) getModuleInfo1();

    setIsLoading(false);
  }, []);

  const [editableKeys, setEditableRowKeys] = useState<React.Key[]>([]);
  const [dataSource, setDataSource] = useState<any>([]);
  const [selectedRowKeys, setSelectedRowKeys] = React.useState([]);

  // 定义选择行的变化时的回调函数
  // const onSelectChange = (keys: any, rows: any) => {
  const onSelectChange = (keys: any) => {
    setSelectedRowKeys(keys);
    // 可以在这里处理选中行的数据，例如执行某些操作
  };
  const actionColumn = {
    title: "操作",
    dataIndex: "option",
    fixed: "right",
    valueType: "option",
    width: 150,
    render: (_text: any, record: any, _: any, action: any) => [
      <a
        key="editable"
        onClick={() => {
          if (editableKeys.length > 0) action?.saveEditable?.(editableKeys[0]);
          action?.startEditable?.(record.ID);
        }}
      >
        编辑
      </a>,
      <Popconfirm
        title="提醒"
        description="是否确定删除记录?"
        onConfirm={async () => {
          let { Success, Message } = await http.delete<any>(url + "/" + record.ID);
          if (Success) message.success(Message);
          if (tableRef.current) tableRef.current.reload();
        }}
        okType="danger"
        okText="确定"
        cancelText="取消"
      >
        <a key="delete">删除</a>
      </Popconfirm>
    ]
  };
  let columns: any = [];
  if (modifyType == ModifyType.Edit) {
    if (moduleInfo && moduleInfo.columns) columns = [...moduleInfo.columns, actionColumn];
  } else if (moduleInfo && moduleInfo.columns) columns = [...moduleInfo.columns];
  return (
    <>
      {isLoading ? (
        <Loading />
      ) : (
        <>
          {moduleInfo && columns ? (
            <EditableProTable
              rowKey="ID"
              className="ant-pro-table-scroll"
              // scroll={{ x: 1000, y: "100%" }}
              scroll={{ scrollToFirstRowOnChange: true, x: columns.length * 100, y: "100%" }}
              recordCreatorProps={false}
              rowSelection={{
                alwaysShowAlert: true,
                onChange: onSelectChange,
                selectedRowKeys
                // onSelect, //用户手动选择/取消选择某行的回调
                //   onSelectMultiple: onMulSelect, //用户使用键盘 shift 选择多行的回调
                //   onSelectAll: onMulSelect, //用户手动选择/取消选择所有行的回调
              }}
              actionRef={tableRef}
              // tableAlertRender={({ selectedRowKeys, selectedRows, onCleanSelected }) => {

              // toolBarRender={() => [
              //   <Space size={0}>
              //     <Button
              //       disabled={modifyType == ModifyType.Edit ? false : true}
              //       onClick={() => {
              //         if (!id) {
              //           message.error("请先保存主表数据！");
              //           return;
              //         }
              //         setMaterialQueryVisible(true);
              //       }}
              //     >
              //       添加
              //     </Button>
              //   </Space>
              // ]}
              toolBarRender={() => [
                <Button
                  disabled={modifyType == ModifyType.Edit ? false : true}
                  type="primary"
                  icon={<Icon name="PlusOutlined" />}
                  onClick={() => {
                    if (!masterId) {
                      message.error("请先保存主表数据！");
                      return;
                    }
                    if (addCallBack) addCallBack();
                  }}
                >
                  添加
                </Button>
              ]}
              tableAlertRender={false}
              tableAlertOptionRender={false}
              // tableAlertRender={({ selectedRowKeys }) => {
              //   // if (tableAlertRenderShow) {
              //   return (
              //     <Space size={0}>
              //       <Button type="link" disabled={selectedRowKeys.length == 0 ? true : false}>
              //         批量删除
              //       </Button>
              //       <Button type="link" disabled={selectedRowKeys.length == 0 ? true : false}>
              //         批量填充
              //       </Button>

              //       {selectedRowKeys.length > 0 ? (
              //         <span style={{ color: "#000" }}>
              //           已选{selectedRowKeys.length}/{materialTotal}项
              //         </span>
              //       ) : (
              //         <span style={{ color: "#000" }}> 共{materialTotal}项</span>
              //       )}
              //       {selectedRowKeys.length > 0 ? <Button type="link">清空</Button> : null}
              //     </Space>
              //   );
              //   // }
              // }}
              // tableAlertOptionRender={() => {
              //   // if (tableAlertRenderShow) {
              //   return (
              //     <Space size={0}>
              //       <Button onClick={() => setMaterialQueryVisible(true)}>添加</Button>
              //     </Space>
              //   );
              //   // }
              // }}
              columns={columns}
              request={async (_params, sorter, filterCondition) => {
                if (masterId) {
                  if (masterColumn) filterCondition = { ...filterCondition, [masterColumn]: masterId };
                  let result = await query({
                    paramData: JSON.stringify(_params),
                    sorter: JSON.stringify(sorter),
                    filter: JSON.stringify(filterCondition),
                    moduleCode
                  });
                  return {
                    data: result.data,
                    total: result.total,
                    success: true
                  };
                } else
                  return {
                    data: [],
                    total: 0,
                    success: true
                  };
              }}
              pagination={pagination1}
              options={{
                search: true,
                fullScreen: true,
                reload: true,
                setting: true,
                density: true
              }}
              value={dataSource}
              onChange={setDataSource}
              editable={{
                type: "multiple",
                editableKeys,
                onSave: async (rowKey, data: any, _row) => {
                  let params = { ...data, ModuleCode: moduleCode };
                  let { Success, Data } = await http.put<any>(url + "/UpdateReturn/" + rowKey, params);
                  if (Success) if (editableCallBack) data = editableCallBack(data, Data);
                },
                onChange: setEditableRowKeys
              }}
              {...props}
            />
          ) : null}
        </>
      )}
    </>
  );
};

export default ProTableEditable;