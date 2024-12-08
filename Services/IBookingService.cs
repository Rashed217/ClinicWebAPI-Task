using ClinicWebApp.Models;

namespace ClinicWebApp.Services
{
    public interface IBookingService
    {
        Task BookAppointment(Booking booking);
        Task<IEnumerable<Booking>> GetAppointmentsByClinic(int clinicId);
        Task<IEnumerable<Booking>> GetAppointmentsByPatient(int patientId);
    }
}