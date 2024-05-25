import React from 'react';
import AuthGate from './components/AuthGate';
import RegisterForm from './components/RegisterForm';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import BookDetails from './components/BookDetails';
import Home from './components/Home';
import UsersRentals from './components/UsersRentals';
import AdminPanel from './components/AdminPanel';

const App: React.FC = () => {
  return (
    <Router>
      <div>
        <h1>Library</h1>
        <Routes>
          <Route path="/" element={<AuthGate loggedInComponent={<Home />} requireAdminsPermission={false} />} />
          <Route path="/register" element={<RegisterForm />} />
          <Route path="/book/:bookId" element={<AuthGate loggedInComponent={<BookDetails />} requireAdminsPermission={false} />} />
          <Route path="/rentals" element={<AuthGate loggedInComponent={<UsersRentals />} requireAdminsPermission={false} />} />
          <Route path="/admin/panel" element={<AuthGate loggedInComponent={<AdminPanel />} requireAdminsPermission={false} />} />
          <Route path="*" element={<AuthGate loggedInComponent={<Home />} requireAdminsPermission={false} />} />
        </Routes>
      </div>
    </Router>
  );
};

export default App;