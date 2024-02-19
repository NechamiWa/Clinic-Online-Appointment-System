export default class Client {
    name!: string
    id!: string
    email?: string
    phone?: string
    joinDate?: Date
    constructor(name: string, id: string, email: string, phone: string) {
        this.name = name;
        this.id = id;
        this.email = email;
        this.phone = phone;
        this.joinDate = new Date();
    }
}