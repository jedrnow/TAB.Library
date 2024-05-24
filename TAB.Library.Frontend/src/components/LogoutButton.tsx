import React from 'react';
import { API_BASE_URL } from '../constants/api';

const LogoutButton: React.FC = () => {
  const handleLogout = async () => {
    await fetch(API_BASE_URL + '/Auth/Logout', { method: 'POST', credentials:'include' });
    window.location.reload();
  };

  return (
      <button onClick={handleLogout}>Logout</button>
  );
};

export default LogoutButton;
