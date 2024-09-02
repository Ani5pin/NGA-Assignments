import React, { useContext, useState } from 'react';
import { UserContext } from './UserContext';

const RegistrationComponent = () => {
  const { setUser } = useContext(UserContext);
  const [user, setUserState] = useState({
    name: '',
    address: '',
    email: '',
    phoneNumber: '',
    dept: ''
  });

  const handleChange = (e) => {
    const { name, value } = e.target;
    setUserState({ ...user, [name]: value });
  };

  const handleRegister = () => {
    setUser(user);
  };

  return (
    <div>
      <input name="name" placeholder="Name" onChange={handleChange} />
      <input name="address" placeholder="Address" onChange={handleChange} />
      <input name="email" placeholder="Email" onChange={handleChange} />
      <input name="phoneNumber" placeholder="Phone Number" onChange={handleChange} />
      <input name="dept" placeholder="Department" onChange={handleChange} />
      <button onClick={handleRegister}>Register</button>
    </div>
  );
};

export default RegistrationComponent;
