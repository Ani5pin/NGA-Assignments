import React, { useContext, useState } from 'react';
import { UserContext } from './UserContext';

const LoginComponent = () => {
  const { setUsername } = useContext(UserContext);
  const [input, setInput] = useState('');

  const handleLogin = () => {
    setUsername(input);
  };

  return (
    <div>
      <input
        type="text"
        placeholder="Enter username"
        value={input}
        onChange={(e) => setInput(e.target.value)}
      />
      <button onClick={handleLogin}>Login</button>
    </div>
  );
};

export default LoginComponent;
