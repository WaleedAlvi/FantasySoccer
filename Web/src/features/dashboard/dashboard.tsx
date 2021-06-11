import React from 'react';
import { observer } from 'mobx-react-lite';
import NavBar from '../navbar/NavBar';
import NavBarItems from '../navbar/NavBarItems';
import Modal from '../../app/shared/hooks/modal';

const Dashboard = () => {
  return (
    <div>
      <NavBar />
      <NavBarItems />
      <h1>This is the DashBoard</h1>
    </div>
  );
};

export default observer(Dashboard);
