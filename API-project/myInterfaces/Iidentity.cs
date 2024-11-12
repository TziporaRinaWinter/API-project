using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using myModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace myInterfaces
{
    public interface Iidentity 
    {
        SecurityToken GetToken(List<Claim> claims);
        //public TokenValidationParameters GetTokenValidationParameters();
        SecurityToken Login(User user);

    }
}