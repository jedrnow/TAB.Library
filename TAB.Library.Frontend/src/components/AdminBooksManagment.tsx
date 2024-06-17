import { API_BASE_URL } from '../constants/api';
import * as React from 'react';
import { useEffect, useState } from 'react';
import { Book, BooksResponse } from '../interfaces/Book';
import { DataGrid, GridColDef, GridPaginationModel, GridRowSelectionModel } from '@mui/x-data-grid';

const AdminBooksManagment: React.FC = () => {
    const [books, setBooks] = useState<Book[]>([]);
    const [paginationModel, setPaginationModel] = useState<GridPaginationModel>({ page: 0, pageSize: 10 });
    const [totalPages, setTotalPages] = useState<number>(0);
    const [selectedRows, setSelectedRows] = useState<GridRowSelectionModel>([]);
    const [fileInputs, setFileInputs] = useState<{ [key: string]: File | null }>({});
    const [pdfFileInputs, setPdfFileInputs] = useState<{ [key: string]: File | null }>({});

    useEffect(() => {
        fetchBooks(paginationModel.page + 1, paginationModel.pageSize);
    }, [paginationModel]);

    const fetchBooks = async (page: number, size: number) => {
        try {
            const response = await fetch(`${API_BASE_URL}/Book?pageNumber=${page}&pageSize=${size}`, { credentials: 'include' });
            const data: BooksResponse = await response.json();
            setBooks(data.list);
            setTotalPages(data.totalPages);
        } catch (error) {
            console.error('Error fetching Books:', error);
        }
    };

    const handlePaginationModelChange = (newModel: GridPaginationModel) => {
        setPaginationModel(newModel);
    };

    const handleSelectionChange = (newSelection: GridRowSelectionModel) => {
        setSelectedRows(newSelection);
    };

    const handleFileChange = (bookId: string, file: File | null) => {
        setFileInputs(prev => ({ ...prev, [bookId]: file }));
    };
    
    const handlePdfFileChange = (bookId: string, file: File | null) => {
        setPdfFileInputs(prev => ({ ...prev, [bookId]: file }));
    };

    const handleDeleteBook = async (bookId: string) => {
        try {
            const response = await fetch(`${API_BASE_URL}/Book/${bookId}`, {
                method: 'DELETE',
                credentials: 'include'
            });
            const success = await response.json();
            if (success) {
                fetchBooks(paginationModel.page + 1, paginationModel.pageSize);
            } else {
                console.error(`Error deleting book id ${bookId}.`);
            }
        } catch (error) {
            console.error(`Error deleting book id ${bookId}:`, error);
        }
    };

    const handleEditBook = (bookId: string) => {
        window.location.href = `/book/${bookId}/edit`;
    };

    const handleAddBook = () => {
        window.location.href = `/book/add`;
    };

    const handleAddThumbnail = async (bookId: string) => {
        const file = fileInputs[bookId];
        if (!file) {
            console.error(`No file selected for book ${bookId}.`);
            return;
        }

        const formData = new FormData();
        formData.append('file', file);

        try {
            const response = await fetch(`${API_BASE_URL}/Book/${bookId}/Thumbnail`, {
                method: 'POST',
                credentials: 'include',
                body: formData,
            });
            const success = await response.json();
            if (success) {
                fetchBooks(paginationModel.page + 1, paginationModel.pageSize);
            } else {
                console.error(`Error adding thumbnail ${bookId}.`);
            }
        } catch (error) {
            console.error(`Error adding thumbnail ${bookId}:`, error);
        }
    };

    const handleAddFile = async (bookId: string) => {
        const file = pdfFileInputs[bookId];
        if (!file) {
            console.error(`No file selected for book ${bookId}.`);
            return;
        }

        const formData = new FormData();
        formData.append('file', file);

        try {
            const response = await fetch(`${API_BASE_URL}/Book/${bookId}/File`, {
                method: 'POST',
                credentials: 'include',
                body: formData,
            });
            const success = await response.json();
            if (success) {
                fetchBooks(paginationModel.page + 1, paginationModel.pageSize);
            } else {
                console.error(`Error adding file ${bookId}.`);
            }
        } catch (error) {
            console.error(`Error adding file ${bookId}:`, error);
        }
    };

    const handleAddMultipleThumbnails = async () => {
        for(const bookId in fileInputs){
            const file = fileInputs[bookId];
            if (!file) {
                console.error(`No file selected for book ${bookId}.`);
                continue;
            }

            const formData = new FormData();
            formData.append('file', file);

            try {
                const response = await fetch(`${API_BASE_URL}/Book/${bookId}/Thumbnail`, {
                    method: 'POST',
                    credentials: 'include',
                    body: formData,
                });
                const success = await response.json();
                if (success) {
                    fetchBooks(paginationModel.page + 1, paginationModel.pageSize);
                } else {
                    console.error(`Error adding thumbnail ${bookId}.`);
                }
            } catch (error) {
                console.error(`Error adding thumbnail ${bookId}:`, error);
            }
        }

        fetchBooks(paginationModel.page + 1, paginationModel.pageSize);
    };
    
    const handleAddMultipleFiles = async () => {
        for(const bookId in pdfFileInputs){
            const file = pdfFileInputs[bookId];
            if (!file) {
                console.error(`No file selected for book ${bookId}.`);
                continue;
            }

            const formData = new FormData();
            formData.append('file', file);

            try {
                const response = await fetch(`${API_BASE_URL}/Book/${bookId}/File`, {
                    method: 'POST',
                    credentials: 'include',
                    body: formData,
                });
                const success = await response.json();
                if (success) {
                    fetchBooks(paginationModel.page + 1, paginationModel.pageSize);
                } else {
                    console.error(`Error adding file ${bookId}.`);
                }
            } catch (error) {
                console.error(`Error adding file ${bookId}:`, error);
            }
        }

        fetchBooks(paginationModel.page + 1, paginationModel.pageSize);
    };

    const columns: GridColDef[] = [
        { field: 'id', headerName: 'ID', width: 30 },
        { field: 'title', headerName: 'Title', width: 400 },
        { field: 'author', headerName: 'Author', width: 200 },
        { field: 'publishYear', headerName: 'Publish Year', width: 100 },
        { field: 'category', headerName: 'Category', width: 200 },
        { field: 'isAvailable', headerName: 'Available', width: 100, type: 'boolean' },
        { field: 'isPdfAvailable', headerName: 'PDF', width: 100, type: 'boolean' },
        { field: 'isThumbnailAvailable', headerName: 'Thumbnail', width: 100, type: 'boolean' },
    ];

    const rows = books.map(book => ({
        id: book.id,
        title: book.title,
        publishYear: book.publishYear,
        author: book.authorName,
        category: book.categoryName,
        isAvailable: !book.isReserved,
        isPdfAvailable: book.pdfContent != "",
        isThumbnailAvailable: book.thumbnailMediumContent != ""
    }));

    return (
        <>
            <DataGrid
                rows={rows}
                columns={columns}
                paginationMode="server"
                rowCount={totalPages * paginationModel.pageSize}
                paginationModel={paginationModel}
                onPaginationModelChange={handlePaginationModelChange}
                pageSizeOptions={[2, 5, 10, 20]}
                checkboxSelection
                onRowSelectionModelChange={handleSelectionChange}
            />
            <button onClick={() => handleAddBook()}>Add book</button>
            {selectedRows.length == 1 ? <div><button onClick={() => handleEditBook(selectedRows[0].toString())}>Edit book</button><button onClick={() => handleDeleteBook(selectedRows[0].toString())}>Delete book</button></div> : <></>}
            {selectedRows.length > 1 ? selectedRows.map(rowId => (
                <div key={rowId} style={{ margin: '10px 0' }}>
                    <label style={{color:'black', margin: '20px'}}>ID = {rowId}</label>
                    <input
                        type="file"
                        accept=".jpg,.jpeg,.png"
                        onChange={e => handleFileChange(rowId.toString(), e.target.files ? e.target.files[0] : null)}
                        style={{width:'100px'}}
                    />
                    {fileInputs[rowId.toString()] && <img src="/check-mark.svg" alt="Check Mark" style={{ color: 'black', marginLeft: '10px', width: '20px', height: '20px' }} />}
                </div>
            )) : selectedRows.map(rowId => (
                <div key={rowId} style={{ margin: '10px 0' }}>
                    <input
                        type="file"
                        accept=".jpg,.jpeg,.png"
                        onChange={e => handleFileChange(rowId.toString(), e.target.files ? e.target.files[0] : null)}
                    />
                    {fileInputs[rowId.toString()] && <img src="/check-mark.svg" alt="Check Mark" style={{ color: 'black', marginLeft: '10px', width: '20px', height: '20px' }} />}
                    <button onClick={() => handleAddThumbnail(rowId.toString())}>Upload Thumbnail</button>
                </div>
            ))}
            {selectedRows.length > 1 && <button onClick={() => handleAddMultipleThumbnails()}>Upload Thumbnails</button>}
            {selectedRows.length > 1 ? selectedRows.map(rowId => (
                <div key={rowId} style={{ margin: '10px 0' }}>
                    <label style={{color:'black', margin: '20px'}}>ID = {rowId}</label>
                    <input
                        type="file"
                        accept=".pdf"
                        onChange={e => handlePdfFileChange(rowId.toString(), e.target.files ? e.target.files[0] : null)}
                        style={{width:'100px'}}
                    />
                    {pdfFileInputs[rowId.toString()] && <img src="/check-mark.svg" alt="Check Mark" style={{ color: 'black', marginLeft: '10px', width: '20px', height: '20px' }} />}
                </div>
            )) : selectedRows.map(rowId => (
                <div key={rowId} style={{ margin: '10px 0' }}>
                    <input
                        type="file"
                        accept=".pdf"
                        onChange={e => handlePdfFileChange(rowId.toString(), e.target.files ? e.target.files[0] : null)}
                    />
                    {pdfFileInputs[rowId.toString()] && <img src="/check-mark.svg" alt="Check Mark" style={{ color: 'black', marginLeft: '10px', width: '20px', height: '20px' }} />}
                    <button onClick={() => handleAddFile(rowId.toString())}>Upload Files</button>
                </div>
            ))}
            {selectedRows.length > 1 && <button onClick={() => handleAddMultipleFiles()}>Upload Files</button>}
        </>
    );
};

export default AdminBooksManagment;
