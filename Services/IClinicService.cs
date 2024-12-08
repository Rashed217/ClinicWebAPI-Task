using ClinicWebApp.Models;

namespace ClinicWebApp.Services
{
    public interface IClinicService
    {
        void AddClinic(Clinic clinic);
        IEnumerable<Clinic> GetAllClinics();
        void GetClinicById(int clinicId);
    }
}