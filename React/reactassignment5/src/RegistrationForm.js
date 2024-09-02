import React, { useState, useEffect } from 'react';
import axios from 'axios';

const RegistrationForm = () => {
  const [formData, setFormData] = useState({
    firstName: '',
    lastName: '',
    email: '',
    password: '',
    address: '',
    mobileNumber: ''
  });

  const handleChange = (e) => {
    const { name, value } = e.target;
    setFormData({ ...formData, [name]: value });
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    axios.post('http://localhost:5000/users', formData)
      .then(response => {
        console.log('User registered:', response.data);
        setFormData({
          firstName: '',
          lastName: '',
          email: '',
          password: '',
          address: '',
          mobileNumber: ''
        });
      })
      .catch(error => console.error('There was an error!', error));
  };

  return (
    <form onSubmit={handleSubmit}>
      <label>
        First Name:
        <input type="text" name="firstName" value={formData.firstName} onChange={handleChange} />
      </label>
      <label>
        Last Name:
        <input type="text" name="lastName" value={formData.lastName} onChange={handleChange} />
      </label>
      <label>
        Email:
        <input type="email" name="email" value={formData.email} onChange={handleChange} />
      </label>
      <label>
        Password:
        <input type="password" name="password" value={formData.password} onChange={handleChange} />
      </label>
      <label>
        Address:
        <input type="text" name="address" value={formData.address} onChange={handleChange} />
      </label>
      <label>
        Mobile Number:
        <input type="text" name="mobileNumber" value={formData.mobileNumber} onChange={handleChange} />
      </label>
      <button type="submit">Register</button>
    </form>
  );
};

export default RegistrationForm;
