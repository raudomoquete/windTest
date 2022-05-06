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
    public class DuesController : ControllerBase
    {
        private readonly IDue _dueService;
        private readonly IMapper _mapper;
        private readonly IPayment _paymentService;


        public DuesController(IDue dueService,
                              IMapper mapper,
                              IPayment payment)
        {
            _dueService = dueService;
            _mapper = mapper;
            _paymentService = payment;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDue(int id)
        {
            var due = await _dueService.GetDue(id);
            var dueDto = _mapper.Map<DueDto>(due);
            var response = new ApiResponse<DueDto>(dueDto);

            return Ok(response);
        }

        [HttpGet]
        public IActionResult GetDues()
        {
            var dues = _dueService.GetDues();
            var duesDto = _mapper.Map<IEnumerable<DueDto>>(dues);
            var response = new ApiResponse<IEnumerable<DueDto>>(duesDto);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post(DueDto dueDto)
        {
            var due = _mapper.Map<Due>(dueDto);

            await _dueService.InsertDue(due);

            dueDto = _mapper.Map<DueDto>(due);
            var response = new ApiResponse<DueDto>(dueDto);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Put(int id, DueDto dueDto)
        {
            var due = _mapper.Map<Due>(dueDto);
            due.Id = id;

            var result = await _dueService.UpdateDue(due);
            var response = new ApiResponse<bool>(result);

            return Ok(response);
        }
    }
}
