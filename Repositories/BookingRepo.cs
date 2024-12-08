using ClinicWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ClinicWebApp.Repositories
{
    // BookingRepo class implements the IBookingRepo interface
    // It is responsible for interacting with the ApplicationDbContext to perform CRUD operations on the Booking data.
    public class BookingRepo : IBookingRepo
    {
        // ApplicationDbContext instance used to interact with the database
        private readonly ApplicationDbContext _context;

        // Constructor that accepts an ApplicationDbContext and initializes the _context field
        // This allows dependency injection of the database context into the repository
        public BookingRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        // Method to book an appointment by adding a new Booking to the database
        public async Task BookAppointmentAsync(Booking booking)
        {
            // Ensure that the number of available slots in the associated clinic is not exceeded
            var clinic = await _context.Clinics.FindAsync(booking.ClinicID);

            // If the clinic exists and has available slots, proceed to book the appointment
            if (clinic != null && clinic.NumberOfSlots > 0)
            {
                // Adds the booking entity to the Bookings DbSet asynchronously
                await _context.Bookings.AddAsync(booking);

                // Decreases the available slots in the clinic by one
                clinic.NumberOfSlots--;

                // Saves the changes to the database asynchronously
                await _context.SaveChangesAsync();
            }
        }

        // Method to retrieve all appointments (bookings) for a specific clinic asynchronously
        public async Task<IEnumerable<Booking>> GetAppointmentsByClinicAsync(int clinicId)
        {
            // Retrieves all bookings for the given clinic ID, including the associated patient information
            return await _context.Bookings
                .Where(b => b.ClinicID == clinicId) // Filters by clinic ID
                .Include(b => b.Patient)            // Includes the related Patient data
                .ToListAsync();                     // Converts the result to a list asynchronously
        }

        // Method to retrieve all appointments (bookings) for a specific patient asynchronously
        public async Task<IEnumerable<Booking>> GetAppointmentsByPatientAsync(int patientId)
        {
            // Retrieves all bookings for the given patient ID, including the associated clinic information
            return await _context.Bookings
                .Where(b => b.PatientID == patientId) // Filters by patient ID
                .Include(b => b.Clinic)               // Includes the related Clinic data
                .ToListAsync();                       // Converts the result to a list asynchronously
        }
    }
}
