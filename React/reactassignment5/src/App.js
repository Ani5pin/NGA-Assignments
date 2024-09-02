import React, { useState } from 'react';
import RegistrationForm from './RegistrationForm';
import Login from './Login';
import Welcome from './Welcome';
import UserTable from './UserTable';

const App = () => {
  const [loggedInUser, setLoggedInUser] = useState(null);

  return (
    <div>
      {loggedInUser ? (
        <div>
          <Welcome user={loggedInUser} />
          <UserTable />
        </div>
      ) : (
        <div>
          <Login onLogin={setLoggedInUser} />
          <RegistrationForm />
        </div>
      )}
    </div>
  );
};

export default App;
