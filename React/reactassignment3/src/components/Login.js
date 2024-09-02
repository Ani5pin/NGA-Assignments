import React, { useRef } from 'react';
import { useNavigate } from 'react-router-dom';

function Login({ onLogin }) {
  const emailRef = useRef(null);
  const passwordRef = useRef(null);
  const navigate = useNavigate();

  const handleLogin = () => {
    const email = emailRef.current.value;
    const password = passwordRef.current.value;
    onLogin({ email, password });
    navigate('/welcome', { state: { email, password } });
  };

  return (
    <div>
      <label>Enter Email:</label>
      <input type="email" ref={emailRef} />
      <br />
      <label>Enter Password:</label>
      <input type="password" ref={passwordRef} />
      <br />
      <button onClick={handleLogin}>Login</button>
    </div>
  );
}

export default Login;
