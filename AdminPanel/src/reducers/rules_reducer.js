export default function (state = [], action) {
    switch (action.type) {
        case 'FETCH_RULES':
            return action.payload.data;
    }
    return state;
}