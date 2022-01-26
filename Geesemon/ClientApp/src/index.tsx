import React from 'react';
import ReactDOM from 'react-dom';
import {Provider} from 'react-redux';
import {App} from './App';
import registerServiceWorker from './registerServiceWorker';
import store from './store/redux-store';
import {client} from './gql/client';
import {BrowserRouter} from 'react-router-dom';
import {ApolloProvider} from '@apollo/client';

ReactDOM.render(
    <React.StrictMode>
        <Provider store={store}>
            <BrowserRouter>
                <ApolloProvider client={client}>
                    <App/>
                </ApolloProvider>
            </BrowserRouter>
        </Provider>
    </React.StrictMode>,
    document.getElementById('root'));

registerServiceWorker();
