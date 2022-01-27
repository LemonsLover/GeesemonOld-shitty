import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react'
import {GET_MESSAGES_QUERY, GetMessagesData, GetMessagesVars} from './messages.queries';

export const messagesApi = createApi({
    reducerPath: 'messagesApi',
    baseQuery: fetchBaseQuery({ baseUrl: './graphql' }),
    endpoints: (builder) => ({
        getMessages: builder.query<GetMessagesData, GetMessagesVars>({
            query: (variables) => ({url: '', document: GET_MESSAGES_QUERY, variables}),
        }),
    }),
})

export const { useGetMessagesQuery } = messagesApi
