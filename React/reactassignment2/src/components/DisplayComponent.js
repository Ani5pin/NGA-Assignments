import React from 'react';

const DisplayComponent = ({ user }) => {
  return (
    <div>
      <h2>User Details:</h2>
      {user ? (
        <ul>
          <li>Name: {user.name}</li>
          <li>Address: {user.address}</li>
          <li>Email: {user.email}</li>
          <li>Phone Number: {user.phoneNumber}</li>
          <li>Department: {user.dept}</li>
        </ul>
      ) : (
        <p>No user details available.</p>
      )}
    </div>
  );
};

export default DisplayComponent;
