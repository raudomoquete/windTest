using AutoMapper;
using Condominio.Core.DTOs;
using Condominio.Core.Entities;
using Condominio.Core.Interfaces;
using Condominios.API.Responses;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Condominios.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly IClient _client;
        private readonly IMapper _mapper;

        public ClientsController(IClient client,
                                 IMapper mapper)
        {
            _client = client;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetClients()
        {
            var clients = _client.GetClients();
            var clientsDto = _mapper.Map<IEnumerable<ClientDto>>(clients);
            var response = new ApiResponse<IEnumerable<ClientDto>>(clientsDto);

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetClient(int id)
        {
            var client = await _client.GetClient(id);
            var clientDto = _mapper.Map<ClientDto>(client);
            var response = new ApiResponse<ClientDto>(clientDto);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post(ClientDto clientDto)
        {
            var client = _mapper.Map<Client>(clientDto);

            await _client.InsertClient(client);

            clientDto = _mapper.Map<ClientDto>(client);
            var response = new ApiResponse<ClientDto>(clientDto);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Put(int id, ClientDto clientDto)
        {
            var client = _mapper.Map<Client>(clientDto);
            client.Id = id;

            var result = await _client.UpdateClient(client);
            var response = new ApiResponse<bool>(result);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _client.DeleteClient(id);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }
    }
}
