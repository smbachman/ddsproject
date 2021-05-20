using System.Collections.Generic;
using DDSProject.Models;
using DDSProject.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;

namespace DDSProject.Controllers 
{
    [Route("api/[controller]")]
    [ApiController]
    [BasicAuth("DDS")]
    public class PatientsController : ControllerBase
    {
        private readonly IPatientService _patientService;
        
        public PatientsController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Patient>> Get(string id)
        {
            Console.WriteLine($"Requested id: {id}");
            return await _patientService.GetItemAsync(id);
        } 

        [HttpGet]
        public async Task<IEnumerable<Patient>> Get()
            => await _patientService.GetItemsAsync("SELECT * FROM c");

        [HttpPost]
        public async Task<ActionResult<Patient>> Create(Patient patient)
        {
            patient.Id = Guid.NewGuid().ToString();

            await _patientService.AddItemAsync(patient);
            
            return patient;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, Patient patient)
        {
            await _patientService.UpdateItemAsync(id, patient);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _patientService.DeleteItemAsync(id);

            return NoContent();
        }
    }
}