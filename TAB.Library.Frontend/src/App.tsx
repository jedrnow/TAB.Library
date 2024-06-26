import React from 'react';
import AuthGate from './components/AuthGate';
import RegisterForm from './components/RegisterForm';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import BookDetails from './components/BookDetails';
import Home from './components/Home';
import UsersRentals from './components/UsersRentals';
import AdminPanel from './components/AdminPanel';
import BookEdit from './components/BookEdit';
import BookAdd from './components/BookAdd';

const App: React.FC = () => {
  return (
    <Router>
      <div>
        <h1>Library</h1>
        <Routes>
          <Route path="/" element={<AuthGate loggedInComponent={<Home />} requireAdminsPermission={false} />} />
          <Route path="/register" element={<RegisterForm />} />
          <Route path="/book/:bookId" element={<AuthGate loggedInComponent={<BookDetails />} requireAdminsPermission={false} />} />
          <Route path="/book/:bookId/edit" element={<AuthGate loggedInComponent={<BookEdit />} requireAdminsPermission={true} />} />
          <Route path="/book/add" element={<AuthGate loggedInComponent={<BookAdd />} requireAdminsPermission={true} />} />
          <Route path="/rentals" element={<AuthGate loggedInComponent={<UsersRentals />} requireAdminsPermission={false} />} />
          <Route path="/admin/panel" element={<AuthGate loggedInComponent={<AdminPanel />} requireAdminsPermission={true} />} />
          <Route path="*" element={<AuthGate loggedInComponent={<Home />} requireAdminsPermission={false} />} />
        </Routes>
      </div>
    </Router>
  );
};

export default App;