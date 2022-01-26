import {gql} from '@apollo/client';
import {User} from '../../types/auth';

export type GetUsersData = { getUsers: User[] }
// export type getUsers = { users: User[], total: number }

export type GetUsersVars = {}
// export type getUsersInput = {}

export const GET_USERS_QUERY = gql`
    query GetUsers {
        getUsers {
            id
            email
            createdAt
            updatedAt
        }
    }
`;
