using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using TestAPI.Models;
using System.Security.Cryptography;
using BCrypt.Net;
using Microsoft.AspNetCore.Authorization;
using Org.BouncyCastle.Asn1.Ocsp;
using System.Security.Principal;
using TestAPI.Models.Account;
using TestAPI.Services;
using AutoMapper;


namespace TestAPI.Controllers
{
    using AutoMapper;
    using BCrypt.Net;
    using System.Data;
    using TestAPI.Models.Accounts;

    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private APIContext db { get; set; }
        private IAccountService accountService { get; set; }
        public UsersController(APIContext context, IAccountService inAccountService)
        {
            accountService = inAccountService;
            db = context;
        }

        // GET: User ALL
        [HttpGet]
        public ActionResult<IEnumerable<UserResponse>> GetAll()
        {
            var accounts = accountService.GetAll();
            return Ok(accounts);
        }
        //Get User by ID
       [HttpGet("{id}")]
        public ActionResult<UserResponse> GetById(int id)
        {
            var resp = accountService.GetById(id);
            return Ok(resp);
        }

        //Login User
        [Route("login")]
        [HttpPost]

        public IActionResult userLogin([FromBody] LoginRequest request)
        {
            var response = accountService.Authenticate(request, ipAddress());
            setTokenCookie(response.RefreshToken);
            return Ok(response);
        }
        
        // Registrierung User
        [Route("register")]
        [HttpPost]
        public string Post(RegisterRequest request)
        {
            accountService.Register(request, "https://localhost:7283");

            return "Register successful";
        }

        [AllowAnonymous]
        [HttpPost("verify-email")]
        public IActionResult VerifyEmail(VerifyEmailRequest model)
        {
            accountService.VerifyEmail(model.Token);
            return Ok(new { message = "Verification successful, you can now login" });
        }

        [AllowAnonymous]
        [HttpPost("forgot-password")]
        public IActionResult ForgotPassword(ForgotPasswordRequest model)
        {
            accountService.ForgotPassword(model, Request.Headers["origin"]);
            return Ok(new { message = "Please check your email for password reset instructions" });
        }

        [AllowAnonymous]
        [HttpPost("reset-password")]
        public IActionResult ResetPassword(ResetPasswordRequest model)
        {
            accountService.ResetPassword(model);
            return Ok(new { message = "Password reset successful, you can now login" });
        }
        [AllowAnonymous]
        [HttpPost("refresh-token")]
        public ActionResult<AuthenticateResponse> RefreshToken()
        {
            var refreshToken = Request.Cookies["refreshToken"];
            var response = accountService.RefreshToken(refreshToken, ipAddress());
            setTokenCookie(response.RefreshToken);
            return Ok(response);
        }
        // DELETE api/<UsersController>/5
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            accountService.Delete(id);
            return Ok(new { message = "User deleted successfully" });
        }

        private void setTokenCookie(string token)
        {
            var cookieOptions = new CookieOptions
        { 
            HttpOnly = true,
            Expires = DateTime.UtcNow.AddDays(7)
        };
             Response.Cookies.Append("refreshToken", token, cookieOptions);
        }
        private string ipAddress()
            {
             if (Request.Headers.ContainsKey("X-Forwarded-For"))
             return Request.Headers["X-Forwarded-For"];

             else
             return HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            }

        }
    }

