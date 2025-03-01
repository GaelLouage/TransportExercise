using apiOef14._6.Helpers;
using apiOef14._6.Models;
using apiOef14._6.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using System.Text;

namespace apiOef14._6.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EnqueteController : ControllerBase
    {
        private int[,] enqueteData = new int[5,4];
        private readonly ILogger<EnqueteController> _logger;
        private List<EnqueteEntity>? _enqueteEntities;
        private readonly IJsonService<EnqueteEntity> _enqueteService;
        public EnqueteController(ILogger<EnqueteController> logger, IJsonService<EnqueteEntity> enqueteService)
        {
            _logger = logger;
            _enqueteService = enqueteService;
        }

        [HttpGet("GetEnquete")]
        public async Task<IActionResult> GetEnquete()
        {
            await PopulateEnquetes();

            TransportHelpers.PopulateEnquetes(_enqueteEntities, enqueteData);

            var sb = new StringBuilder();
            var year = 1960;
            for (int i = 0; i < enqueteData.GetLength(0); i++)
            {
                sb.AppendLine($"< {year} {enqueteData[i, 0]} {enqueteData[i, 1]} {enqueteData[i, 2]} {enqueteData[i, 3]}");
                year += 10;
            }
            return Ok(sb.ToString());
        }

        [HttpGet("GetByYear")]
        public async Task<IActionResult> GetByYear(int year)
        {
            await PopulateEnquetes();
            var byYear = _enqueteEntities.Where(x => x.Year <= year);
            return Ok(byYear);
        }


        private async Task PopulateEnquetes()
        {
            if (_enqueteEntities is null)
            {
                _enqueteEntities = await _enqueteService.GetJson(@"C:\Users\louag\OneDrive\Bureau\all deskoptfiles and shortcuts\oef opleiding\14.6\Enquete.json");
            }

        }
    }
}
