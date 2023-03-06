using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Services.Payment;
using WebApplication1.ViewModel;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService paymentService;
        private readonly IMapper mapper;

        public PaymentController(IPaymentService paymentService, IMapper mapper)
        {
            this.paymentService = paymentService;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<PaymentViewModel>> Get() {
            var allPayments = paymentService.GetAll();
            var mapPayments = mapper.Map<IEnumerable<PaymentViewModel>>(allPayments);
            return mapPayments;
        }

        [HttpPost]
        public async Task<IResult> Create(PaymentViewModel payment)
        {
            var mapPayment = mapper.Map<Model.Payment>(payment);
            var createPayment = paymentService.Create(mapPayment);
            if(payment != null)
            {
                return Results.Ok(createPayment.CardName);
            }
            return Results.BadRequest();
        }

        [HttpGet("{id}")]
        public async Task<PaymentViewModel> Get(int id) { 
            var payment = paymentService.Get(id);
            var mapPaymeny = mapper.Map<PaymentViewModel>(payment);
            return mapPaymeny;
        }
    }
}
