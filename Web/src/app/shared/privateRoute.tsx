import React from 'react';
import { Redirect, Route, RouteProps } from 'react-router';

export interface IPrivateRouteProps extends RouteProps {
  isAuth: boolean; // is authenticate route
  redirectPath: string; // redirect path if don't authenticate route
  path: string;
  component: any;
}

const PrivateRoute: React.FC<IPrivateRouteProps> = ({
  isAuth,
  redirectPath,
  path,
  component,
}) => {
  return isAuth ? (
    <Route exact path={path} component={component} render={undefined} />
  ) : (
    <Redirect to={{ pathname: redirectPath }} />
  );
};

export default PrivateRoute;
