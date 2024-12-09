using ClinicWebApp.Models;

namespace ClinicWebApp.Services
{
    public interface IBookingService
    {
        void BookAppointment(Booking booking);
        List<Booking> GetAppointmentsByClinic(int clinicId);
        List<Booking> GetAppointmentsByPatient(int patientId);
    }
}