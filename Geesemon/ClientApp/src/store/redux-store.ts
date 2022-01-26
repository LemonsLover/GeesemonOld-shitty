import {Action, applyMiddleware, combineReducers, compose, createStore} from 'redux';
import thunkMiddleware, {ThunkAction} from 'redux-thunk';
import {authReducer} from '../modules/auth/auth-reducer';
import {usersReducer} from '../modules/users/users.reducer';

let rootReducer = combineReducers({
    auth: authReducer,
    users: usersReducer,
});

type RootReducerType = typeof rootReducer;
export type AppStateType = ReturnType<RootReducerType>;

export type InferActionsTypes<T> = T extends { [keys: string]: (...args: any[]) => infer U } ? U : never

export type BaseThunkType<A extends Action, R = Promise<void>> = ThunkAction<Promise<void>, AppStateType, unknown, A>;


// @ts-ignore
const composeEnhancers = window.__REDUX_DEVTOOLS_EXTENSION_COMPOSE__ || compose;
const store = createStore(rootReducer, composeEnhancers(applyMiddleware(thunkMiddleware)));
// @ts-ignore
window.__store__ = store;

export default store;
