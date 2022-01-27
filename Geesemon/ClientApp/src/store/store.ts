import {configureStore} from '@reduxjs/toolkit';
import {messagesReducer} from '../modules/messages/messages.slice';
import {TypedUseSelectorHook, useDispatch, useSelector} from 'react-redux';
import {authReducer} from '../modules/auth/auth.slice';

export const store = configureStore({
    reducer: {
        messages: messagesReducer,
        auth: authReducer,
    },
});

type RootState = ReturnType<typeof store.getState>
type AppDispatch = typeof store.dispatch

export const useAppDispatch = () => useDispatch<AppDispatch>()
export const useAppSelector: TypedUseSelectorHook<RootState> = useSelector
