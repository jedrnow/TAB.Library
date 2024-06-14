import React, { useEffect, useState } from 'react';
import { useParams } from 'react-router-dom';
import { BookDetail } from '../interfaces/Book';
import { API_BASE_URL } from '../constants/api';
import { Container } from '@mui/material';
import BookThumbnail from './BookThumbnail';
import Dashboard from './Dashboard';

const BookDetails: React.FC = () => {
  const { bookId } = useParams<{ bookId: string }>();
  const [book, setBook] = useState<BookDetail>();

  useEffect(() => {
    fetchBook(bookId);
  }, [bookId]);

  const fetchBook = async (bookId: string | undefined) => {
    try {
      const response = await fetch(API_BASE_URL + `/Book/${bookId}`, {credentials:'include'});
      const data: BookDetail = await response.json();
      setBook(data);
    } catch (error) {
      console.error('Error fetching books:', error);
    }
  };

  const rentBook = async (bookId: string | undefined) => {
    try {
        const response = await fetch(API_BASE_URL + `/Book/${bookId}/Rent`, {method: 'POST', credentials:'include'});
        const result: boolean = await response.json();
        if(result) window.location.reload();
      } catch (error) {
        console.error('Error renting book:', error);
      }
  }

  const openPdfViewer = (base64Pdf: string | undefined) => {
    if (!base64Pdf) {
      return;
    }
  
    // Decode base64 string to binary data
    const byteCharacters = atob(base64Pdf);
    const byteNumbers = new Array(byteCharacters.length);
    for (let i = 0; i < byteCharacters.length; i++) {
      byteNumbers[i] = byteCharacters.charCodeAt(i);
    }
    const byteArray = new Uint8Array(byteNumbers);
    const blob = new Blob([byteArray], { type: 'application/pdf' });
    const objectUrl = URL.createObjectURL(blob);
  
    // Open the PDF in a new tab
    window.open(objectUrl, '_blank');
  };

  return (
    <>
    <Dashboard></Dashboard>
    <Container maxWidth="sm">
      <h2>Book Details</h2>
      <BookThumbnail content={book?.thumbnailLargeContent ?? ""}></BookThumbnail>
      <p>Book ID: {bookId}</p>
      <p>{book?.title ?? ""}</p>
      <p>{book?.publishYear ? `(${book.publishYear})` : ""}</p>
      <p>{book?.authorName ?? ""}</p>
      {!book?.isReserved ? <button onClick={() => rentBook(bookId)}>Rent</button> : <button disabled>Reserved</button>}
      {book?.reservedByCurrentUser ? ((book?.pdfContent != null && book.pdfContent != "") ? <button onClick={() => openPdfViewer(book.pdfContent)}>Print</button> : <button disabled>Pdf file not available</button>) : <></>}
    </Container>
    </>
  );
};

export default BookDetails;
