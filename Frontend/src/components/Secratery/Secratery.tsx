import React, { FC, useState, useEffect, useRef } from 'react';
import './Secratery.scss';
import apiService from '../../services/api.service';

interface SecrateryProps { }

const Secratery: FC<SecrateryProps> = () => {
  const [clientsList, setClientsList] = useState<any>([{}]);
  const [meetingsList, setMeetingsList] = useState<any>([{}]);
  const [choice, setChoice] = useState<string>('')

  const nameRef = useRef<HTMLInputElement>(null);
  const idRef = useRef<HTMLInputElement>(null);
  const phoneRef = useRef<HTMLInputElement>(null);
  const emailRef = useRef<HTMLInputElement>(null);

  useEffect(() => {
  }, [])

  const getClients = () => {
    apiService.GetClientList().then((res: any) => {
      setClientsList(res.data);
      console.log(res.data)
    })
  }
  const getMeetings = () => {
    apiService.getMeetings().then((res: any) => {
      setMeetingsList(res.data);
      console.log(res.data)
    })
  }


  const createClient = () => {
    debugger
    const c = { Id: idRef.current?.value, Name: nameRef.current?.value, PhoneNumber: phoneRef.current?.value, Email: emailRef.current?.value, JoinDate: "2024-02-06T13:27:38.3994423+02:00" }
    apiService.CreateClient(c).then(res => {
      clientsList.push(c)
      setClientsList([...clientsList]);
    })
      .catch((err: any) => {
        alert("we don't success to save the user")
      })
  }

  return <div className='Secratery'>
    <div className="container-fluid">
      <div className='row'>
        <div className="col-md-6">
          <button  onClick={() => { getClients(); setChoice('clients') }}>See all Clients</button>
          <button  onClick={() => { getMeetings(); setChoice('meetings') }}>See all Meetings</button>

          {choice == 'clients' ?
            <table className="table table-dark table-hover">
              <thead>
                <tr>
                  <th scope="col">Id</th>
                  <th scope="col">Name</th>
                  <th scope="col">JoinDate</th>
                  <th scope="col">Phone</th>
                </tr>
              </thead>
              <tbody>
                {clientsList.map((c: any, index: number) => {
                  return <tr>
                    <th scope="row"> {c.id}</th>
                    <td>{c.name}</td>
                    <td>{c.joinDate}</td>
                    <td> {c.phoneNumber}</td>
                  </tr>
                })}
              </tbody>
            </table>
            : choice == 'meetings' ?
              <table className="table table-dark table-hover">
                <thead>
                  <tr>
                    <th scope="col">ClientId</th>
                    <th scope="col">TherapistId</th>
                    <th scope="col">Date</th>
                  </tr>
                </thead>
                <tbody>
                  {meetingsList.map((m: any, index: number) => {
                    return <tr>
                      <th scope="row"> {m.clientId}</th>
                      <td>{m.therapistId}</td>
                      <td>{m.date}</td>
                    </tr>
                  })}
                </tbody>
              </table>
              : ''}
        </div>

        <div className='col-md-6 mt6 body'>

          <div className="grid align__item">

            <div className="register">

              <svg xmlns="http://www.w3.org/2000/svg" className="site__logo" width="56" height="84" viewBox="77.7 214.9 274.7 412"><defs><linearGradient id="a" x1="0%" y1="0%" y2="0%"><stop offset="0%" stop-color="#8ceabb" /><stop offset="100%" stop-color="#378f7b" /></linearGradient></defs><path fill="url(#a)" d="M215 214.9c-83.6 123.5-137.3 200.8-137.3 275.9 0 75.2 61.4 136.1 137.3 136.1s137.3-60.9 137.3-136.1c0-75.1-53.7-152.4-137.3-275.9z" /></svg>

              <h2>Create Client</h2>

              <form className="form">

                <div className="form__field">
                  <input ref={nameRef} placeholder=' Insert Name' className='form-control'></input>
                </div>

                <div className='form__field'>
                  <input ref={idRef} placeholder=' Insert Id' className='form-control'></input>
                </div>

                <div className='form__field'>
                  <input ref={emailRef} placeholder=' Insert Email' className='form-control'></input>
                </div>

                <div className='form__field'>
                  <input ref={phoneRef} placeholder=' Insert Phone' className='form-control'></input>
                </div>
                <div className="form__field">
                  <button type='submit' onClick={createClient}>Create</button>
                </div>
              </form>
            </div>

          </div>
        </div>
      </div>
    </div>
  </div>
}
export default Secratery;
