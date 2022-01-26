import React, {useEffect} from 'react';
import {useDispatch, useSelector} from 'react-redux';
import {s_getUsers, s_getUsersLoading} from '../../modules/users/users.selectors';
import {loadUsers} from '../../modules/users/users.reducer';

export const Users = () => {
    const users = useSelector(s_getUsers);
    const usersLoading = useSelector(s_getUsersLoading);
    const dispatch = useDispatch();

    useEffect(() => {
        dispatch(loadUsers());
    }, []);

    if (usersLoading)
        return <div>loading...</div>;

    return (
        <div>
            {users.map(user => (
                <div key={user.id}>{user.email}</div>
            ))}
        </div>
    );
};
