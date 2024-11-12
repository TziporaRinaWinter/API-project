using myModels;

namespace myInterfaces
{
    public interface IOrder : ILifeTime
    {
        Task<string> SendOrder(Order order);
        Order? Get();
        void Receipt(Order ord);
        Task<string> MakePizzasAsync(List<OrderItem> items);
        Task<string> payAsync(Order order);
    }
}
