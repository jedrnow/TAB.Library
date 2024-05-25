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
        </>
    );
};

export default AdminBooksManagment;