using System.Collections.Generic;
using System.Threading.Tasks;
using DDSProject.Models;

namespace DDSProject.Interfaces
{
    public interface IPatientService
    {
        Task<IEnumerable<Patient>> GetItemsAsync(string query);
        Task<Patient> GetItemAsync(string id);
        Task AddItemAsync(Patient item);
        Task UpdateItemAsync(string id, Patient item);
        Task DeleteItemAsync(string id);
    }
}