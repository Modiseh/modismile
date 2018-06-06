import { combineReducers } from 'redux';
import RulesReducer from '../reducers/rules_reducer';

const rootReducer = combineReducers({
    rules: RulesReducer
});

export default rootReducer;
