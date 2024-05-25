import { API_BASE_URL } from '../constants/api';
import * as React from 'react';
import { useEffect, useState } from 'react';
import { Rental, RentalsResponse } from '../interfaces/Rental';
import { DataGrid, GridColDef, GridPaginationModel, GridRowSelectionModel } from '@mui/x-data-grid';
import { Box } from '@mui/material';
import { format } from 'date-fns';
import Dashboard from './Dashboard';

const UsersRentals: React.FC = () => {
  const [rentals, setRentals] = useState<Rental[]>([]);
  const [paginationModel, setPaginationModel] = useState<GridPaginationModel>({ page: 0, pageSize: 10 });
  const [totalPages, setTotalPages] = useState<number>(0);
  const [selectedRows, setSelectedRows] = useState<GridRowSelectionModel>([]);

  useEffect(() => {
    fetchRentals(paginationModel.page + 1, paginationModel.pageSize);
  }, [paginationModel]);

  const fetchRentals = async (page: number, size: number) => {
    try {
      const response = await fetch(`${API_BASE_URL}/Rental?pageNumber=${page}&pageSize=${size}`, { credentials: 'include' });
      const data: RentalsResponse = await response.json();
      setRentals(data.list);
      setTotalPages(data.totalPages);
    } catch (error) {
      console.error('Error fetching rentals:', error);
    }
  };

  const handlePaginationModelChange = (newModel: GridPaginationModel) => {
    setPaginationModel(newModel);
  };

  const handleSelectionChange = (newSelection: GridRowSelectionModel) => {
    setSelectedRows(newSelection);
  };

  const handleReturnBooks = async () => {
    for (const rentalId of selectedRows) {
        const rentalToProcess = rentals.find(x => x.id == rentalId);
        if (rentalToProcess?.isReturned) continue;
        
      try {
        const response = await fetch(`${API_BASE_URL}/Rental/${rentalId}/Return`, {
          method: 'POST',
          credentials: 'include'
        });
        const success = await response.json();
        if (success) {
          fetchRentals(paginationModel.page + 1, paginationModel.pageSize);
        } else {
          console.error(`Failed to return rental ${rentalId}.`);
        }
      } catch (error) {
        console.error(`Error returning rental ${rentalId}:`, error);
      }
    }
  };

  const formatDate = (dateString: string) => {
    return format(new Date(dateString), 'PPpp');
  };

  const columns: GridColDef[] = [
    { field: 'bookTitle', headerName: 'Book Title', width: 400 },
    { field: 'rentedBy', headerName: 'Rented By', width: 200 },
    { field: 'fromUtc', headerName: 'From', width: 200, valueFormatter: (params) => formatDate(params.value) },
    { field: 'toUtc', headerName: 'To', width: 200, valueFormatter: (params) => formatDate(params.value) },
    { field: 'isReturned', headerName: 'Returned', width: 130, type: 'boolean' },
  ];

  const rows = rentals.map(rental => ({
    id: rental.id,
    bookTitle: rental.bookTitle,
    rentedBy: rental.rentedBy,
    fromUtc: rental.fromUtc,
    toUtc: rental.toUtc,
    isReturned: rental.isReturned
  }));

  return (
    <>
      <Dashboard />
      <div style={{ height: 400, width: '100%' }}>
        <Box sx={{ bgcolor: '#ffffff' }}>
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
        </Box>
        {selectedRows.length > 0 ? <button onClick={handleReturnBooks}>{selectedRows.length > 1 ? "Return books" : "Return a book"}</button> : <></>}
      </div>
    </>
  );
};

export default UsersRentals;
