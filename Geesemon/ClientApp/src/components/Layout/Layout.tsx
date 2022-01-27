import React from 'react';
import {Navigate, Route, Routes} from 'react-router-dom';
import {Messages} from '../Messages/Messages';
import {Error} from '../Error/Error';
import {useAppDispatch, useAppSelector} from '../../store/store';
import {setAuthData, setIsAuth} from '../../modules/auth/auth.slice';

export const Layout = () => {
    const isAuth = useAppSelector(state => state.auth.isAuth);
    const dispatch = useAppDispatch();

    if (!isAuth)
        return <Navigate to={'/auth/login'}/>;

    const logoutHandler = () => {
        localStorage.removeItem('token');
        dispatch(setIsAuth(false))
        dispatch(setAuthData(null))
    };

    return (
        <>
            <button onClick={logoutHandler}>Logout</button>
            <Routes>
                <Route path={'/'} element={<Messages/>}/>
                <Route path={'*'} element={<Error/>}/>
            </Routes>
        </>
    );
};
