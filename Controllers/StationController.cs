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
        public async Task<IActionResult> getStations()   // api intergartion for get all stations
        {
            //return await _stationServices.GetstationsAsync();

            List<Station> stationlist = await _stationServices.GetstationsAsync();
            if (stationlist != null)
            {
                return Ok(new { success = true, data = stationlist, msg = "data retrive success" });
            }
            else {
                return BadRequest(new { success = true, data = stationlist, msg = "data retrive failed " });
            }
        }

        [HttpPost]
        public async Task<IActionResult> addStation([FromBody] Station station)  //api implentation for station create
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
        public async Task<IActionResult> updatePetralAvailabity(string id, [FromBody] Station station) // api inplemetation for petrol avalabity state change
        {
            await _stationServices.Update_Petrol_AvailabilityAsync(id, station);
            return NoContent();

        }

        [HttpPut("updateDieselAvailability/{id}/")]
        public async Task<IActionResult> updateDieselAvailabity(string id, [FromBody] Station station)// api inplemetation for diseal avalabity state change
        {
            await _stationServices.Update_diesel_AvailabilityAsync(id, station);
            return NoContent();

        }

        // api forupdate queque incemently

        [HttpPut("Iquque/{id}/{quque}")]
        public async Task<IActionResult> updateIQuque(string id,string quque, [FromBody] Station station) 
        {
            await _stationServices.IncrementququeAsync(id, quque, station);
            return NoContent();

        }


        [HttpPut("Dquque/{id}/{quque}")]
        public async Task<IActionResult> updateDeQuque(string id, string quque, [FromBody] Station station) //api for decrement vehicle quque
        {
            await _stationServices.DecrementququeAsync(id, quque, station);
            return Ok(new { success = true, data = id, msg = "data updated success" });

        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> deleteStation(string id) // api implementation for delete station
        {

            await _stationServices.DeleteStationAsync(id);
            return Ok(new { success = true, data = id, msg = "data deleted success" });
        }

        [HttpGet("serachStation/{StationId}")]
        public async Task<IActionResult> searchStations(int StationId) //api implelement for search a station facilities user to search station by station id
        {
            //return await _stationServices.SearchstationsAsync(StationId);

            Station station = await _stationServices.SearchstationsAsync(StationId);
            if (station != null)
            {
                return Ok(new { success = true, data = station, msg = "data retrive success" });
            }
            else
            {
                return BadRequest(new { success = true, data = station, msg = "data retrive failed " });
            }

        }

        [HttpGet("ownerstations/{ownerid}")]
        public async Task<IActionResult> getStationsofOwner(string ownerid) // api implementation for get all station of a owner
        {
            //return await _stationServices.GetstationsAsync();

            List<Station> stationlist = await _stationServices.getstationsofownerAsync(ownerid);
            if (stationlist != null)
            {
                return Ok(new { success = true, data = stationlist, msg = "data retrive success" });
            }
            else
            {
                return BadRequest(new { success = true, data = stationlist, msg = "data retrive failed " });
            }
        }
    }
}
