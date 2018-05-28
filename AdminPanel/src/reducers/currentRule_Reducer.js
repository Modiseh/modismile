export default function currentRule(state = {
    title: '',
    description: '',
    rate: 1,
    version: 1,
    priority: 1,
    expiresAfterDays: 0,
    dateFrom: new Date(),
    dateTo: new Date()
}, action) {
    switch (action.type) {
        case 'ADD_NEW_RULE':
            return action.payload;
    }
    return state;
}