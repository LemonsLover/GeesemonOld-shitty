import {gql} from '@apollo/client';
import {Message} from './messages.types';
import {MESSAGE_FIELDS} from './messages.fragments';

export type CreateMessageData = { createMessage: Message }

export type CreateMessageVars = { createMessageInputType: createMessageInputType }
export type createMessageInputType = {
    text: string,
}

export const CREATE_MESSAGE_MUTATION = gql`
    ${MESSAGE_FIELDS}
    mutation CreateMessage($createMessageInputType: CreateMessageInputType!) {
        createMessage(createMessageInputType: $createMessageInputType) {
            ...MessageFields
        }
    }
`;
