import { createSlice, PayloadAction } from "@reduxjs/toolkit";
// import { ModuleInfo } from "@/api/interface/index";
// import { IWorkFlowNode } from "@/workflow-editor/interfaces";
import { NodeType } from "@/workflow-editor/interfaces";
import { modifyWorkFlowStartNode } from "@/utils";

interface IErrors {
  [nodeId: string]: string | undefined;
}
const state: any = {
  errors: {},
  validated: null,
  undoList: [],
  redoList: [],
  changeNode: {},
  selectedId: null,
  changeFlag: false,
  startNode: {
    id: "start",
    nodeType: NodeType.start
  }
};

const workflowSlice = createSlice({
  name: "hooks-workflow",
  initialState: state,
  reducers: {
    SET_ERRORS(state, { payload }: PayloadAction<IErrors>) {
      state.errors = payload;
    },
    SET_VALIDATED(state, { payload }: PayloadAction<boolean>) {
      state.validated = payload;
    },
    SET_UNOLIST(state, { payload }: PayloadAction<any>) {
      state.undoList = payload;
    },
    SET_REDOLIST(state, { payload }: PayloadAction<any>) {
      state.redoList = payload;
    },
    SET_START_NODE(state, { payload }: PayloadAction<any>) {
      state.startNode = payload;
    },
    CHANGE_NODE(state, { payload }: PayloadAction<any>) {
      if (state.startNode.id === payload.id) state.startNode = payload;
    },
    ADD_NODE(state, { payload }: PayloadAction<any>) {
      if (state.startNode.id === payload.parentId)
        state.startNode = { ...state.startNode, childNode: { ...payload.node, childNode: state.startNode.childNode } };
      else modifyWorkFlowStartNode(state.startNode, "childNode", payload.node, payload.parentId);
    },
    SELECT_NODE(state, { payload }: PayloadAction<any>) {
      state.selectedId = payload;
    },
    DELETE_NODE(state, { payload }: PayloadAction<any>) {
      state.selectedId = payload;
      if (payload === state.startNode.childNode?.id)
        state.startNode = { ...state.startNode, childNode: state.startNode.childNode.childNode };
    }
  }
});

export const {
  SET_ERRORS,
  SET_UNOLIST,
  SET_VALIDATED,
  SET_REDOLIST,
  SET_START_NODE,
  DELETE_NODE,
  CHANGE_NODE,
  SELECT_NODE,
  ADD_NODE
} = workflowSlice.actions;
export default workflowSlice.reducer;