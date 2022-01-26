import React, { FC, useEffect } from "react";
import { Route } from "react-router";
import { Routes } from "react-router-dom";
import { Users } from "./components/Users/Users";
import { useSubscription } from "@apollo/client";
import {
  USER_ADDED_SUBSCRIPTION,
  UserAddedData,
  UserAddedVars,
} from "./modules/users/users.subscriptions";
import { useDispatch } from "react-redux";
import { actions } from "./modules/users/users.reducer";

export const App = () => {
  const userAddedSubscription = useSubscription<UserAddedData, UserAddedVars>(
    USER_ADDED_SUBSCRIPTION
  );
  const dispatch = useDispatch();
  useEffect(() => {
    if (userAddedSubscription.data) {
      dispatch(actions.addUser(userAddedSubscription.data.userAdded));
    }
  }, [userAddedSubscription.data]);

  return (
    <div>
      <Routes>
        <Route path="*" element={<Users />} />
      </Routes>
    </div>
  );
};
