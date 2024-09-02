import React, { useState } from 'react';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import NumberFormClass from './components/NumberFormClass';
import NumberFormFunction from './components/NumberFormFunction';
import NumberFormUncontrolled from './components/NumberFormUncontrolled';
import RegistrationClass from './components/RegistrationClass';
import RegistrationFunction from './components/RegistrationFunction';
import Login from './components/Login';
import Welcome from './components/Welcome';

function App() {
  const [loginDetails, setLoginDetails] = useState(null);

  return (
    <Router>
      <Routes>
        <Route path="/" element={<NumberFormClass />} />
        <Route path="/function" element={<NumberFormFunction />} />
        <Route path="/uncontrolled" element={<NumberFormUncontrolled />} />
        <Route path="/registration-class" element={<RegistrationClass />} />
        <Route path="/registration-function" element={<RegistrationFunction />} />
        <Route path="/login" element={<Login onLogin={setLoginDetails} />} />
        <Route path="/welcome" element={<Welcome loginDetails={loginDetails} />} />
      </Routes>
    </Router>
  );
}

export default App;
