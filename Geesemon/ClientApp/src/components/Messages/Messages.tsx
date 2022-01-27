import React, {useEffect, useState} from 'react';
import {useDispatch} from 'react-redux';
import {useAppSelector} from '../../store/store';
import {useMutation, useQuery, useSubscription} from '@apollo/client';
import {GET_MESSAGES_QUERY, GetMessagesData, GetMessagesVars} from '../../modules/messages/messages.queries';
import {addMessage, setMessages} from '../../modules/messages/messages.slice';
import {
    MESSAGE_ADDED_SUBSCRIPTION,
    MessageAddedData,
    MessageAddedVars,
} from '../../modules/messages/messages.subscriptions';
import s from './Messages.module.css';
import {CREATE_MESSAGE_MUTATION, CreateMessageData, CreateMessageVars} from '../../modules/messages/messages.mutations';
import {Loading} from '../Loading/Loading';

export const Messages = () => {
    const messages = useAppSelector(state => state.messages.messages);
    const messagesLoading = useAppSelector(state => state.messages.messagesLoading);
    const dispatch = useDispatch();
    const getMessagesQuery = useQuery<GetMessagesData, GetMessagesVars>(GET_MESSAGES_QUERY);
    const messageAddedSubscription = useSubscription<MessageAddedData, MessageAddedVars>(MESSAGE_ADDED_SUBSCRIPTION);
    const [createUserMutation, createUserMutationOptions] = useMutation<CreateMessageData, CreateMessageVars>(CREATE_MESSAGE_MUTATION);

    const [newMessageText, setNewMessageText] = useState('');

    useEffect(() => {
        if (messageAddedSubscription.data) {
            dispatch(addMessage(messageAddedSubscription.data.messageAdded));
        }
    }, [messageAddedSubscription.data]);

    useEffect(() => {
        if (getMessagesQuery.data) {
            dispatch(setMessages(getMessagesQuery.data.getMessages));
        }
    }, [getMessagesQuery.data]);

    const onEnterPress = async (e: any) => {
        if (e.keyCode == 13 && e.shiftKey == false) {
            e.preventDefault();
            const response = await createUserMutation({
                variables: {createMessageInputType: {text: newMessageText}},
            });
            if (response.errors) {
                console.log(response.errors);
            } else {
                setNewMessageText('');
            }
        }
    };

    if (messagesLoading)
        return <Loading/>;

    return (
        <div className={s.wrapper}>
            <div className={s.messages}>
                {messages.map(message => (
                    <div key={message.id}
                         className={[s.message, message.userId === 21 ? s.myMessage : s.othersMessage].join(' ')}>{message.text}</div>
                ))}
            </div>
            <textarea
                className={s.messageTextarea}
                placeholder="Input message"
                onKeyDown={onEnterPress}
                onChange={e => setNewMessageText(e.target.value)}
                value={newMessageText}
            />
        </div>
    );
};
