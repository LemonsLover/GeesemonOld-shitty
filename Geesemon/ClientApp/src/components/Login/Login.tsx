import React, {FormEvent, useState} from 'react';
import {useMutation} from '@apollo/client';
import {LOGIN_MUTATION, LoginData, LoginVars} from '../../modules/auth/auth.mutations';
import {useAppDispatch} from '../../store/store';
import {useNavigate} from 'react-router-dom';
import {authActions} from '../../modules/auth/auth.slice';

export const Login = () => {
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');
    const [loginMutation, loginMutationOptions] = useMutation<LoginData, LoginVars>(LOGIN_MUTATION);
    const dispatch = useAppDispatch();
    const navigate = useNavigate();

    const loginHandler = async (e: FormEvent<HTMLFormElement>) => {
        e.preventDefault();
        const response = await loginMutation({
            variables: {
                loginAuthInputType: {
                    email: email,
                    password: password,
                },
            },
        });
        if (response.errors) {
            console.log(response.errors);
        } else {
            dispatch(authActions.setAuth({isAuth: true, authData: response.data?.login}));
            navigate('/');
        }
    };

    return (
        <form onSubmit={loginHandler}>
            <div>
                <input type="text" placeholder={'Email'} value={email} onChange={e => setEmail(e.target.value)}/>
            </div>
            <div>
                <input type="Password" placeholder={'Password'} value={password}
                       onChange={e => setPassword(e.target.value)}/>
            </div>
            <div>
                <button>Login</button>
            </div>
        </form>
    );
};
