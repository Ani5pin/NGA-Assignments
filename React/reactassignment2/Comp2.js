import React, { useContext } from 'react';
import { ColorContext } from './ColorContext';
import { UserContext } from './UserContext';

const Comp2 = () => {
  const { color } = useContext(ColorContext);
  const { user } = useContext(UserContext);

  return (
    <div style={{ backgroundColor: color }}>
      {user ? (
        <div>
          <h2>User Details:</h2>
          <p>Name: {user.name}</p>
          <p>Address: {user.address}</p>
          <p>Email: {user.email}</p>
          <p>Phone Number: {user.phoneNumber}</p>
          <p>Department: {user.dept}</p>
        </div>
      ) : (
        <p>Please provide user details.</p>
      )}
    </div>
  );
};

export default Comp2;
