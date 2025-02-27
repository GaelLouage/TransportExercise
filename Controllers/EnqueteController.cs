using apiOef14._6.Helpers;
using apiOef14._6.Models;
using apiOef14._6.Services.Classes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using System.Text;

namespace apiOef14._6.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EnqueteController : ControllerBase
    {
        private int[,] enqueteData = new int[5,4];
        private readonly ILogger<EnqueteController> _logger;
        private readonly IJsonService<EnqueteEntity> _enqueteService;
        public EnqueteController(ILogger<EnqueteController> logger, IJsonService<EnqueteEntity> enqueteService)
        {
            _logger = logger;
            _enqueteService = enqueteService;
        }

        [HttpGet(Name = "GetEnquete")]
        public async Task<IActionResult> Get()
        {
            var enquetes = await _enqueteService.GetJson(@"C:\Users\louag\OneDrive\Bureau\all deskoptfiles and shortcuts\oef opleiding\14.6\Enquete.json");
            foreach (var enquete in enquetes) 
            {
                if(enquete.Year < 1960)
                {
                   TransportHelpers.SetTransPortValues(enquete, enqueteData, 0);
                }
                else if(enquete.Year < 1970)
                {
                    TransportHelpers.SetTransPortValues(enquete, enqueteData, 1);
                }
                else if(enquete.Year < 1980)
                {
                    TransportHelpers.SetTransPortValues(enquete, enqueteData, 2);
                }
                else if(enquete.Year < 1990)
                {
                    TransportHelpers.SetTransPortValues(enquete, enqueteData, 3);
                }
                else
                {
                    TransportHelpers.SetTransPortValues(enquete, enqueteData, 4);
                }
            }
            var sb = new StringBuilder();
            var year = 1960;
            for (int i = 0; i < enqueteData.GetLength(0);i++)
            {
                sb.AppendLine($"< {year} {enqueteData[i,0]} {enqueteData[i, 1]} {enqueteData[i, 2]} {enqueteData[i, 3]}");
                year += 10;
            }
            return Ok(sb.ToString());
        }
    }
}
