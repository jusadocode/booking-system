/* eslint-disable react/prop-types */
import * as React from 'react';
import { useState, useEffect } from 'react';
import { Box } from '@mui/material';
import Stepper from '@mui/material/Stepper';
import Step from '@mui/material/Step';
import StepLabel from '@mui/material/StepLabel';
import Button from '@mui/material/Button';
import Typography from '@mui/material/Typography';
import DoneIcon from '@mui/icons-material/Done';
import dayjs from 'dayjs';
import isSameOrAfter from 'dayjs/plugin/isSameOrAfter';

import { Dialog, DialogTitle } from '@mui/material';
import CheckInStep from './CheckInStep';
import ExtraStep from './ExtraStep';
import FinalStep from './FinalStep';
import { addBooking } from '../services/bookingService';


dayjs.extend(isSameOrAfter);

const steps = ['Select dates', 'Extra services', 'Finalize booking'];

export default function BookingDialog({ open, selectedRoom, handleCloseDialog, expandedHotel }) {


    useEffect(() => {
        if (!open) {
            // Reset state when dialog is closed
            setActiveStep(0);
            setSkipped(new Set());
            setBookingDates([dayjs(), dayjs()]);
            setBreakfastRequests(0);
        }
    }, [open]);


    const [activeStep, setActiveStep] = useState(0);
    const [skipped, setSkipped] = useState(new Set());

    const isStepOptional = (step) => {
        return step === 1;
    };

    const isStepSkipped = (step) => {
        return skipped.has(step);
    };

    const handleNext = () => {
        let newSkipped = skipped;
        if (isStepSkipped(activeStep)) {
            newSkipped = new Set(newSkipped.values());
            newSkipped.delete(activeStep);
        }
        if(activeStep === 0) {
           const datesValid = validateDates();
           if(!datesValid)
            return;
        }
        if(activeStep === steps.length - 1) {
            handleBooking();
         }


        setActiveStep((prevActiveStep) => prevActiveStep + 1);
        setSkipped(newSkipped);
    };

    const handleBack = () => {
        setActiveStep((prevActiveStep) => prevActiveStep - 1);
    };

    const validateDates = () => {
        const [checkInDate, checkOutDate] = bookingDates;
        if (!checkInDate.isValid() || !checkOutDate.isValid()) {
            return false;
        }
        if (checkInDate.isSameOrAfter(checkOutDate)) {
            return false;
        }
        return true;
    };


    const handleBooking = async () => {

        const newBooking = {
            checkInDate: bookingDates[0].toISOString().split('T')[0],
            checkOutDate: bookingDates[1].toISOString().split('T')[0],
            room: selectedRoom,
            hotel: expandedHotel,
            breakfastRequests: breakfastRequests
        };

        await addBooking(newBooking)
    };

    const handleSkip = () => {
        if (!isStepOptional(activeStep)) {
            throw new Error("You can't skip a step that isn't optional.");
        }

        setActiveStep((prevActiveStep) => prevActiveStep + 1);
        setSkipped((prevSkipped) => {

            if(activeStep === 1) 
                setBreakfastRequests(0);
            
            const newSkipped = new Set(prevSkipped.values());
            newSkipped.add(activeStep);
            return newSkipped;
        });
    };


    const [bookingDates, setBookingDates] = useState([dayjs(), dayjs(),])

    const [breakfastRequests, setBreakfastRequests] = useState(0)

    return (
        <Dialog open={open} onClose={handleCloseDialog} maxWidth="lg" fullWidth>
            <DialogTitle>Book a room</DialogTitle>

            <Box sx={{ width: '90%', px: 5, py: 5 }} >
                <Stepper activeStep={activeStep}>
                    {steps.map((label, index) => {
                        const stepProps = {};
                        const labelProps = {};
                        if (isStepOptional(index)) {
                            labelProps.optional = (
                                <Typography variant="caption">Optional</Typography>
                            );
                        }
                        if (isStepSkipped(index)) {
                            stepProps.completed = false;
                        }
                        return (
                            <Step key={label} {...stepProps}>
                                <StepLabel {...labelProps}>{label}</StepLabel>
                            </Step>
                        );
                    })}
                </Stepper>
                {activeStep === steps.length ? (
                    <React.Fragment>
                        <Typography sx={{ my: 2 }}>
                            Room successfully booked
                            <DoneIcon fontSize='medium' />
                        </Typography>
                        <Typography sx={{ my: 2 }}>
                            You can continue browsing the hotels
                        </Typography>
                        <Typography sx={{ my: 2 }}>
                            You will be able to check your bookings in My Bookings section
                        </Typography>
                        <Box sx={{ display: 'flex', flexDirection: 'row', pt: 2 }}>
                            <Box sx={{ flex: '1 1 auto' }} />
                            <Button onClick={handleCloseDialog}>Continue</Button>
                        </Box>
                    </React.Fragment>
                ) : (
                    <React.Fragment>
                        {activeStep === 0 && (
                            <CheckInStep bookingDates={bookingDates} setBookingDates={setBookingDates} />
                        )}
                        {activeStep === 1 && (
                            <ExtraStep selectedRoom={selectedRoom} breakfastRequests={breakfastRequests} setBreakfastRequests={setBreakfastRequests} />
                        )}
                        {activeStep === 2 && (
                            <FinalStep selectedRoom={selectedRoom} bookingDates={bookingDates} breakfastRequests={breakfastRequests} expandedHotel={expandedHotel} />
                        )}
                        <Box sx={{ display: 'flex', flexDirection: 'row', pt: 2 }}>
                            <Button
                                color="inherit"
                                disabled={activeStep === 0}
                                onClick={handleBack}
                                sx={{ mr: 1 }}
                            >
                                Back
                            </Button>
                            <Box sx={{ flex: '1 1 auto' }} />
                            {isStepOptional(activeStep) && (
                                <Button color="inherit" onClick={handleSkip} sx={{ mr: 1 }}>
                                    Skip
                                </Button>
                            )}
                            <Button variant='contained' onClick={handleNext}>
                                {activeStep === steps.length - 1 ? 'Finalize booking' : 'Next'}
                            </Button>
                        </Box>
                    </React.Fragment>
                )}
            </Box>
        </Dialog >
    );
}