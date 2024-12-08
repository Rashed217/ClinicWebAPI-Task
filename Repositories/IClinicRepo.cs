using ClinicWebApp.Models;

namespace ClinicWebApp.Repositories
{
    public interface IClinicRepo
    {
        void AddClinic(Clinic clinic);
        IEnumerable<Clinic> GetAllClinics();
        Clinic GetClinicById(int clinicId);
    }
}