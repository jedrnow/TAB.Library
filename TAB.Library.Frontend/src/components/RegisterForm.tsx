// src/components/RegisterForm.tsx
import React, { useState } from 'react';
import { API_BASE_URL } from '../constants/api';
import "./RegisterForm.css";
import ErrorResponseBody from '../constants/ErrorResponseBody';
import { Link } from 'react-router-dom';

const RegisterForm: React.FC = () => {
  const [username, setUsername] = useState<string>('');
  const [password, setPassword] = useState<string>('');
  const [confirmPassword, setConfirmPassword] = useState<string>('');
  const [email, setEmail] = useState<string>('');
  const [firstName, setFirstName] = useState<string>('');
  const [lastName, setLastName] = useState<string>('');
  const [phoneNumber, setPhoneNumber] = useState<string>('');
  const [validationErrorText, setValidationErrorText] = useState<string>('');

  const handleUsernameChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    setUsername(e.target.value);
  };

  const handlePasswordChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    setPassword(e.target.value);
  };

  const handleConfirmPasswordChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    setConfirmPassword(e.target.value);
  };

  const handleEmailChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    setEmail(e.target.value);
  };

  const handleFirstNameChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    setFirstName(e.target.value);
  };

  const handleLastNameChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    setLastName(e.target.value);
  };

  const handlePhoneNumberChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    setPhoneNumber(e.target.value);
  };

  const handleRegister = async () => {
    const requestBody = { username, password, confirmPassword, email, firstName, lastName, phoneNumber: phoneNumber.replace(/\s/g, "") };
    try {
      const response = await fetch(API_BASE_URL + '/Auth/Register', {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(requestBody),
        credentials: 'include'
      });

      if (response.ok) {
        setValidationErrorText('');
        window.location.href = '/';
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
    <div id="registerForm">
      <h2>Register</h2>
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
        <label htmlFor="confirmPassword">Confirm password:</label>
        <div>
          <input
            type="password"
            id="confirmPassword"
            value={confirmPassword}
            onChange={handleConfirmPasswordChange}
          />
        </div>
        <label htmlFor="email">Email:</label>
        <div>
          <input
            type="email"
            id="email"
            value={email}
            onChange={handleEmailChange}
          />
        </div>
        <label htmlFor="firstName">First name:</label>
        <div>
          <input
            type="text"
            id="firstName"
            value={firstName}
            onChange={handleFirstNameChange}
          />
        </div>
        <label htmlFor="lastName">Last name:</label>
        <div>
          <input
            type="text"
            id="lastName"
            value={lastName}
            onChange={handleLastNameChange}
          />
        </div>
        <label htmlFor="phoneNumber">Phone number:</label>
        <div>
          <input
            type="tel"
            id="phoneNumber"
            value={phoneNumber}
            onChange={handlePhoneNumberChange}
            pattern="[0-9]{3} [0-9]{3} [0-9]{3}"
          />
        </div>
        <div>
        <Link to="/">Already have account?</Link>
        </div>
        <button type="button" onClick={handleRegister}>
          Register
        </button>
      </form>
      <p>{validationErrorText}</p>
    </div>
  );
};

export default RegisterForm;
