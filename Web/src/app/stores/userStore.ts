import { makeAutoObservable } from 'mobx';
import { IUser } from '../models/user';
import { auth } from '../shared/firebase';

export default class UserStore {
    user: IUser | null = null;
    errorExists: boolean = false;
    errorMessage: string = '';
    

    constructor() {
        makeAutoObservable(this);
    }

    get IsLoggedIn() {
        return !!this.user;
    }

    login = async (email: string, password: string) => {

        try {
            await auth.signInWithEmailAndPassword(email, password);
            this.errorExists = false;
            this.errorMessage = '';
            this.setUser();
        } catch (error) {
            this.errorExists = true;
            this.errorMessage = error.message;
        }
    }

    logout = async () => {
        try {
            await auth.signOut();
            this.user = null;
        } catch(error) {
            
        }

    }

    signup = async (email: string, password: string, confirmPassword:string) => {
        if (password === confirmPassword) {
            this.errorExists = false;
            this.errorMessage = '';
            try {
                await auth.createUserWithEmailAndPassword(email, password);
                this.setUser();
            } catch(error) {
                this.errorExists = true;
                this.errorMessage = error.message;
            }
        } else {
            this.errorExists = true;
            this.errorMessage = 'Passwords do not match';
        }
    }

    setUser = async () => {
        await auth.onAuthStateChanged(user => {
            this.errorExists = false;
            this.errorMessage = '';
            this.user = {
                name: '',
                email: user?.email,
                userToken: user?.uid
            }
        })
    }

    resertPassword = async (email: string) => {
        this.errorExists = false;
        this.errorMessage = '';
        try {
            await auth.sendPasswordResetEmail(email);
        } catch(error) {
            this.errorExists = true;
            this.errorMessage = error.message;
        }
    }
}