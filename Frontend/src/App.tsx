import React from 'react';
import '../node_modules/bootstrap/';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import LogIn from './components/LogIn/LogIn';
import Secratary from './components/Secratery/Secratery'; // Fix the typo
import Client from './components/Client/Client';
import Terapist from './components/Terapist/Terapist';
import { useState } from "react";
import './App.scss';


function App() {
  return (
    <div className='App'>
      <Router>
        <Routes>
          <Route path="" element={<LogIn />} />
          <Route path="secretary" element={<Secratary />} />
          <Route path="client" element={<Client />} />
          <Route path="therapist" element={<Terapist />} />
        </Routes>
      </Router>
    </div>
  );
}

export default App;