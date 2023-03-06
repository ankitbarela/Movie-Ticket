using WebApplication1.Repository.Payment;

namespace WebApplication1.Services.Payment
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository paymentRepository;

        public PaymentService(IPaymentRepository paymentRepository)
        {
            this.paymentRepository = paymentRepository;
        }
        public List<Model.Payment> GetAll()
        {
            var allPayments = paymentRepository.GetAll();
            return allPayments;
        }
        public Model.Payment Create(Model.Payment payment)
        {
            payment.CreatedAt= DateTime.Now;
            payment.UpdatedAt= DateTime.Now;
            payment.CreatedBy = 1;
            payment.UpdatedBy= 1;
            return paymentRepository.Create(payment);
        }
        public Model.Payment Get(int id)
        {
            var payment = paymentRepository.Get(id);
            return payment;
        }
    }
}
