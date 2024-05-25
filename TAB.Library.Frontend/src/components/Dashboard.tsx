import LogoutButton from './LogoutButton';
import * as React from 'react';
import "./Dashboard.css";

const Dashboard: React.FC = () => {
  const handleHomeButton = () => {
    window.location.href = "/";
  }

  const handleMyRentalsButton = () => {
    window.location.href = "/rentals";
  }

  return (
    <>
      <div id="menu">
      <button onClick={handleHomeButton} className="menuItem">Home</button>
      <button onClick={handleMyRentalsButton} className="menuItem">My Rentals</button>
      <LogoutButton />
      </div>
    </>
  );
};

export default Dashboard;
