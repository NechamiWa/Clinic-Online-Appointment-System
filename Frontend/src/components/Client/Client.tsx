import React, { FC, useEffect, useRef, useState } from 'react';
import './Client.scss';
import apiService from '../../services/api.service';

interface ClientProps { }

const Client: FC<ClientProps> = () => {

  const [clientMeetings, setClientMeetings] = useState<any>([])
  let idRef = useRef<HTMLInputElement>(null);


  useEffect(() => {
  }, [])



  const getTherapist = () => {
    apiService.getTherapistList().then((res: any) => {
      console.log(res.data)
    }).catch(err => { throw new Error("getTherapist failed") }).then(getMeetings)
  }
  const getMeetings = () => {
    let clientId = idRef.current?.value;
    apiService.getClientMeetings(clientId ? clientId : "").then(res => {
      console.log(res.data)
      setClientMeetings(res.data);
      console.log(clientMeetings)
    }).catch(err => { throw new Error("getClientMeetings failed") })
  }


  return <div className="Client">
    <h2>Client</h2>
    <br></br>
    {idRef.current?.value == null ? <input type="text" onBlur={getTherapist} ref={idRef} placeholder='Insert ID' /> : ""}
    {clientMeetings.length > 0 ? <table className="table table-dark table-hover">
      <thead>
        <tr>
          <th scope="col">clientName</th>
          <th scope="col">therapistName</th>
          <th scope="col">Date</th>
        </tr>
      </thead>
      <tbody>
        {clientMeetings.map((meeting: any, index: number) => {
          return <tr>
            <td>{meeting.clientName}</td>
            <td>{meeting.therapistName}</td>
            <td>{meeting.date}</td>
          </tr>
        })}
      </tbody>
    </table> : ''}
  </div>
}

export default Client;
