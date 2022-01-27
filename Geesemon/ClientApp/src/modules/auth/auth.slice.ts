import {createSlice, PayloadAction} from '@reduxjs/toolkit';
import {Auth} from './auth.types';

const initialState = {
    isAuth: false,
    authData: null as null | Auth,
};

export const authSlice = createSlice({
    name: 'auth',
    initialState,
    reducers: {
        setIsAuth: (state, action: PayloadAction<boolean>) => {
            state.isAuth = action.payload;
        },
        setAuthData: (state, action: PayloadAction<Auth | null>) => {
            state.authData = action.payload;
        },
    },
});

export const {setIsAuth, setAuthData} = authSlice.actions;
export const authReducer = authSlice.reducer;
