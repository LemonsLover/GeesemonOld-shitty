import {gql} from '@apollo/client';
import {Auth} from './auth.types';

export type LoginData = { login: Auth }

export type LoginVars = { loginAuthInputType: loginAuthInputType }
export type loginAuthInputType = {
    email: string,
    password: string,
}

export const LOGIN_MUTATION = gql`
    mutation login($loginAuthInputType: LoginAuthInputType!) {
        login(loginAuthInputType: $loginAuthInputType) {
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
