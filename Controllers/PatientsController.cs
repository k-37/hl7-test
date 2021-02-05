using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Hl7.Fhir.Rest;
using Hl7.Fhir.Model;

namespace hl7Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        // GET: api/Patients
        [HttpGet]
        public ActionResult<Bundle> GetPatients()
        {
            var settings = new FhirClientSettings
            {
                Timeout = 10,
                PreferredFormat = ResourceFormat.Json,
                VerifyFhirVersion = true,
                PreferredReturn = Prefer.ReturnMinimal
            };

            var client = new FhirClient("http://fhir.healthintersections.com.au/open", settings);
            Bundle results = client.Search<Patient>(new string[] { "family:exact=Eve" });

            return results;
        }
    }
}
