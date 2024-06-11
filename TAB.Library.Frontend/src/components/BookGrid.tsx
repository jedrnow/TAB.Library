import { API_BASE_URL } from '../constants/api';
import { Book, BooksResponse } from '../interfaces/Book';
import * as React from 'react';
import { useEffect, useState } from 'react';
import "./Styles.css";
import { styled } from '@mui/material/styles';
import Grid from '@mui/material/Unstable_Grid2';
import Paper from '@mui/material/Paper';
import Box from '@mui/material/Box';
import BookThumbnail from './BookThumbnail';
import { Link } from 'react-router-dom';

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
  const [pageSize, setPageSize] = useState<number>(5);
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
        <Box sx={{ flexGrow: 1 }}>
        <Grid container spacing={{ xs: 2, md: 3 }} columns={{ xs: 4, sm: 8, md: 12 }}>
        {books.map((book: Book, index: number) => (
          <Grid xs={2} sm={4} md={4} key={index}>
            <Item><Link to={`/book/${book.id}`}><BookThumbnail content={book.thumbnailMediumContent}/></Link></Item>
            <Item><Link to={`/book/${book.id}`}><b>{book.title}</b></Link></Item>
            <Item>({book.publishYear})</Item>
            <Item>{book.authorName}</Item>
            <Item>{book.categoryName}</Item>
            <Item><p className={book.isReserved ? "reservedText" : "availableText"}>{!book.isReserved ? <b>Available</b> : <b>Reserved</b>}</p></Item>
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
