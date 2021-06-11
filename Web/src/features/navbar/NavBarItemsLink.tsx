import React from 'react';
import { observer } from 'mobx-react-lite';
import { Link } from 'react-router-dom';
import { useStore } from '../../app/stores/rootStore';

interface IProp {
  linkName: string;
  linkPath: string;
}

const NavBarItemsLink: React.FC<IProp> = ({ linkName, linkPath }) => {
  const { menuStore } = useStore();

  return (
    <Link to={linkPath}>
      <a className="block px-4 py-2 mt-2 text-sm font-semibold bg-transparent rounded-lg dark-mode:bg-transparent dark-mode:hover:bg-gray-600 dark-mode:focus:bg-gray-600 dark-mode:focus:text-white dark-mode:hover:text-white dark-mode:text-gray-200 md:mt-0 hover:text-gray-900 focus:text-gray-900 hover:bg-gray-200 focus:bg-gray-200 focus:outline-none focus:shadow-outline">
        {linkName}
      </a>
    </Link>
  );
};

export default observer(NavBarItemsLink);