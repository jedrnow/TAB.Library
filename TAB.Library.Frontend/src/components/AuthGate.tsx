import React, { useState, useEffect } from 'react';
import LoginForm from './LoginForm';
import { API_BASE_URL } from '../constants/api';

interface AuthGateProps {
  loggedInComponent?: React.ReactNode;
}

const AuthGate: React.FC<AuthGateProps> = ({ loggedInComponent}) => {
  const [isAuthenticated, setIsAuthenticated] = useState<boolean>(false);

  useEffect(() => {
    const checkAuth = async () => {
      try {
        const response = await fetch(API_BASE_URL + '/Auth/IsAuthenticated', {
          method: 'GET',
          credentials: 'include'
      });
        if (response.status === 200) {
          setIsAuthenticated(true);
        } else {
          setIsAuthenticated(false);
        }
      } catch (error) {
        setIsAuthenticated(false);
      }
    };

    checkAuth();
  }, []);

  return <>{isAuthenticated ? loggedInComponent : <LoginForm></LoginForm>}</>;
};

export default AuthGate;