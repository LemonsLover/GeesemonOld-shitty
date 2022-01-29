import {gql} from '@apollo/client';

export const MESSAGE_FIELDS = gql`
    fragment MessageFields on Message {
        id
        text
        chatId
        userId
        createdAt
        updatedAt
    }
`;
