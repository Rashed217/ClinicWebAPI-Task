using ClinicWebApp.Models;

namespace ClinicWebApp.Services
{
    public interface IBookingService
    {
        void BookAppointment(Booking booking);
        List<Booking> GetAppointmentsByClinic(int clinicId);
        IEnumerable<Booking> GetAppointmentsByPatientName(string patientName);
        List<Booking> GetAppointmentsByPatient(int patientId);
    }
}