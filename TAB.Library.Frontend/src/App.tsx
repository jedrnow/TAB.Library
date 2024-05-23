import React from 'react';
import AuthGate from './components/AuthGate';
import Dashboard from './components/Dashboard';
import RegisterForm from './components/RegisterForm';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';

const App: React.FC = () => {
  return (
    <Router>
      <div>
        <h1>Library</h1>
        <Routes>
          <Route path="/" element={<AuthGate loggedInComponent={<Dashboard />} />} />
          <Route path="/register" element={<RegisterForm />} />
        </Routes>
      </div>
    </Router>
  );
};

export default App;