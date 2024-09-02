import React from 'react';
import { useLocation } from 'react-router-dom';

function Welcome() {
  const location = useLocation();
  const { email, password } = location.state || { email: '', password: '' };

  return (
    <div>
      <h2>Welcome</h2>
      <p>Email: {email}</p>
      <p>Password: {password}</p>
    </div>
  );
}

export default Welcome;
