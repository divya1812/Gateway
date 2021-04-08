import * as actionTypes from "../actions/actionTypes";

var ID = 0;

const items = (state = [], action) => {
  switch (action.type) {
    case actionTypes.ADD_ITEM:
      return [
        ...state,
        {
          id: ++ID,
          title: action.payload,
          isCompleted: false,
        },
      ];

    case actionTypes.EDIT_ITEM:
      return state.map((todo) => {
        if (todo.id !== action.payload.id) {
          return todo;
        }

        return {
          ...todo,
          title: action.payload.description,
        };
      });

    case actionTypes.DELETE_ITEM:
      return state.filter((todo) => todo.id !== action.payload);

    case actionTypes.STATUS_UPDATE:
      return state.map((todo) => {
        if (todo.id !== action.payload) {
          return todo;
        }

        return {
          ...todo,
          isCompleted: true,
        };
      }); 

    default:
      return state;
  }
};

export default items;
