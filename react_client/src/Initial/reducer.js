import initStore from "./initStore";

const reducer = (state = initStore(), action) => {
  switch (action.type) {
    case "CHANGE_TOTAL_DEVICE": 
      return { ...state, totalDevice: action.payload };
    default:
      throw new Error(`No action with type: ${action.type}`);
  }
};
export default reducer;