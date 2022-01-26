import {User} from '../../types/auth';
import {BaseThunkType, InferActionsTypes} from '../../store/redux-store';
import {usersAPI} from './users.api';

let initialState = {
    users: [] as User[],
    usersLoading: false,
};

export const usersReducer = (state = initialState, action: ActionsType): InitialStateType => {
    switch (action.type) {
        case 'SET_USERS':
            return {
                ...state,
                users: action.payload.users,
            };
        case 'ADD_USER':
            return {
                ...state,
                users: [...state.users, action.payload.user],
            };
        case 'SET_USERS_LOADING':
            return {
                ...state,
                usersLoading: action.payload.loading,
            };
        default:
            return state;
    }
};

export const actions = {
    setUsers: (users: User[]) => ({
        type: 'SET_USERS',
        payload: {users},
    } as const),
    addUser: (user: User) => ({
        type: 'ADD_USER',
        payload: {user},
    } as const),
    setUsersLoading: (loading: boolean) => ({
        type: 'SET_USERS_LOADING',
        payload: {loading},
    } as const),
};

export const loadUsers = (): ThunkType => async (dispatch) => {
    dispatch(actions.setUsersLoading(true));
    const users = await usersAPI.getUsers();
    dispatch(actions.setUsers(users));
    dispatch(actions.setUsersLoading(false));
};

type InitialStateType = typeof initialState;
type ActionsType = InferActionsTypes<typeof actions>;
type ThunkType = BaseThunkType<ActionsType>;
