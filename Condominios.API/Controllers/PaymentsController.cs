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
    public class PaymentsController : ControllerBase
    {
        private readonly IPayment _paymentService;
        private readonly IMapper _mapper;

        public PaymentsController(IPayment payment,
                                   IMapper mapper)
        {
            _paymentService = payment;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetPayments()
        {
            var payments = _paymentService.GetPayments();
            var paymentsDto = _mapper.Map<IEnumerable<PaymentDto>>(payments);
            var response = new ApiResponse<IEnumerable<PaymentDto>>(paymentsDto);

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPayment(int id)
        {
            var payment = await _paymentService.GetPayment(id);
            var paymentDto = _mapper.Map<PaymentDto>(payment);
            var response = new ApiResponse<PaymentDto>(paymentDto);

            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetPaymentByStatus(Status status)
        {
            var payment =  await _paymentService.GetPaymentByStatus(status);
            var paymentDto = _mapper.Map<IEnumerable<PaymentDto>>(payment);
            var response = new ApiResponse<IEnumerable<PaymentDto>>(paymentDto);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post(PaymentDto paymentDto)
        {
            var payment = _mapper.Map<Payment>(paymentDto);

            await _paymentService.AddPayment(payment);

            paymentDto = _mapper.Map<PaymentDto>(payment);
            var response = new ApiResponse<PaymentDto>(paymentDto);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Put(int id, PaymentDto paymentDto)
        {
            var post = _mapper.Map<Payment>(paymentDto);
            post.Id = id;

            var result = await _paymentService.UpdatePayment(post);
            var response = new ApiResponse<bool>(result);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _paymentService.DeletePayment(id);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }
    }
}
