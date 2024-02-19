import React, { FC, useEffect, useState } from 'react';
import './LogIn.scss';
import apiService from '../../services/api.service';
import { useNavigate } from 'react-router-dom';

interface LogInProps { }

const LogIn: FC<LogInProps> = () => {

  const navigate = useNavigate();
  // useEffect(() => {
  //   console.log("useEffect")
  //   // getClients();
  // }, []);


  // const getClients = () => {
  //   apiService.GetClientList().then((res: any) => {
  //     console.log(res.data);
  //   }).catch(err => { throw new Error("getClients failed") })
  // }
  // const getTherapist = () => {
  //   apiService.getTherapistList().then((res: any) => {
  //     console.log(res.data)
  //   }).catch(err => { throw new Error("getTherapist failed") })
  // }
  return <div className="LogIn">
    <h1>Log In</h1>
    <button id='loginBtn' onClick={() => { navigate('client') }}>I am Client</button>
    <button id='loginBtn' onClick={() => { navigate('therapist') }}>I am Terapist</button>
    <button id='loginBtn' onClick={() => { navigate('secretary') }}>I am Secratery</button>
  </div>
}

export default LogIn;
