import axios from 'axios';
import { ROOT_URL } from './apiConfig';

export function addNewRuleAction(rule) {
    const postResult = axios.post(`${ROOT_URL}/api/Aggregate`, rule);
    return {
        type: 'ADD_NEW_RULE',
        payload: postResult
    };
}

export function fetchRulesAction() {
    const request = axios.get(`${ROOT_URL}/api/aggregate`);
    return {
        type: 'FETCH_RULES',
        payload: request
    }
}
