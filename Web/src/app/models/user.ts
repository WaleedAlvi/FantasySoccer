export interface IUser {
    name?: string,
    dateOfBirth?: Date,
    email: string | null | undefined,
    //password: string,
    userToken: string | null | undefined,
}