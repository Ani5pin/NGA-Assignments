// src/Login.js
import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom';

const Login = () => {
  const [credentials, setCredentials] = useState({
    email: '',
    password: ''
  });
  const [error, setError] = useState('');
  const navigate = useNavigate();

  const handleChange = (e) => {
    setCredentials({
      ...credentials,
      [e.target.name]: e.target.value
    });
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    fetch('http://localhost:5000/users')
      .then(response => response.json())
      .then(users => {
        const user = users.find(u => u.email === credentials.email && u.password === credentials.password);
        if (user) {
          navigate(`/welcome?name=${user.firstName}`);
        } else {
          setError('Invalid credentials');
        }
      });
  };

  return (
    <div>
      <form onSubmit={handleSubmit}>
        <input 
          type="email" 
          name="email" 
          value={credentials.email} 
          onChange={handleChange} 
          placeholder="Enter Email" 
          required 
        />
        <input 
          type="password" 
          name="password" 
          value={credentials.password} 
          onChange={handleChange} 
          placeholder="Enter Password" 
          required 
        />
        <button type="submit">Login</button>
      </form>
      {error && <p>{error}</p>}
    </div>
  );
};

export default Login;
