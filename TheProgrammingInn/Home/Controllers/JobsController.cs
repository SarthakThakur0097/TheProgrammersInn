using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Home.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Home.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobsController : ControllerBase
    {
        public IEnumerable<Job> GetJobs()
        {
            string jsonText = System.IO.File.ReadAllText("./Data/jobs.json");
            return JsonConvert.DeserializeObject<IEnumerable<Job>>(jsonText);
        }
    }
}
