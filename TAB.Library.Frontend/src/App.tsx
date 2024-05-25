import React from 'react';
import AuthGate from './components/AuthGate';
import RegisterForm from './components/RegisterForm';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import BookDetails from './components/BookDetails';
import Home from './components/Home';

const App: React.FC = () => {
  return (
    <Router>
      <div>
        <h1>Library</h1>
        <Routes>
          <Route path="/" element={<AuthGate loggedInComponent={<Home />} />} />
          <Route path="/register" element={<RegisterForm />} />
          <Route path="/book/:bookId" element={<AuthGate loggedInComponent={<BookDetails />} />} />
          <Route path="*" element={<AuthGate loggedInComponent={<Home />} />} />
        </Routes>
      </div>
    </Router>
  );
};

export default App;