import {gql} from '@apollo/client';

export const CHAT_FIELDS = gql`
    fragment ChatFields on Chat {
        id
        name
        type
        createAt
        updatedAt
    }
`;
