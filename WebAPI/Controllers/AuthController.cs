using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private IAuthService _authService;
        private SmsService _smsService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthController(IAuthService authService, SmsService smsService, IHttpContextAccessor httpContextAccessor)
        {
            _authService = authService;
            _smsService = smsService;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpPost("login")]
        public ActionResult Login(UserForLoginDto userForLoginDto)
        {
            // Login sayfası açıldı
            // giriş yapılmaya çalışıldı
            // eğer şifresi ve username'i doğruysa ==> sms kodu girilecek sayfaya redirect edeceksin (eğer sms gönderilmediyse logine redirect)
            // yanlışsa şifreniz yanlış
            var userToLogin = _authService.Login(userForLoginDto);
            
            if (!userToLogin.Success)
            {
                return BadRequest(userToLogin.Message);
            }

            return Ok();
        }

        [HttpGet]
        public ActionResult SmsCheck(string smsCode, UserForLoginDto userForLoginDto)
        {
            var userToLogin = _authService.Login(userForLoginDto);
            if (_httpContextAccessor.HttpContext.Session.GetString("randomSms") != smsCode)
            {
                return BadRequest(userToLogin.Message);
            }

            var result = _authService.CreateAccessToken(userToLogin.Data);
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);

        }


        [HttpPost("register")]
        public ActionResult Register(UserForRegisterDto userForRegisterDto)
        {
            var userExists = _authService.UserExists(userForRegisterDto.PhoneNumber);
            if (!userExists.Success)
            {
                return BadRequest(userExists.Message);
            }

            var registerResult = _authService.Register(userForRegisterDto, userForRegisterDto.PhoneNumber);
            var result = _authService.CreateAccessToken(registerResult.Data);
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("sendsms")]
        public ActionResult SendSms(int id)
        {
            int x = 5;
            bool sended = false;
            sended = _smsService.Send("5352202588", "şifreniz :" + x);
            HttpContext.Session.SetString("sendedsms", sended.ToString());
            HttpContext.Session.SetString("randomSms", x.ToString());
            return Ok();
        }
    }
}
