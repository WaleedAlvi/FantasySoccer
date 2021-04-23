import { observer } from 'mobx-react-lite';
import { Link } from 'react-router-dom';
import { useStore } from '../../app/stores/rootStore';
import NavBarAccountButton from './NavBarAccountButton';
import NavBarAccountDropDown from './NavBarAccountDropDown';

const NavBar = () => {
  const { menuStore } = useStore();

  return (
    <nav
      className="flex justify-between items-center h-16 bg-white text-black relative shadow-sm font-mono"
      role="navigation"
    >
      <Link to="/" className="pl-8">
        Test Nav
      </Link>
      <div
        className="px-4 cursor-pointer md:hidden"
        onClick={menuStore.toggleMenu}
      >
        <svg
          className="w-6 h-6"
          fill="none"
          stroke="currentColor"
          viewBox="0 0 24 24"
          xmlns="http://www.w3.org/2000/svg"
        >
          <path
            strokeLinecap="round"
            strokeLinejoin="round"
            strokeWidth={2}
            d="M4 6h16M4 12h16M4 18h16"
          />
        </svg>
      </div>
      <div className="pr-8 md:block hidden">
        <Link className="p-4 hover:bg-gray-200 rounded-lg" to="/">
          Home
        </Link>
        <Link className="p-4 hover:bg-gray-200 rounded-lg" to="/menu">
          Menu
        </Link>
        <Link className="p-4 hover:bg-gray-200 rounded-lg" to="/about">
          About
        </Link>
        <Link className="p-4 hover:bg-gray-200 rounded-lg" to="/contact">
          Contact
        </Link>
      </div>
      <div className="pr-8">
        <NavBarAccountButton />
        {menuStore.isMenuDDLOpen ? <NavBarAccountDropDown /> : null}
      </div>
    </nav>
  );
};

export default observer(NavBar);
