import { API_BASE_URL } from '../constants/api';
import { Book, BooksResponse } from '../interfaces/Book';
import * as React from 'react';
import { useEffect, useState } from 'react';
import "./BookGrid.css";
import { styled } from '@mui/material/styles';
import Grid from '@mui/material/Unstable_Grid2';
import Paper from '@mui/material/Paper';
import Box from '@mui/material/Box';

const Item = styled(Paper)(({ theme }) => ({
    backgroundColor: theme.palette.mode === 'dark' ? '#1A2027' : '#fff',
    ...theme.typography.body2,
    padding: theme.spacing(1),
    textAlign: 'center',
    color: theme.palette.text.secondary,
  }));

const BookGrid: React.FC = () => {
  const [books, setBooks] = useState<Book[]>([]);
  const [pageNumber, setPageNumber] = useState<number>(1);
  const [pageSize, setPageSize] = useState<number>(10);
  const [totalPages, setTotalPages] = useState<number>(0);

  useEffect(() => {
    fetchBooks(pageNumber, pageSize);
  }, [pageNumber, pageSize]);

  const fetchBooks = async (page: number, size: number) => {
    try {
      const response = await fetch(API_BASE_URL + `/Book?pageNumber=${page}&pageSize=${size}`, {credentials:'include'});
      const data: BooksResponse = await response.json();
      setBooks(data.list);
      setTotalPages(data.totalPages);
    } catch (error) {
      console.error('Error fetching books:', error);
    }
  };

  const handlePageChange = (newPageNumber: number) => {
    setPageNumber(newPageNumber);
  };

  const handlePageSizeChange = (event: React.ChangeEvent<HTMLSelectElement>) => {
    setPageSize(parseInt(event.target.value, 10));
    setPageNumber(1);
  };


  return (
    <div>
        <h3>Books</h3>
        <Box sx={{ flexGrow: 1 }}>
        <Grid container spacing={{ xs: 2, md: 3 }} columns={{ xs: 4, sm: 8, md: 12 }}>
        {books.map((book: Book, index: number) => (
          <Grid xs={2} sm={4} md={4} key={index}>
            <Item>"{book.title}"</Item>
            <Item>({book.publishYear})</Item>
            <Item>{book.authorName}</Item>
            <Item>{book.categoryName}</Item>
            <Item>{!book.isReserved ? <a href={`/book/${book.id}`}>Available</a> : "Reserved"}</Item>
          </Grid>
        ))}
      </Grid>
      </Box>
        <div id="pagination">
          <button className="paginationItem" onClick={() => handlePageChange(pageNumber - 1)} disabled={pageNumber === 1}>
            Previous
          </button>
          <span className="paginationItem">Page {pageNumber} of {totalPages}</span>
          <button className="paginationItem" onClick={() => handlePageChange(pageNumber + 1)} disabled={pageNumber === totalPages}>
            Next
          </button>
          <select className="paginationItem" value={pageSize} onChange={handlePageSizeChange}>
            <option value={5}>5</option>
            <option value={10}>10</option>
            <option value={20}>20</option>
          </select>
        </div>
    </div>
  );
};

export default BookGrid;
