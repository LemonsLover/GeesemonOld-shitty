import {ApolloClient, ApolloLink, HttpLink, InMemoryCache, split} from '@apollo/client';
import {schema} from './schema';
import {WebSocketLink} from '@apollo/client/link/ws';
import {getMainDefinition} from '@apollo/client/utilities';

const httpLink = new HttpLink({
    uri: `./graphql`,
    headers: {
        authorization: localStorage.getItem('token') ? `Bearer ${localStorage.getItem('token')}` : '',
    },

});

const wsLink = new WebSocketLink({
    uri: `wss://${window.location.host}/graphql`,
    options: {
        reconnect: true,
        connectionParams: {
            authToken: localStorage.getItem('token') ? `Bearer ${localStorage.getItem('token')}` : '',
        },
    },
});

const splitLink = split(
    ({query}) => {
        const definition = getMainDefinition(query);
        return (
            definition.kind === 'OperationDefinition' &&
            definition.operation === 'subscription'
        );
    },
    wsLink,
    httpLink,
);

export const client = new ApolloClient({
    link: splitLink,
    cache: new InMemoryCache({addTypename: false}),
    defaultOptions: {
        watchQuery: {
            // fetchPolicy: 'network-only',
            errorPolicy: 'all',
            notifyOnNetworkStatusChange: true,
        },
        query: {
            // fetchPolicy: 'network-only',
            errorPolicy: 'all',
            notifyOnNetworkStatusChange: true,
        },
    },
    typeDefs: schema,
});
