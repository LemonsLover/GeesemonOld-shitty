import {AppStateType} from '../../store/redux-store';

export const s_getUsers = (state: AppStateType) => {
    return state.users.users;
}

export const s_getUsersLoading = (state: AppStateType) => {
    return state.users.usersLoading;
}
