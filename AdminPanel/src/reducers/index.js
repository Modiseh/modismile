import { combineReducers } from 'redux';
import currentRuleReducer  from './currentRule_Reducer';

const rootReducer = combineReducers({
  currentRule: currentRuleReducer
});

export default rootReducer;
