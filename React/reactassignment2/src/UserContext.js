import React, { createContext, useState } from 'react';

export const UserContext = createContext();

export const UserProvider = ({ children }) => {
  const [username, setUsername] = useState('');
  const [user, setUser] = useState(null);

  return (
    <UserContext.Provider value={{ username, setUsername, user, setUser }}>
      {children}
    </UserContext.Provider>
  );
};
