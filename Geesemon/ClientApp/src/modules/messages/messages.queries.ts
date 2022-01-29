import {gql} from '@apollo/client';
import {Message} from './messages.types';

export type GetMessagesData = { getMessages: Message[] }

export type GetMessagesVars = { getMessagesInputType: getMessagesInputType }
export type getMessagesInputType = {
    page: number,
    pageSize: number
}

export const GET_MESSAGES_QUERY = gql`
    query GetMessages($getMessagesInputType: GetMessagesInputType!) {
        getMessages(getMessagesInputType: $getMessagesInputType) {
            id
            text
            chatId
            userId
            createdAt
            updatedAt
        }
    }

`;
