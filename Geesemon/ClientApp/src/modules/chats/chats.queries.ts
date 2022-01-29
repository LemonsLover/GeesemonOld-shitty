import {gql} from '@apollo/client';
import {Chat} from './chats.types';
import {CHAT_FIELDS} from './chats.fragments';

export type GetMyChatsData = { getMyChats: Chat[] }
export type GetMyChatsVars = {}

export const GET_MY_CHATS_QUERY = gql`
    ${CHAT_FIELDS}
    query GetMyChats {
        getMyChats {
            ...ChatFields
        }
    }
`;
