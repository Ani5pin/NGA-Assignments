import React from 'react';
import { UserProvider } from './UserContext';
import { ColorProvider } from './ColorContext';
import LoginComponent from './LoginComponent';
import WelcomeComponent from './WelcomeComponent';
import RegistrationComponent from './RegistrationComponent';
import DisplayComponent from './DisplayComponent';
import Comp1 from './Comp1';
import Comp2 from './Comp2';
import Comp3 from './Comp3';

function App() {
  const { username, user } = useContext(UserContext);

  return (
    <ColorProvider>
      <UserProvider>
        <div>
          {/* Login and Welcome */}
          {username ? (
            <div>
              <WelcomeComponent />
              <button onClick={() => setUsername('')}>Logout</button>
            </div>
          ) : (
            <LoginComponent />
          )}

          {/* Registration and Display */}
          {username && !user ? (
            <RegistrationComponent />
          ) : (
            <DisplayComponent user={user} />
          )}

          {/* Color Components */}
          <Comp1 />
          <Comp2 />
          <Comp3 />
        </div>
      </UserProvider>
    </ColorProvider>
  );
}

export default App;
