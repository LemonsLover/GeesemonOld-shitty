import {createSlice, PayloadAction} from '@reduxjs/toolkit';
import {Auth} from './auth.types';

const initialState = {
    isAuth: false,
    authData: null as Auth | null | undefined,
};

export const authSlice = createSlice({
    name: 'auth',
    initialState,
    reducers: {
        setAuth: (state, action: PayloadAction<{ isAuth: boolean, authData: Auth | null | undefined }>) => {
            const token = action.payload?.authData?.token ? action.payload?.authData?.token : '';
            localStorage.setItem('token', token);
            state.isAuth = action.payload.isAuth;
            state.authData = action.payload.authData;
        },
    },
});

export const authActions = authSlice.actions;
export const authReducer = authSlice.reducer;
