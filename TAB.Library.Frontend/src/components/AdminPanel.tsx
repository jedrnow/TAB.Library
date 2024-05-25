import * as React from 'react';
import { Box, Tab, Tabs, Typography } from '@mui/material';
import Dashboard from './Dashboard';
import AdminRentalsManagment from './AdminRentalsManagment';
import AdminBooksManagment from './AdminBooksManagment';

interface TabPanelProps {
    children?: React.ReactNode;
    index: number;
    value: number;
}
  
function CustomTabPanel(props: TabPanelProps) {
    const { children, value, index, ...other } = props;
  
    return (
      <div
        role="tabpanel"
        hidden={value !== index}
        id={`simple-tabpanel-${index}`}
        aria-labelledby={`simple-tab-${index}`}
        {...other}
      >
        {value === index && (

            <Typography>{children}</Typography>
        )}
      </div>
    );
}

function a11yProps(index: number) {
    return {
      id: `simple-tab-${index}`,
      'aria-controls': `simple-tabpanel-${index}`,
    };
}

const AdminPanel: React.FC = () => {
    const [value, setValue] = React.useState(0);

    const handleChange = (_event: React.SyntheticEvent, newValue: number) => {
        setValue(newValue);
    };

    return (
        <>
        <Dashboard />
        <div style={{ height: 400, width: '100%' }}>
            <Box sx={{ bgcolor: '#ffffff' }}>
                <Box sx={{ borderBottom: 1, borderColor: 'divider' }}>
                    <Tabs value={value} onChange={handleChange}>
                        <Tab label="Books" {...a11yProps(0)} />
                        <Tab label="Rentals" {...a11yProps(1)} />
                        <Tab label="Users" {...a11yProps(2)} />
                    </Tabs>
                </Box>
                <CustomTabPanel value={value} index={0}>
                    <AdminBooksManagment/>
                </CustomTabPanel>
                <CustomTabPanel value={value} index={1}>
                    <AdminRentalsManagment/>
                </CustomTabPanel>
                <CustomTabPanel value={value} index={2}>
                    Item Three
                </CustomTabPanel>
            </Box>
        </div>
        </>
    );
};

export default AdminPanel;
