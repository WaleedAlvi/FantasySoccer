import { makeAutoObservable } from 'mobx';

export default class MenuStore {
    isMenuDDLOpen: boolean = false;
    isMenuOpen: boolean = false;

    constructor() {
        makeAutoObservable(this);
    }

    toggleMenuDDL = () => {
        this.isMenuDDLOpen = !this.isMenuDDLOpen;
        console.log(this.isMenuOpen);
    }

    toggleMenu = () => {
        this.isMenuOpen = !this.isMenuOpen;
        console.log(this.isMenuOpen);
    }
}