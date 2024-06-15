import React, { useEffect, useState } from 'react';
import { useParams } from 'react-router-dom';
import { BookDetail } from '../interfaces/Book';
import { API_BASE_URL } from '../constants/api';
import { Container, TextField, Button, MenuItem, Select, FormControl, InputLabel } from '@mui/material';
import BookThumbnail from './BookThumbnail';
import Dashboard from './Dashboard';
import { SelectChangeEvent } from '@mui/material/Select';

const BookEdit: React.FC = () => {
  const { bookId } = useParams<{ bookId: string }>();
  const [book, setBook] = useState<BookDetail>();
  const [authors, setAuthors] = useState<{ id: number, name: string }[]>([]);
  const [categories, setCategories] = useState<{ id: number, name: string }[]>([]);
  const [formData, setFormData] = useState({
    title: '',
    publishYear: '',
    authorId: '',
    authorFirstName: '',
    authorLastName: '',
    categoryId: '',
    categoryName: ''
  });

  useEffect(() => {
    fetchBook(bookId);
    fetchAuthors();
    fetchCategories();
  }, [bookId]);

  const fetchBook = async (bookId: string | undefined) => {
    try {
      const response = await fetch(API_BASE_URL + `/Book/${bookId}`, { credentials: 'include' });
      const data: BookDetail = await response.json();
      setBook(data);
      setFormData({
        title: data.title,
        publishYear: data.publishYear.toString(),
        authorId: data.authorId.toString(),
        authorFirstName: '',
        authorLastName: '',
        categoryId: data.categoryId.toString(),
        categoryName: ''
      });
    } catch (error) {
      console.error('Error fetching book:', error);
    }
  };

  const fetchAuthors = async () => {
    try {
      const response = await fetch(API_BASE_URL + '/Author', { credentials: 'include' });
      const data = await response.json();
      setAuthors(data);
    } catch (error) {
      console.error('Error fetching authors:', error);
    }
  };

  const fetchCategories = async () => {
    try {
      const response = await fetch(API_BASE_URL + '/Category', { credentials: 'include' });
      const data = await response.json();
      setCategories(data);
    } catch (error) {
      console.error('Error fetching categories:', error);
    }
  };

  const handleInputChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    const { name, value } = event.target;
    setFormData((prevFormData) => ({
      ...prevFormData,
      [name]: value
    }));
  };

  const handleSelectChange = (event: SelectChangeEvent<string>) => {
    const { name, value } = event.target;
    setFormData((prevFormData) => ({
      ...prevFormData,
      [name]: value
    }));
  };

  const handleSubmit = async (event: React.FormEvent<HTMLFormElement>) => {
    event.preventDefault();

    const updatedBook = {
      title: formData.title,
      publishYear: parseInt(formData.publishYear),
      authorId: parseInt(formData.authorId) || 0,
      categoryId: parseInt(formData.categoryId) || 0,
      authorFirstName: formData.authorId === "0" ? formData.authorFirstName : undefined,
      authorLastName: formData.authorId === "0" ? formData.authorLastName : undefined,
      categoryName: formData.categoryId === "0" ? formData.categoryName : undefined
    };

    try {
      const response = await fetch(API_BASE_URL + `/Book/${bookId}`, {
        method: 'PUT',
        headers: {
          'Content-Type': 'application/json'
        },
        body: JSON.stringify(updatedBook),
        credentials: 'include'
      });
      if (response.ok) {
        console.log('Book updated successfully');
        window.location.href = `/book/${bookId}`;
      } else {
        console.error('Failed to update book');
      }
    } catch (error) {
      console.error('Error updating book:', error);
    }
  };

  return (
    <>
      <Dashboard />
      <Container maxWidth="sm">
        <h2>Book Edit</h2>
        <BookThumbnail content={book?.thumbnailLargeContent ?? ''} />
        <p>Book ID: {bookId}</p>
        <form onSubmit={handleSubmit}>
          <TextField
            label="Title"
            name="title"
            value={formData.title}
            onChange={handleInputChange}
            fullWidth
            margin="normal"
            sx={{backgroundColor:'white'}}
            InputLabelProps={{
              style: { color: '#ff3845' },
            }}
          />
          <TextField
            label="Publish Year"
            name="publishYear"
            value={formData.publishYear}
            onChange={handleInputChange}
            fullWidth
            margin="normal"
            sx={{backgroundColor:'white'}}
            InputLabelProps={{
              style: { color: '#ff3845' },
            }}
          />
          <FormControl fullWidth margin="normal">
            <InputLabel sx={{color:'#ff3845'}}>Author</InputLabel>
            <Select
              name="authorId"
              value={formData.authorId}
              onChange={handleSelectChange}
              sx={{backgroundColor:'white'}}
              
            >
              {authors.map((author) => (
                <MenuItem key={author.id} value={author.id.toString()}>
                  {author.name}
                </MenuItem>
              ))}
              <MenuItem value="0">New Author</MenuItem>
            </Select>
          </FormControl>
          {formData.authorId === "0" && (
            <>
              <TextField
                label="Author First Name"
                name="authorFirstName"
                value={formData.authorFirstName}
                onChange={handleInputChange}
                fullWidth
                margin="normal"
                sx={{backgroundColor:'white'}}
                InputLabelProps={{
                  style: { color: '#ff3845' },
                }}
              />
              <TextField
                label="Author Last Name"
                name="authorLastName"
                value={formData.authorLastName}
                onChange={handleInputChange}
                fullWidth
                margin="normal"
                sx={{backgroundColor:'white'}}
                InputLabelProps={{
                  style: { color: '#ff3845' },
                }}
              />
            </>
          )}
          <FormControl fullWidth margin="normal">
            <InputLabel sx={{color:'#ff3845'}}>Category</InputLabel>
            <Select
              name="categoryId"
              value={formData.categoryId}
              onChange={handleSelectChange}
              sx={{backgroundColor:'white'}}
            >
              {categories.map((category) => (
                <MenuItem key={category.id} value={category.id.toString()}>
                  {category.name}
                </MenuItem>
              ))}
              <MenuItem value="0">New Category</MenuItem>
            </Select>
          </FormControl>
          {formData.categoryId === "0" && (
            <TextField
              label="Category Name"
              name="categoryName"
              value={formData.categoryName}
              onChange={handleInputChange}
              fullWidth
              margin="normal"
              sx={{backgroundColor:'white'}}
              InputLabelProps={{
                style: { color: '#ff3845' },
              }}
            />
          )}
          <Button type="submit" variant="contained" color="primary" fullWidth>
            Submit
          </Button>
        </form>
      </Container>
    </>
  );
};

export default BookEdit;
