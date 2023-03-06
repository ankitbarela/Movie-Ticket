namespace WebApplication1.Services.Payment
{
    public interface IPaymentService
    {
        List<Model.Payment> GetAll();
        Model.Payment Create(Model.Payment payment);
        Model.Payment Get(int id);
    }
}
