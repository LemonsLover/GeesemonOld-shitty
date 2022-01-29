import React from 'react';
import {Navigate} from 'react-router-dom';
import {Messages} from '../Messages/Messages';
import {useAppDispatch, useAppSelector} from '../../store/store';
import {Chats} from '../Chats/Chats';
import s from './Layout.module.css';
import {authActions} from '../../modules/auth/auth.slice';
import {client} from '../../gql/client';

export const Layout = () => {
    const isAuth = useAppSelector(state => state.auth.isAuth);
    const dispatch = useAppDispatch();

    const logoutHandler = async () => {
        localStorage.removeItem('token');
        dispatch(authActions.setAuth({isAuth: false, authData: null}));
    };

    if (!isAuth)
        return <Navigate to={'/auth/login'}/>;

    return (

        <div className={s.wrapper}>
            <button onClick={logoutHandler}>Logout</button>
            <Chats/>
            <Messages/>
        </div>
    );
};
