using AutoMapper;
using Condominio.Core.DTOs;
using Condominio.Core.Entities;
using Condominio.Core.Interfaces;
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
    public class StatusController : ControllerBase
    {
        private readonly IStatus _status;
        private readonly IMapper _mapper;

        public StatusController(IStatus status,
                                 IMapper mapper)
        {
            _status = status;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Post(StatusDto statusDto)
        {
            var status = _mapper.Map<Status>(statusDto);

            await _status.InsertStatus(status);

            statusDto = _mapper.Map<StatusDto>(status);
            var response = new ApiResponse<StatusDto>(statusDto);
            return Ok(response);
        }
    }
}
