using EADBackend.Models;
using EADBackend.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EADBackend.Controllers
{
    [Controller]
    [Route("api/[controller]")]
    public class StationController : Controller
    {
        private readonly StationService _stationServices;


        public StationController(StationService stationService)
        {
            _stationServices = stationService;
        }

        [HttpGet]
        public async Task<List<Station>> getStations()
        {
            return await _stationServices.GetstationsAsync();

        }

        [HttpPost]
        public async Task<IActionResult> addStation([FromBody] Station station)
        {
            await _stationServices.CreateStationAsync(station);
            return CreatedAtAction(nameof(getStations), new { id = station.Id }, station);
        }

        [HttpPut("Icarquque/{id}")]
        public async Task<IActionResult> updateCarQuque(string id, [FromBody] Station station)
        {
            await _stationServices.IncrementCars_ququeAsync(id, station);
            return NoContent();

        }

        [HttpPut("updatePetrolAvailability/{id}")]
        public async Task<IActionResult> updatePetralAvailabity(string id, [FromBody] Station station)
        {
            await _stationServices.Update_Petrol_AvailabilityAsync(id, station);
            return NoContent();

        }

        [HttpPut("updateDieselAvailability/{id}/")]
        public async Task<IActionResult> updateDieselAvailabity(string id, [FromBody] Station station)
        {
            await _stationServices.Update_diesel_AvailabilityAsync(id, station);
            return NoContent();

        }

        //update queque incemently

        [HttpPut("Iquque/{id}/{quque}")]
        public async Task<IActionResult> updateIQuque(string id,string quque, [FromBody] Station station)
        {
            await _stationServices.IncrementququeAsync(id, quque, station);
            return NoContent();

        }


        [HttpPut("Dquque/{id}/{quque}")]
        public async Task<IActionResult> updateDeQuque(string id, string quque, [FromBody] Station station)
        {
            await _stationServices.DecrementququeAsync(id, quque, station);
            return NoContent();

        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> deleteStation(string id)
        {

            await _stationServices.DeleteStationAsync(id);
            return NoContent();
        }

        [HttpGet("serachStation/{StationId}")]
        public async Task<Station> searchStations(int StationId)
        {
            return await _stationServices.SearchstationsAsync(StationId);

        }
    }
}
