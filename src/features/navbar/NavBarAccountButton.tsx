import { observer } from 'mobx-react-lite';
import { useStore } from '../../app/stores/rootStore';

const NavBarAccountButton = () => {
  const { menuStore } = useStore();

  return (
    <button
      onClick={menuStore.toggleMenuDDL}
      className="rounded-full bg-white p-3 focus:outline-none border-black-800 border-2"
    >
      <span>WAL</span>
      <svg
        fill="currentColor"
        className="inline w-4 h-4 mt-1 ml-1 transition-transform duration-200 transform md:-mt-1"
      >
        <path
          fill-rule="evenodd"
          d={
            menuStore.isMenuDDLOpen
              ? 'M5.293 7.293a1 1 0 011.414 0L10 10.586l3.293-3.293a1 1 0 111.414 1.414l-4 4a1 1 0 01-1.414 0l-4-4a1 1 0 010-1.414z'
              : 'M14.707 12.707a1 1 0 01-1.414 0L10 9.414l-3.293 3.293a1 1 0 01-1.414-1.414l4-4a1 1 0 011.414 0l4 4a1 1 0 010 1.414z'
          }
          clip-rule="evenodd"
        ></path>
      </svg>
    </button>
  );
};

export default observer(NavBarAccountButton);
