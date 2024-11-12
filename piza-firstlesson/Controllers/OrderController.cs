using Microsoft.AspNetCore.Mvc;
using myModels;
using myInterfaces;
using myServices; 

namespace piza_firstlesson.Controllers{

[ApiController]
[Route("api/[controller]/[action]")]
public class OrderController : ControllerBase
{
    readonly IOrder _order;


    public OrderController(IOrder order){
        _order=order;
    }

    [HttpGet]
    public Order? Get(){
        return _order.Get();
    }
    [HttpPost]
    public async Task<string> SendOrder([FromBody]Order order)
    {
        Console.WriteLine(_order.Stringi());
        return await _order.SendOrder(order);
    }
}
}