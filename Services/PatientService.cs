using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DDSProject.Models;
using DDSProject.Interfaces;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Fluent;
using Microsoft.Extensions.Configuration;

namespace DDSProject.Services
{
    public class PatientService : IPatientService
    {
        private Container _container;

        public PatientService(
            CosmosClient dbClient,
            string databaseName,
            string containerName)
        {
            this._container = dbClient.GetContainer(databaseName, containerName);
        }
        
        public async Task AddItemAsync(Patient item)
        {
            await this._container.CreateItemAsync<Patient>(item, new PartitionKey(item.Id));
        }

        public async Task DeleteItemAsync(string id)
        {
            await this._container.DeleteItemAsync<Patient>(id, new PartitionKey(id));
        }

        public async Task<Patient> GetItemAsync(string id)
        {
            try
            {
                ItemResponse<Patient> response = await this._container.ReadItemAsync<Patient>(id, new PartitionKey(id));
                return response.Resource;
            }
            catch(CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            { 
                return null;
            }

        }

        public async Task<IEnumerable<Patient>> GetItemsAsync(string queryString)
        {
            var query = this._container.GetItemQueryIterator<Patient>(new QueryDefinition(queryString));
            List<Patient> results = new List<Patient>();
            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();
                
                results.AddRange(response.ToList());
            }

            return results;
        }

        public async Task UpdateItemAsync(string id, Patient item)
        {
            await this._container.UpsertItemAsync<Patient>(item, new PartitionKey(id));
        }
    }
}