using AutoMapper;
using Condominio.Core.DTOs;
using Condominio.Core.Entities;
using Condominio.Core.Interfaces;
using Condominio.Infrastructure.Repositories;
using Condominios.API.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Condominios.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResidentialController : ControllerBase
    {

        private readonly IResidential _residentialService;
        private readonly IMapper _mapper;


        public ResidentialController(IResidential residentialService,
                                       IMapper mapper)
        {
            _residentialService = residentialService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetPosts()
        {
            var residentials = _residentialService.GetResidentials();
            var residentialsDto = _mapper.Map<IEnumerable<ResidentialDto>>(residentials);
            var response = new ApiResponse<IEnumerable<ResidentialDto>>(residentialsDto);

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetResidential(int id)
        {
            var residential = await _residentialService.GetResidential(id);
            var residentialDto = _mapper.Map<ResidentialDto>(residential);
            var response = new ApiResponse<ResidentialDto>(residentialDto);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post(ResidentialDto residentialDto)
        {
            var residential = _mapper.Map<Residential>(residentialDto);

            await _residentialService.InsertResidential(residential);

            residentialDto = _mapper.Map<ResidentialDto>(residential);
            var response = new ApiResponse<ResidentialDto>(residentialDto);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Put(int id, ResidentialDto residentialDto)
        {
            var residential = _mapper.Map<Residential>(residentialDto);
            residential.Id = id;

            var result = await _residentialService.UpdateResidential(residential);
            var response = new ApiResponse<bool>(result);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _residentialService.DeleteResidential(id);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }
    }
}
