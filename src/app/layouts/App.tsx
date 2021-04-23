import { useEffect } from 'react';
import { observer } from 'mobx-react-lite';
import NavBar from '../../features/navbar/NavBar';
import { useStore } from '../../app/stores/rootStore';
import NavBarItems from '../../features/navbar/NavBarItems';

function App() {
  const { menuStore } = useStore();

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
      <NavBar />
      <NavBarItems />
      <header className="App-header">
        <h1 className="text-green-500 text-center space-y-2 sm:text-left">
          hello world
        </h1>
      </header>
    </div>
  );
}

export default observer(App);
