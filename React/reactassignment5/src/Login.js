import React, { useState } from 'react';
import axios from 'axios';

const Login = ({ onLogin }) => {
  const [credentials, setCredentials] = useState({
    email: '',
    password: ''
  });

  const handleChange = (e) => {
    const { name, value } = e.target;
    setCredentials({ ...credentials, [name]: value });
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    axios.get('http://localhost:5000/users')
      .then(response => {
        const user = response.data.find(user => user.email === credentials.email && user.password === credentials.password);
        if (user) {
          onLogin(user);
        } else {
          alert('Invalid credentials');
        }
      })
      .catch(error => console.error('There was an error!', error));
  };

  return (
    <form onSubmit={handleSubmit}>
      <label>
        Email:
        <input type="email" name="email" value={credentials.email} onChange={handleChange} />
      </label>
      <label>
        Password:
        <input type="password" name="password" value={credentials.password} onChange={handleChange} />
      </label>
      <button type="submit">Login</button>
    </form>
  );
};

export default Login;
