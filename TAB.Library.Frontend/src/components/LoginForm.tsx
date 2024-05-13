import React, { useState } from 'react';
import { API_BASE_URL } from '../constants/api';
import { redirect} from 'react-router-dom';
import "./LoginForm.css";
import ErrorResponseBody from '../constants/ErrorResponseBody';

interface LoginRequestBody {
  username: string;
  password: string;
}

const LoginForm: React.FC = () => {
  const [username, setUsername] = useState<string>('');
  const [password, setPassword] = useState<string>('');
  const [validationErrorText, setValidationErrorText] = useState<string>('');

  const handleUsernameChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    setUsername(e.target.value);
  };

  const handlePasswordChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    setPassword(e.target.value);
  };

  const handleLogin = async () => {
    const requestBody: LoginRequestBody = {
      username: username,
      password: password
    };

    try {
      const response = await fetch(API_BASE_URL + '/Auth/Login', {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(requestBody),
      })

      if (response.ok) {
        setValidationErrorText('');
        return redirect("/");
      } else {
        const responseBody: ErrorResponseBody = await response.json();
        setValidationErrorText(responseBody.Message);
      }
    } catch (error) {
      console.error(error);
      setValidationErrorText("Service unavailable");
    }
  };

  return (
    <div id="loginForm">
      <h2>Login</h2>
      <form>
        <label htmlFor="username">Username:</label>
        <div>
          <input
            type="text"
            id="username"
            value={username}
            onChange={handleUsernameChange}
          />
        </div>
        <label htmlFor="password">Password:</label>
        <div>
          <input
            type="password"
            id="password"
            value={password}
            onChange={handlePasswordChange}
          />
        </div>
        <button type="button" onClick={handleLogin}>
          Zaloguj się
        </button>
      </form>
      <p>{validationErrorText}</p>
    </div>
  );
};

export default LoginForm;
