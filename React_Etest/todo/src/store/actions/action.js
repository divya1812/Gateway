import * as actionTypes from "./actionTypes";

export const addItem = (description) => {
  return {
    type: actionTypes.ADD_ITEM,
    payload: description,
  };
};

export const deleteItem = (id) => {
  return {
    type: actionTypes.DELETE_ITEM,
    payload: id,
  };
};

export const editItem = (id, description) => {
  return {
    type: actionTypes.EDIT_ITEM,
    payload: {
      id,
      description,
    },
  };
};

export const updateStatus = (id) => {
  return {
    type: actionTypes.STATUS_UPDATE,
    payload: id,
  };
};
