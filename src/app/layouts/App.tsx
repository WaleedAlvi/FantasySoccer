import { observer } from 'mobx-react-lite';
import React from 'react';
import NavBar from '../../features/navbar/NavBar';
import { BrowserRouter as Router, Switch, Route } from 'react-router-dom';
import SideBar from '../../features/sidebar/SideBar';

function App() {
  return (
    <div className="App">
      {/* <NavBar></NavBar> */}
      <Router>
        <SideBar />
        <Switch>
          <Route path="/" />
        </Switch>
      </Router>
      <header className="App-header">
        <h1>hello world</h1>
      </header>
    </div>
  );
}

export default observer(App);
