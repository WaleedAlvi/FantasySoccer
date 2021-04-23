import { observer } from 'mobx-react-lite';
import { useStore } from '../../app/stores/rootStore';
import NavBarItemsLink from './NavBarItemsLink';

const NavBarItems = () => {
  const { menuStore } = useStore();
  return (
    <div
      className={
        menuStore.isMenuOpen
          ? 'grid grid-rows-4 text-center items-center bg-gray-100'
          : 'hidden'
      }
      onClick={menuStore.toggleMenu}
    >
      <NavBarItemsLink linkName={'Home'} linkPath={'/'} />
      <NavBarItemsLink linkName={'Menu'} linkPath={'/menu'} />
      <NavBarItemsLink linkName={'About'} linkPath={'/about'} />
      <NavBarItemsLink linkName={'Contact'} linkPath={'/contact'} />
    </div>
  );
};

export default observer(NavBarItems);
