using CallCenter.Models;

namespace CallCenter.Repository
{
    public interface ITechnicianRepository{
        Task AddTechnician(Technician technician);
        Task UpdateTechnician(Technician technician);
        Task<List<Technician>> GetAllTechnicians();
        Task<Technician> GetTechnicianById(Guid technicianId);
        Task<Technician> GetTechnicianByEmployeeId(Guid employeeId);
        Task<List<Technician>> GetTechnicianBySkillLevel(int skillLevel);
        Task<List<Technician>> GetTechnicianByServiceArea(string serviceArea);
        Task<List<Technician>> GetTechnicianByAvailability(string availability);
        Task<List<Technician>> GetTechnicianByCertificationLevel(string certificationLevel);
    }
}