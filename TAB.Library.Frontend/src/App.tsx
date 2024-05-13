import React from 'react';
import AuthGate from './components/AuthGate';
import Dashboard from './components/Dashboard';

const App: React.FC = () => {
  return (
    <div>
      <h1>Library</h1>
      <AuthGate
        loggedInComponent={<Dashboard />}
      />
    </div>
  );
};

export default App;