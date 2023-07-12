using RegistrationMedicineProject.Shared;

namespace RegistrationMedicineProject.Client.Services.RegistrationMedicineService
{
    public interface IRegistrationMedicineService
    {
        List<RegistrationMedicine> Medicines { get; set; }
        List<Retention> Retentions { get; set; }
        Task GetRetentions();
        Task GetRegistrationMedicines();
        Task<RegistrationMedicine> GetSingleMedicine(int id);
        Task CreateMedicine(RegistrationMedicine medicine);
        Task UpdateMedicine(RegistrationMedicine medicine);
        Task DeleteMedicine(int id);
    }
}
 