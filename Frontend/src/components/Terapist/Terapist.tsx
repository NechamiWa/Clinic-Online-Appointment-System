import React, { FC, useRef, useState } from 'react';
import './Terapist.scss';
import apiService from '../../services/api.service';

interface TerapistProps { }

const Terapist: FC<TerapistProps> = () => {
  const [therapistMeetings, setTherapistMeetings] = useState<any>([])
  const idRef = useRef<HTMLInputElement>(null);

  const getMeetings = () => {
    let terapistId = idRef.current?.value;
    apiService.getTerapistMeetings(terapistId ? terapistId : "").then(res => {
      setTherapistMeetings(res.data);
    }).catch(err => { throw new Error("getTerapistMeetings failed") })
  }
  const getTherapist = () => {
    apiService.getTherapistList().then((res: any) => {
      console.log(res.data)
    }).catch(err => { throw new Error("getTherapist failed") }).then(getMeetings)
  }

  return <div className="Terapist">
    <h2>Therapist</h2>
    <br></br>
    {idRef.current?.value == null ? <input type="text" onBlur={getTherapist} ref={idRef} placeholder='Insert ID' /> : ""}
    {therapistMeetings.length > 0 ? <table className="table table-dark table-hover">
      <thead>
        <tr>
          <th scope="col">Client Name</th>
          <th scope="col">Therapist Name</th>
          <th scope="col">Date</th>
        </tr>
      </thead>
      <tbody>
        {therapistMeetings.map((meeting: any, index: number) => {
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

export default Terapist;
