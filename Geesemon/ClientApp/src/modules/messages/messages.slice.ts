import {createSlice, PayloadAction} from '@reduxjs/toolkit';
import {Message} from './messages.types';

const initialState = {
    messages: [] as Message[],
    messagesLoading: false,
};

export const messagesSlice = createSlice({
    name: 'messages',
    initialState,
    reducers: {
        setMessages: (state, action: PayloadAction<Message[]>) => {
            state.messages = action.payload;
        },
        addMessage: (state, action: PayloadAction<Message>) => {
            state.messages.push(action.payload);
        },
    },
});

export const {setMessages, addMessage} = messagesSlice.actions;
export const messagesReducer = messagesSlice.reducer;
