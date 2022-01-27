import {gql} from '@apollo/client';
import {Message} from './messages.types';

export type MessageAddedData = { messageAdded: Message }

export type MessageAddedVars = {}

export const MESSAGE_ADDED_SUBSCRIPTION = gql`
    subscription MessageAdded {
        messageAdded {
            id
            text
            chatId
            userId
            createdAt
            updatedAt
        }
    }
`;
