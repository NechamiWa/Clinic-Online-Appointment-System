import './ClientList.scss'
import apiService from '../../services/api.service'
import { error } from 'console';
import { useState, useRef, useEffect } from 'react';
import Client from '../../models/Client';
import { Exception } from 'sass';
interface ClientListProps { }

const ClientList = () => {
    const [clientsList, setClientsList] = useState<any>([{}]);

    const nameRef = useRef<HTMLInputElement>(null);
    let idRef = useRef<HTMLInputElement>(null);
    let phoneRef = useRef<HTMLInputElement>(null);
    let emailRef = useRef<HTMLInputElement>(null);

    useEffect(() => {
        getClients();
    }, [])

    const getClients = () => {
        apiService.GetClientList().then((res: any) => {
            setClientsList(res.data);
            console.log(res.data)
        })
    }

    const createClient = () => {
        const c = { id: idRef.current?.value, fullName: nameRef.current?.value, phone: phoneRef.current?.value, email: emailRef.current?.value, joinDate: "2024-02-06T13:27:38.3994423+02:00" }
        apiService.CreateClient(c).catch((err: any) => {
            if (err) { throw new Error("we don't success to save the user") }
        })
        clientsList.push(c)
        setClientsList([...clientsList]);
    }

    return <div>
        <div> All Clients: <br></br>{clientsList.map((c: any, index: number) => (<div> Name: {c.fullName} | Id: {c.id} </div>))}</div>
        <form>
            <input ref={nameRef} placeholder='Name'></input>
            <input ref={idRef} placeholder='Id'></input>
            <input ref={emailRef} placeholder='Email'></input>
            <input ref={phoneRef} placeholder='Phone'></input>
            <button type='submit' onClick={createClient}>submit</button>
        </form>
    </div >
}
export default ClientList;