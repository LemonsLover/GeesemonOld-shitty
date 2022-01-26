import {client} from '../../gql/client';
import {GET_USERS_QUERY} from './users.queries';
import {User} from '../../types/auth';

export const usersAPI = {
    async getUsers(): Promise<User[]> {
        const response = await client.query({
            query: GET_USERS_QUERY,
        });
        return response.data.getUsers;
    },
};
