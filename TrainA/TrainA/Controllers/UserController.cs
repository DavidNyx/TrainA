using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using TrainA.Entities;

namespace TrainA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly AppSetting _appSettings;

        [HttpPost("Login")]
        public IActionResult Validate(LoginModel model)
    }

    private string GenerateToken(NhanVien nhanVien)
    {
        var jwtTokenHandler = new JwtSecurityTokenHandler();
    }
}
