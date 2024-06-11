import { API_BASE_URL } from '../constants/api';
import * as React from 'react';
import { useEffect, useState } from 'react';
import { DataGrid, GridColDef, GridPaginationModel } from '@mui/x-data-grid';
import { User, UsersResponse } from '../interfaces/User';

const AdminUsersManagment: React.FC = () => {
    const [users, setUsers] = useState<User[]>([]);
    const [paginationModel, setPaginationModel] = useState<GridPaginationModel>({ page: 0, pageSize: 10 });
    const [totalPages, setTotalPages] = useState<number>(0);
    //const [selectedRows, setSelectedRows] = useState<GridRowSelectionModel>([]);

    useEffect(() => {
        fetchUsers(paginationModel.page + 1, paginationModel.pageSize);
    }, [paginationModel]);

    const fetchUsers = async (page: number, size: number) => {
        try {
            const response = await fetch(`${API_BASE_URL}/User?pageNumber=${page}&pageSize=${size}`, { credentials: 'include' });
            const data: UsersResponse = await response.json();
            setUsers(data.list);
            setTotalPages(data.totalPages);
        } catch (error) {
            console.error('Error fetching users:', error);
        }
    };

    const handlePaginationModelChange = (newModel: GridPaginationModel) => {
        setPaginationModel(newModel);
    };

    // const handleSelectionChange = (newSelection: GridRowSelectionModel) => {
    //     setSelectedRows(newSelection);
    // };
    const handleSelectionChange = () => {

    };

    const columns: GridColDef[] = [
        { field: 'id', headerName: 'ID', width: 30 },
        { field: 'username', headerName: 'Username', width: 200 },
        { field: 'email', headerName: 'Email', width: 250 },
        { field: 'firstName', headerName: 'First Name', width: 120 },
        { field: 'lastName', headerName: 'Last Name', width: 120 },
        { field: 'phoneNumber', headerName: 'Phone Number', width: 120 },
        { field: 'role', headerName: 'Role', width: 130 },
        { field: 'booksToReturn', headerName: 'Books To Return', width: 130 },
    ];

    const rows = users.map(user => ({
        id: user.id,
        username: user.username,
        email: user.email,
        firstName: user.firstName,
        lastName: user.lastName,
        phoneNumber: user.phoneNumber,
        role: user.role,
        booksToReturn: user.booksToReturn
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
        </>
    );
};

export default AdminUsersManagment;
