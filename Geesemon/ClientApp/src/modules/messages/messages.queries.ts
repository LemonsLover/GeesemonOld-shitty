import {gql} from '@apollo/client';
import {Message} from './messages.types';

export type GetMessagesData = { getMessages: Message[] }
export type GetMessagesVars = {}

export const GET_MESSAGES_QUERY = gql`
    query GetMessages {
        getMessages {
            id
            text
            chatId
            userId
            createdAt
            updatedAt
        }
    }
`;
