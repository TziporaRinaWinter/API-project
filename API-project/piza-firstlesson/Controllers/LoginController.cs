using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using myModels;
using myInterfaces;
using myServices; 
using fileService;

namespace piza_firstlesson.Controllers{

[ApiController]
[Route("api/[controller]/[action]")]
public class LoginController : ControllerBase
{
    readonly Iidentity _identity;
    public LoginController(Iidentity identity) {
        _identity=identity;
    }

    [HttpPost]
    [Route("[action]")]
    public ActionResult<String> Login([FromBody]User user)
    {
        var token = _identity.Login(user);
        if(token == null)
            throw new UnauthorizedAccessException("Unauthorized");
        return new OkObjectResult(new JwtSecurityTokenHandler().WriteToken(token));
    }
}
}
