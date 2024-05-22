import React from 'react';
import { API_BASE_URL } from '../constants/api';

const LogoutButton: React.FC = () => {
  const handleLogout = async () => {
    await fetch(API_BASE_URL + '/Auth/Logout', { method: 'POST' });
  };

  return (
      <button onClick={handleLogout}>Wyloguj</button>
  );
};

export default LogoutButton;