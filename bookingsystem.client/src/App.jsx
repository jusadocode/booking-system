import { useEffect, useState } from 'react';
import { Container, Button, Typography, Box } from '@mui/material';
import HotelList from './components/HotelList';
import { fetchHotels } from './services/hotelService';
import { BrowserRouter as Router, Link } from 'react-router-dom';
import './App.css';

function App() {
    const [hotels, setHotels] = useState([]);

    useEffect(() => {
        populateHotelData();
    }, []);

    return (
        <Container maxWidth='md' sx={{ display: 'flex', flexDirection: 'column', alignItems: 'flex-start', py: 4 }}>
            <Typography variant="h4" gutterBottom>
                <strong>Booking system</strong>
            </Typography>

            <Typography variant="body1" gutterBottom>
            Technical assignment for a candidate for an internship developer position at the BDT team
            </Typography>

            <Box display='flex' justifyContent='space-between' width='100%' my={2}>
                <Button variant="outlined" component={Link} to='/'>
                    My Account
                </Button>
                <Button variant="outlined" component={Link} to='/bookings'>
                    My Bookings
                </Button>
                <Button variant="outlined" component="a" href='https://github.com/jusadocode' target='_blank' rel='noopener noreferrer'>
                    Github
                </Button>
                <Button variant="outlined" component="a" href='https://presentconnection.eu/' target='_blank' rel='noopener noreferrer'>
                    Present Connection
                </Button>
            </Box>

            <Typography variant="h3" gutterBottom>
                Search for a place to stay
            </Typography>
            <Typography variant="body1" gutterBottom>
                We provide a variety of options for all kinds of customer needs.
            </Typography>

            <Container sx={{ minWidth: '50vw', minHeight: '80vh' }}>
                <HotelList hotels={hotels} />
            </Container>
        </Container>
    );

    async function populateHotelData() {
        const data = await fetchHotels();
        setHotels(data);
    }
}

export default App;
