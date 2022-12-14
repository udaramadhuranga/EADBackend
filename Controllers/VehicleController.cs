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
    public class VehicleController : Controller
    {
        private readonly MongoDBServices _mongodbService;


        public VehicleController(MongoDBServices mongoDBServices)
        {
            _mongodbService = mongoDBServices;
        }

        [HttpGet]
        public async Task<List<Vehicle>> getVehicle()  //api for get all vehicles
        {
            return await _mongodbService.GetVehiclesAsync();

        }

        [HttpPost]
        public async Task<IActionResult> addVehicle([FromBody] Vehicle vehicle) //api for create vehicle category
        {
            await _mongodbService.CreateVehicleAsync(vehicle);
            return CreatedAtAction(nameof(getVehicle), new { id = vehicle.Id }, vehicle);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> updateVehicle(string id, [FromBody] Vehicle vehicle) //api for update vehicle category
        {
            await _mongodbService.UpdateVehicleAsync(id, vehicle);
            return NoContent(); 

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> deleteVehicle(string id) //api for delete vehicle chategory.
        {

            await _mongodbService.DeleteVehicleAsync(id);
            return NoContent();
        }

       
    }
}
