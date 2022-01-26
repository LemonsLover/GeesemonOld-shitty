import {User} from '../../types/auth';
import {gql} from '@apollo/client';

export type UserAddedData = { userAdded: User }

export type UserAddedVars = {}
// export type getUsersInput = {}

export const USER_ADDED_SUBSCRIPTION = gql`
    subscription UserAdded {
        userAdded {
            id
            email
        }
    }
`;
