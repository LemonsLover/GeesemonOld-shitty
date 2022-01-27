import {gql} from '@apollo/client';
import {Auth} from './auth.types';

export type IsAuthData = { isAuth: Auth }
export type IsAuthVars = {}

export const IS_AUTH_QUERY = gql`
    query IsAuth {
        isAuth {
            user {
                id
                email
                role
                createdAt
                updatedAt
            }
            token
        }
    }
`;
