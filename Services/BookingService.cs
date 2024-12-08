using ClinicWebApp.Models;
using ClinicWebApp.Repositories;

namespace ClinicWebApp.Services
{
    // BookingService class implements the IBookingService interface
    // It acts as a service layer, interacting with the IBookingRepo (repository) to manage booking-related operations.
    public class BookingService : IBookingService
    {
        // IBookingRepo instance used to interact with the repository layer for booking operations
        private readonly IBookingRepo _bookingRepo;

        // Constructor that accepts an IBookingRepo and initializes the _bookingRepo field
        // This allows dependency injection of the booking repository into the service
        public BookingService(IBookingRepo bookingRepo)
        {
            _bookingRepo = bookingRepo;
        }

        // Method to book an appointment by delegating the operation to the repository
        public Task BookAppointment(Booking booking)
        {
            // Calls the BookAppointmentAsync method of the booking repository
            return _bookingRepo.BookAppointmentAsync(booking);
        }

        // Method to retrieve all appointments for a specific clinic by delegating the operation to the repository
        public Task<IEnumerable<Booking>> GetAppointmentsByClinic(int clinicId)
        {
            // Calls the GetAppointmentsByClinicAsync method of the booking repository
            return _bookingRepo.GetAppointmentsByClinicAsync(clinicId);
        }

        // Method to retrieve all appointments for a specific patient by delegating the operation to the repository
        public Task<IEnumerable<Booking>> GetAppointmentsByPatient(int patientId)
        {
            // Calls the GetAppointmentsByPatientAsync method of the booking repository
            return _bookingRepo.GetAppointmentsByPatientAsync(patientId);
        }

    }

}
