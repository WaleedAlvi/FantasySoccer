import {createContext, useContext} from 'react';
import MenuStore from './menuStore';
import UserStore from './userStore'

interface Store {
    menuStore: MenuStore,
    userStore: UserStore,
}

export const store: Store = {
    menuStore: new MenuStore(),
    userStore: new UserStore(),
}

export const StoreContext = createContext(store);

export function useStore() {
    return useContext(StoreContext);
}