// import { useEffect } from "react";
import { useDispatch } from "@/redux";
import { store } from "@/redux";
import {
  SET_ERRORS,
  SET_VALIDATED,
  SET_UNOLIST,
  SET_REDOLIST,
  SET_START_NODE,
  CHANGE_NODE,
  ADD_NODE,
  SELECT_NODE,
  DELETE_NODE
} from "@/redux/modules/workflow";
import { useEditorEngine } from "../workflow-editor/hooks";
import { IErrors } from "@/workflow-editor/interfaces/state";
import { IBranchNode, IRouteNode, IWorkFlowNode, NodeType } from "@/workflow-editor/interfaces";
import { createUuid } from "@/utils";
import { useTranslate } from "@/workflow-editor/react-locales";

export function useWorkFlow() {
  const dispatch = useDispatch();
  const editorStore = useEditorEngine();
  const t = useTranslate();
  // useEffect(() => {}, []);
  function addNode(parentId: string, node: IWorkFlowNode) {
    backup();
    dispatch(ADD_NODE({ parentId, node }));
    revalidate();
  }
  function backup() {
    let state = store.getState().workflow;
    const list = [...state.undoList, { startNode: state.startNode, validated: state.validated }];

    dispatch(SET_UNOLIST(list));
    dispatch(SET_REDOLIST([]));
  }
  //审批流节点不多，节点变化全部重新校验一遍，无需担心性能问题，以后有需求再优化
  function revalidate() {
    if (store.getState().workflow.validated) validate();
  }

  function validate() {
    dispatch(SET_VALIDATED(true));

    const errors: IErrors = {};
    setErrors({});
    doValidateNode(store.getState().workflow.startNode, errors);
    if (Object.keys(errors).length > 0) {
      setErrors(errors);
      return errors;
    }
    return true;
  }
  function setErrors(errors: IErrors) {
    dispatch(SET_ERRORS(errors));
  }

  function doValidateNode(node: IWorkFlowNode, errors: IErrors) {
    const materialUi = editorStore?.materialUis[node.nodeType];
    if (materialUi?.validate) {
      if (editorStore != null) {
        let t = { t: editorStore.t };
        const result = materialUi.validate(node, t);
        if (result !== true && result !== undefined) errors[node.id] = result;
      }
    }
    if (node.childNode) doValidateNode(node.childNode, errors);
    if (node.nodeType === NodeType.route) {
      for (const condition of (node as IRouteNode).conditionNodeList) {
        doValidateNode(condition, errors);
      }
    }
  }
  function selectNode(id: string | undefined) {
    dispatch(SELECT_NODE(id));
  }
  function changeNode(node: any) {
    backup();

    dispatch(CHANGE_NODE(node));

    revalidate();
  }

  //dlc 取消
  function undo() {
    let state = store.getState().workflow;
    const newUndoList = [...state.undoList];
    const snapshot = newUndoList.pop();
    if (!snapshot) {
      console.error("No element in undo list");
      return;
    }
    dispatch(SET_UNOLIST(newUndoList));

    const list = [...state.redoList, { startNode: state.startNode }];

    dispatch(SET_REDOLIST(list));
    dispatch(SET_START_NODE(snapshot?.startNode));
    dispatch(SET_VALIDATED(snapshot?.validated));
  }

  // dlc 重做
  function redo() {
    let state = store.getState().workflow;
    const newRedoList = [...state.redoList];
    const snapshot = newRedoList.pop();
    if (!snapshot) {
      console.error("No element in redo list");
      return;
    }

    dispatch(SET_REDOLIST(newRedoList));

    dispatch(SET_UNOLIST([...state.undoList, { startNode: state.startNode }]));

    dispatch(SET_START_NODE(snapshot?.startNode));
    dispatch(SET_VALIDATED(snapshot?.validated));
  }
  function removeNode(id?: string) {
    if (id) {
      backup();
      dispatch(DELETE_NODE(id));
      revalidate();
    }
  }

  function removeCondition(node: IRouteNode, conditionId: string) {
    //如果只剩2个分支，则删除节点
    if (node.conditionNodeList.length <= 2) {
      removeNode(node.id);
      return;
    }
    backup();
    const newNode: IRouteNode = { ...node, conditionNodeList: node.conditionNodeList.filter(co => co.id !== conditionId) };
    changeNode(newNode);
  }
  function resetId(node: IWorkFlowNode) {
    node.id = createUuid();
    if (node.childNode) {
      resetId(node.childNode);
    }
    if (node.nodeType === NodeType.route) {
      for (const condition of (node as IRouteNode).conditionNodeList) {
        resetId(condition);
      }
    }
  }
  //克隆一个条件
  function cloneCondition(node: IRouteNode, condition: IBranchNode) {
    const newCondition = JSON.parse(JSON.stringify(condition));
    newCondition.name = newCondition.name + t?.("ofCopy");
    //重写Id
    resetId(newCondition);
    const index = node.conditionNodeList.indexOf(condition);
    const newList = [...node.conditionNodeList];
    newList.splice(index + 1, 0, newCondition);
    const newNode: IRouteNode = { ...node, conditionNodeList: newList };
    changeNode(newNode);
  }
  return { validate, addNode, selectNode, changeNode, undo, redo, removeNode, removeCondition, cloneCondition };
}