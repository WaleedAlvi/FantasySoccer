import {createContext, useContext} from 'react';
import MenuStore from './menuStore';

interface Store {
    menuStore: MenuStore,
}

export const store: Store = {
    menuStore: new MenuStore(),
}

export const StoreContext = createContext(store);

export function useStore() {
    return useContext(StoreContext);
}