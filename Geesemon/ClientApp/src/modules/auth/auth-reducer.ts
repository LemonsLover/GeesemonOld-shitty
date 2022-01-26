import {Auth} from '../../types/auth';
import {BaseThunkType, InferActionsTypes} from '../../store/redux-store';

let initialState = {
    authData: null as null | Auth,
    isAuth: false,
};

export const authReducer = (state = initialState, action: ActionsType): InitialStateType => {
    switch (action.type) {
        case 'SET_AUTH_DATA':
            return {
                ...state,
                ...action.payload,
            };
        default:
            return state;
    }
};

export const actions = {
    setAuthData: (authData: Auth | null, isAuth: boolean) => ({
        type: 'SET_AUTH_DATA',
        payload: {authData, isAuth},
    } as const),
};

export const login = (login: Auth): ThunkType => async (dispatch) => {
    localStorage.setItem('token', login.accessToken);
    dispatch(actions.setAuthData(login, true));
};

export const logout = (): ThunkType => async (dispatch) => {
    localStorage.removeItem('token');
    dispatch(actions.setAuthData(null, false));
};

type InitialStateType = typeof initialState;
type ActionsType = InferActionsTypes<typeof actions>;
type ThunkType = BaseThunkType<ActionsType>;
