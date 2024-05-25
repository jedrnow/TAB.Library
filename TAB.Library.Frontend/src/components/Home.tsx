import * as React from 'react';
import BookGrid from './BookGrid';
import Dashboard from './Dashboard';

const Home: React.FC = () => {
  return (
    <div>
      <Dashboard></Dashboard>
      <BookGrid />
    </div>
  );
};

export default Home;
