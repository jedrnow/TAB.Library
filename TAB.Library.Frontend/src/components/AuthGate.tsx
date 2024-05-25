import React, { useState, useEffect } from 'react';
import LoginForm from './LoginForm';
import { API_BASE_URL } from '../constants/api';

interface AuthGateProps {
  loggedInComponent?: React.ReactNode;
  requireAdminsPermission: boolean;
}

const AuthGate: React.FC<AuthGateProps> = ({ loggedInComponent, requireAdminsPermission}) => {
  const [isAuthenticated, setIsAuthenticated] = useState<boolean>(false);
  const [isAdmin, setIsAdmin] = useState<boolean>(false);

  useEffect(() => {
    const checkAuth = async () => {
      try {
        const responseAuth = await fetch(API_BASE_URL + '/Auth/IsAuthenticated', {
          method: 'GET',
          credentials: 'include'
        });

        if (responseAuth.status === 200){
          setIsAuthenticated(true);

          if (requireAdminsPermission){
            const responseAdmin = await fetch(API_BASE_URL + '/Auth/IsAdmin', {
              method: 'GET',
              credentials: 'include'
            });

            if (responseAdmin.status === 200){
              setIsAdmin(true);
            }
          }
        }
        else
        {
          setIsAuthenticated(false);
        }
      }
      catch (error)
      {
        setIsAuthenticated(false);
      }
    };

    checkAuth();
  }, []);

  return <>{(isAuthenticated && (!requireAdminsPermission || isAdmin)) ? loggedInComponent : <LoginForm></LoginForm>}</>;
};

export default AuthGate;