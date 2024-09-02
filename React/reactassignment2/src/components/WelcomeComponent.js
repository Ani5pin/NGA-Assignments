import React, { useContext } from 'react';
import { UserContext } from './UserContext';

const WelcomeComponent = () => {
  const { username } = useContext(UserContext);

  return (
    <div>
      {username ? <h1>Welcome, {username}!</h1> : <h1>Welcome, Guest!</h1>}
    </div>
  );
};

export default WelcomeComponent;
