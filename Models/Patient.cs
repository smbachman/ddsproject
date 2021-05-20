using System;
using Newtonsoft.Json;

namespace DDSProject.Models 
{
    public class Patient
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "socialSecurityNumber")]
        public string SocialSecurityNumber { get; set; }
        
        [JsonProperty(PropertyName = "firstName")]
        public string FirstName { get; set; }
        
        [JsonProperty(PropertyName = "lastName")]
        public string LastName { get; set; }
        
        [JsonProperty(PropertyName = "dateOfBirth")]
        public DateTime DateOfBirth { get; set; }
    }
}