// src/Registration.js
import React, { useState, useEffect } from 'react';

const Registration = () => {
  const [formData, setFormData] = useState({
    firstName: '',
    lastName: '',
    email: '',
    password: '',
    address: '',
    mobileNumber: ''
  });
  const [users, setUsers] = useState([]);

  useEffect(() => {
    fetch('http://localhost:5000/users')
      .then(response => response.json())
      .then(data => setUsers(data));
  }, []);

  const handleChange = (e) => {
    setFormData({
      ...formData,
      [e.target.name]: e.target.value
    });
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    fetch('http://localhost:5000/users', {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json'
      },
      body: JSON.stringify(formData)
    })
    .then(response => response.json())
    .then(newUser => {
      setUsers([...users, newUser]);
      setFormData({
        firstName: '',
        lastName: '',
        email: '',
        password: '',
        address: '',
        mobileNumber: ''
      });
    });
  };

  const handleDelete = (id) => {
    fetch(`http://localhost:5000/users/${id}`, {
      method: 'DELETE'
    })
    .then(() => {
      setUsers(users.filter(user => user.id !== id));
    });
  };

  const handleEdit = (id) => {
    // Logic to handle edit will go here
  };

  const handleDetails = (id) => {
    // Logic to handle details will go here
  };

  return (
    <div>
      <form onSubmit={handleSubmit}>
        <input 
          type="text" 
          name="firstName" 
          value={formData.firstName} 
          onChange={handleChange} 
          placeholder="Enter First Name" 
          required 
        />
        <input 
          type="text" 
          name="lastName" 
          value={formData.lastName} 
          onChange={handleChange} 
          placeholder="Enter Last Name" 
          required 
        />
        <input 
          type="email" 
          name="email" 
          value={formData.email} 
          onChange={handleChange} 
          placeholder="Enter Email" 
          required 
        />
        <input 
          type="password" 
          name="password" 
          value={formData.password} 
          onChange={handleChange} 
          placeholder="Enter Password" 
          required 
        />
        <input 
          type="text" 
          name="address" 
          value={formData.address} 
          onChange={handleChange} 
          placeholder="Enter Address" 
          required 
        />
        <input 
          type="text" 
          name="mobileNumber" 
          value={formData.mobileNumber} 
          onChange={handleChange} 
          placeholder="Enter Mobile Number" 
          required 
        />
        <button type="submit">Register</button>
      </form>
      <table>
        <thead>
          <tr>
            <th>ID</th>
            <th>First Name</th>
            <th>Actions</th>
          </tr>
        </thead>
        <tbody>
          {users.map(user => (
            <tr key={user.id}>
              <td>{user.id}</td>
              <td>{user.firstName}</td>
              <td>
                <button onClick={() => handleDetails(user.id)}>Details</button>
                <button onClick={() => handleEdit(user.id)}>Edit</button>
                <button onClick={() => handleDelete(user.id)}>Delete</button>
              </td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
};

export default Registration;
