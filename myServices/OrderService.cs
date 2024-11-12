using System.Net.Http;
using myInterfaces;
using myModels;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.IO;
using fileService;


namespace myServices
{

    public class OrderService : myInterfaces.IOrder
    {
        IPizza _p;
        IfileService<string> _f;
        public DateTime Date { get; set; }
        
        public OrderService(IPizza p,IfileService<string> f )
        {
            Date = DateTime.Now;
            _p=p;
            _f=f;
            _f.FileName="";
        }
        public string Stringi() => "the date from order: " + Date;

        public Order? Get(){
            return null;
        }

        public async Task<string> SendOrder(Order order)
        {
            DateTime Date = new DateTime();
            var jsonOrder = JsonSerializer.Serialize<Order>(order);
            var strp = payAsync(order);
            var strm = MakePizzasAsync(order.Items);
            string strp2 =await strp;
            string strm2 =await strm;
            Receipt(order);
            return strp2 +strm2+ jsonOrder;
        }

        public async Task<string> payAsync(Order order)
        {
            Console.WriteLine("take credit card details...");
            await Task.Delay(1000);
            Console.WriteLine("checked the card number...");
            await Task.Delay(1000);
            Console.WriteLine("connect to credit campany...");
            await Task.Delay(4000);
            Console.WriteLine("transfare the money...");
            await Task.Delay(1000);
            Console.WriteLine("disconnect...");
            await Task.Delay(3000);
            return "the deal was made successfully!";
        }
        public async Task<string> MakePizzasAsync(List<OrderItem> items)
        {
            List<Pizza> pizza= _p.Get();
            foreach(OrderItem i in items){
            Pizza piz= pizza.FirstOrDefault(pi => pi.Id == i.ItemId);
                if(piz!=null){
                    for(int j=0; j< i.Quantity;j++){
                        Console.WriteLine("we start make the pizza: "+piz.Name);
                        Console.WriteLine("make the dough...");
                        Console.WriteLine("put ketshop...");
                        Console.WriteLine("put yellowcheese and so on...");
                        Console.WriteLine("put in oven...");
                        await Task.Delay(3000);
                        Console.WriteLine("the pizza: "+piz.Name+" made successfully!");
                    }
                }
            }
            return "in pleasure:) PIZZAshop";
        }
        public void Receipt(Order ord){
            List<Pizza> pizza= _p.Get();
            string str=$"CustomerId: {ord.CustomerId}, Date: {ord.Date}\n ";
            foreach(OrderItem i in ord.Items){
                Pizza piz= pizza.FirstOrDefault(pi => pi.Id == i.ItemId);
                str+=$" pizza's id: {i.ItemId},pizza's name: {piz.Name} Quantity: {i.Quantity}, Price: {i.Price}\n";
            }
            str+=$" TotalAmount: {ord.TotalAmount}\n thank you for buying in apiPIZZA!!!\n";
            _f.FileName=Path.Combine("Mail", $"custumer{ord.CustomerId}");
            _f.WriteLog(str);
        }
    }
}