import { observer } from 'mobx-react-lite';
import NavBarAccountDropDownLink from './NavBarAccountDropDownLink';
import { useStore } from '../../app/stores/rootStore';
import { Link, useHistory } from 'react-router-dom';

const NavBarAccountDropDown = () => {
  const { userStore, menuStore } = useStore();
  const history = useHistory();

  const handleLogOut = () => {
    try {
      menuStore.toggleMenuDDL();
      userStore.logout().then(() => {
        if (!userStore.IsLoggedIn) history.push('/login');
      });
    } catch {}
  };

  return (
    <div className="absolute right-0 w-full mt-2 origin-top-right rounded-md shadow-lg md:w-48">
      <div className="px-2 py-2 bg-white rounded-md shadow dark-mode:bg-gray-800">
        <NavBarAccountDropDownLink
          linkName={'Settings'}
          linkPath={'/settings'}
        />
        <NavBarAccountDropDownLink
          linkName={'Edit Account'}
          linkPath={'/editaccount'}
        />
        <a
          onClick={handleLogOut}
          className="block px-4 py-2 mt-2 text-sm font-semibold bg-transparent rounded-lg dark-mode:bg-transparent dark-mode:hover:bg-gray-600 dark-mode:focus:bg-gray-600 dark-mode:focus:text-white dark-mode:hover:text-white dark-mode:text-gray-200 md:mt-0 hover:text-gray-900 focus:text-gray-900 hover:bg-gray-200 focus:bg-gray-200 focus:outline-none focus:shadow-outline"
        >
          Logout
        </a>
      </div>
    </div>
  );
};

export default observer(NavBarAccountDropDown);
