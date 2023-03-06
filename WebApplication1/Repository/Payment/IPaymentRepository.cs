namespace WebApplication1.Repository.Payment
{
    public interface IPaymentRepository
    {
        List<Model.Payment> GetAll(); 
        Model.Payment Create(Model.Payment payment);
        Model.Payment Get(int id);
    }
}
