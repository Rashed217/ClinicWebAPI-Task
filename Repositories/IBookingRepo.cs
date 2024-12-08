using ClinicWebApp.Models;

namespace ClinicWebApp.Repositories
{
    public interface IBookingRepo
    {
        Task BookAppointmentAsync(Booking booking);
        Task<IEnumerable<Booking>> GetAppointmentsByClinicAsync(int clinicId);
        Task<IEnumerable<Booking>> GetAppointmentsByPatientAsync(int patientId);
    }
}
