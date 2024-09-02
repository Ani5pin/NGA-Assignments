import React from 'react';
import { useLocation } from 'react-router-dom';

const Welcome = () => {
  const location = useLocation();
  const queryParams = new URLSearchParams(location.search);
  const name = queryParams.get('name');

  return (
    <div>
      <h1>Welcome, {name}!</h1>
    </div>
  );
};

export default Welcome;