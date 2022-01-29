import React, {useEffect, useState} from 'react';
import {useAppSelector} from '../../store/store';
import {useMutation, useQuery} from '@apollo/client';
import {GET_MESSAGES_QUERY, GetMessagesData, GetMessagesVars} from '../../modules/messages/messages.queries';
import {MESSAGE_ADDED_SUBSCRIPTION} from '../../modules/messages/messages.subscriptions';
import s from './Messages.module.css';
import {CREATE_MESSAGE_MUTATION, CreateMessageData, CreateMessageVars} from '../../modules/messages/messages.mutations';

export const Messages = () => {
    const [page, setPage] = useState(1);
    const [pageSize, setPageSize] = useState(30);
    const getMessagesQuery = useQuery<GetMessagesData, GetMessagesVars>(GET_MESSAGES_QUERY, {
        variables: {
            getMessagesInputType: {
                page: page,
                pageSize: pageSize,
            },
        },
    });
    const [createUserMutation, createUserMutationOptions] = useMutation<CreateMessageData, CreateMessageVars>(CREATE_MESSAGE_MUTATION);
    const authData = useAppSelector(state => state.auth.authData);
    const [newMessageText, setNewMessageText] = useState('');

    useEffect(() => {
        getMessagesQuery.subscribeToMore({
            document: MESSAGE_ADDED_SUBSCRIPTION,
            updateQuery: (prev, {subscriptionData}) => {
                if (!subscriptionData.data)
                    return prev;
                // @ts-ignore
                const newFeedItem = subscriptionData.data.messageAdded;
                const result = {...prev, getMessages: [...prev.getMessages, newFeedItem]};
                console.log(result);
                return result;
            },
        });
    }, []);

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

    console.log(getMessagesQuery.data?.getMessages);

    return (
        <div className={s.wrapper}>
            <div className={s.messages}>
                {getMessagesQuery.data?.getMessages.map(message => (
                    <div key={message.id}
                         className={[s.message, message?.userId?.toString() === authData?.user.id ? s.myMessage : s.othersMessage].join(' ')}
                    >{message.text}</div>
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
