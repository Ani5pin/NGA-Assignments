import React, { useState } from 'react';

function RegistrationFunction() {
  const [form, setForm] = useState({
    firstName: '',
    lastName: '',
    email: '',
    password: '',
    address: '',
    mobile: ''
  });

  const handleChange = (e) => {
    const { name, value } = e.target;
    setForm({ ...form, [name]: value });
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    console.log(JSON.stringify(form, null, 2));
  };

  return (
    <form onSubmit={handleSubmit}>
      <div>
        <label>Enter First Name:</label>
        <input type="text" name="firstName" value={form.firstName} onChange={handleChange} />
      </div>
      <div>
        <label>Enter Last Name:</label>
        <input type="text" name="lastName" value={form.lastName} onChange={handleChange} />
      </div>
      <div>
        <label>Enter Email:</label>
        <input type="email" name="email" value={form.email} onChange={handleChange} />
      </div>
      <div>
        <label>Enter Password:</label>
        <input type="password" name="password" value={form.password} onChange={handleChange} />
      </div>
      <div>
        <label>Enter Address:</label>
        <input type="text" name="address" value={form.address} onChange={handleChange} />
      </div>
      <div>
        <label>Enter Mobile Number:</label>
        <input type="text" name="mobile" value={form.mobile} onChange={handleChange} />
      </div>
      <button type="submit">Register</button>
    </form>
  );
}

export default RegistrationFunction;
