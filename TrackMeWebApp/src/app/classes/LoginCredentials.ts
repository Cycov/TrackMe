export class LoginCredentials {
    constructor(public email?: string,
                public password?: string) { }
    public isEmpty() {
        return (this.email === '') || (this.password === '');
    }
}
