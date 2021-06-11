import { useEffect } from 'react';
import { observer } from 'mobx-react-lite';
import { useStore } from '../../app/stores/rootStore';
import Dashboard from '../../features/dashboard/dashboard';
import Login from '../../features/login/login';
import Signup from '../../features/login/signup';
import ForgotPassword from '../../features/login/forgotPassword';
import { BrowserRouter as Router, Switch, Route } from 'react-router-dom';
import PrivateRoute from '../shared/privateRoute';
function App() {
  const { menuStore, userStore } = useStore();

  useEffect(() => {
    const hideMenu = () => {
      if (window.innerWidth > 768 && menuStore.isMenuOpen) {
        menuStore.isMenuOpen = false;
      }
    };

    window.addEventListener('resize', hideMenu);

    return () => {
      window.removeEventListener('resize', hideMenu);
    };
  });

  return (
    <div className="App">
      <Router>
        <Switch>
          <PrivateRoute
            isAuth={userStore.IsLoggedIn}
            redirectPath="/login"
            exact
            path="/"
            component={Dashboard}
          />
          <Route path="/login" component={Login} />
          <Route path="/signup" component={Signup} />
          <Route path="/forgotpassword" component={ForgotPassword} />
        </Switch>
      </Router>
    </div>
  );
}

export default observer(App);
