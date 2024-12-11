using ClinicWebApp.Models;

namespace ClinicWebApp.Services
{
    public interface IClinicService
    {
        void AddClinic(Clinic clinic);
        IEnumerable<Clinic> GetAllClinics();
        Clinic GetClinicById(int clinicId);
        void RemoveClinicByName(string specialization);
    }
}