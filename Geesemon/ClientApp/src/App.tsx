import React, {useEffect, useState} from 'react';
import {Route} from 'react-router';
import {Routes} from 'react-router-dom';
import {Error} from './components/Error/Error';
import {Login} from './components/Login/Login';
import {Layout} from './components/Layout/Layout';
import {useQuery} from '@apollo/client';
import {IS_AUTH_QUERY, IsAuthData, IsAuthVars} from './modules/auth/auth.queries';
import {Loading} from './components/Loading/Loading';
import {useAppDispatch} from './store/store';
import {authActions} from './modules/auth/auth.slice';

export const App = () => {
    const isAuthQuery = useQuery<IsAuthData, IsAuthVars>(IS_AUTH_QUERY);
    const dispatch = useAppDispatch();
    const [initialized, setInitialized] = useState(false);

    useEffect(() => {
        if (isAuthQuery.data) {
            dispatch(authActions.setAuth({isAuth: true, authData: isAuthQuery.data.isAuth}));
            setInitialized(true);
        }
        if (isAuthQuery.error) {
            setInitialized(true);
        }
    }, [isAuthQuery]);

    if (isAuthQuery.loading || !initialized)
        return <Loading/>;

    return (
        <div>
            <Routes>
                <Route path="/*" element={<Layout/>}/>
                <Route path="/auth/login" element={<Login/>}/>
                <Route path="*" element={<Error/>}/>
            </Routes>
        </div>
    );
};
