import {gql} from '@apollo/client';
import {Message} from './messages.types';

export type CreateMessageData = { createMessage: Message }

export type CreateMessageVars = { createMessageInputType: createMessageInputType }
export type createMessageInputType = {
    text: string,
}

export const CREATE_MESSAGE_MUTATION = gql`
    mutation CreateMessage($createMessageInputType: CreateMessageInputType!) {
        createMessage(createMessageInputType: $createMessageInputType) {
            id
            text
            chatId
            userId
            createdAt
            updatedAt
        }
    }
`;
