﻿using Microsoft.AspNetCore.Mvc;
using MonoProject.API.Models;
using MonoProject.Common.Models;
using MonoProject.Service.Common;
using System;
using System.Threading.Tasks;

namespace MonoProject.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VehicleMakeController : ControllerBase
    {
        private readonly IVehicleMakeService vehicleMakeService;

        public VehicleMakeController(IVehicleMakeService vehicleMakeService)
        {
            this.vehicleMakeService = vehicleMakeService;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetVehicleMakeAsync([FromQuery] Guid id)
        {
            var vehicleMake = await vehicleMakeService.GetAsync(id);

            if (vehicleMake == null)
            {
                return BadRequest();
            }

            return Ok(vehicleMake);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllVehicleMakeAsync(string searchBy, string search, string sortOrder, string sortBy, int? pageNumber, int? pageSize)
        {
            var filtering = new Filtering(searchBy, search);
            var paging = new Paging(pageNumber, pageSize);
            var sorting = new Sorting(sortOrder, sortBy);

            var response = new PagedResult<VehicleMakeDTO, object>()
            {
                Data = await vehicleMakeService.GetAllAsync(filtering, paging, sorting),
                Filtering = filtering,
                Pagination = paging,
                Sorting = sorting,
            };

            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<ActionResult> PostVehicleMakeAsync([FromBody] VehicleMakeDTO vehicleMakeDTO)
        {
            try
            {
                var result = await vehicleMakeService.AddAsync(vehicleMakeDTO);

                if (result == 0)
                {
                    return BadRequest();
                }

                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateVehicleMakeAsync([FromBody] VehicleMakeDTO vehicleMakeDTO)
        {
            var vehicleGet = await vehicleMakeService.GetAsync(vehicleMakeDTO.Id.Value);

            if (vehicleGet == null)
            {
                return BadRequest();
            }

            await vehicleMakeService.UpdateAsync(vehicleMakeDTO);

            return Ok();
        }

        [HttpDelete("[action]")]
        public async Task<ActionResult> DeleteVehicleMakeAsync([FromQuery] Guid id)
        {
            await vehicleMakeService.DeleteAsync(id);

            return Ok();
        }
    }
}
