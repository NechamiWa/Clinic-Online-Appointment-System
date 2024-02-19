import axios from "axios"
import Client from "../models/Client";
export default new class ApiService {
    BASE_URL = "https://localhost:7127";

    //ClientService
    GetClientList() {
        return axios.get(`${this.BASE_URL}/Client/GetClients`);
    }

    CreateClient(client: any) {
        debugger
        return axios.post(`${this.BASE_URL}/Client/CreateClient`, client)
    }

    getClientMeetings(id: string,) {
        return axios.get(`${this.BASE_URL}/Client/GetMeetings?id=${id}`)
    }

    //TherapistService
    getTerapistMeetings(id: string) {
        return axios.get(`${this.BASE_URL}/Therapist/GetMeetings?id=${id}`)
    }

    getTherapistList() {
        return axios.get(`${this.BASE_URL}/Therapist/GetTherapist`)
    }

    //MeetingService
    getMeetings(){
        return axios.get(`${this.BASE_URL}/Meeting/GetMeetingsOnSecrateryFormat`)
    }

}
