import LogoutButton from './LogoutButton';
import * as React from 'react';
import "./Dashboard.css";
import BookGrid from './BookGrid';

const Dashboard: React.FC = () => {
  const handleHomeButton = () => {
    window.location.href = "/";
  }

  const handleMyRentalsButton = () => {
    window.location.href = "/rentals";
  }

  return (
    <div>
      <h2>Dashboard</h2>
      <div id="menu">
      <button onClick={handleHomeButton} className="menuItem">Home</button>
      <button onClick={handleMyRentalsButton} className="menuItem">My Rentals</button>
      <LogoutButton />
      </div>
      <BookGrid />
    </div>
  );
};

export default Dashboard;
