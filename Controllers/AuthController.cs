using System;
using dotnet_login.Data;
using dotnet_login.Dtos;
using dotnet_login.Helpers;
using dotnet_login.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_login.Controllers
{
    [Route("api")]
    [ApiController]
    public class AuthController : Controller
    {
        // inject the IRepo here in the controller
        private readonly IUserRepo _repo;
        private readonly JwtService _jwtService;

        public AuthController(IUserRepo repo, JwtService jwtService)
        {
            _repo = repo;
            _jwtService = jwtService;
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterDto dto)
        {
            Console.Write(Response);
            var user = new User
            {
                Name = dto.Name,
                Email = dto.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(dto.Name)
            };

            return Created("Success", new
            {
                message = "Created",
                data = _repo.Create(user)
            });

        }

        [HttpPost("login")]
        public IActionResult Login(LoginDto dto)
        {
            var user = _repo.GetByEmail(dto.Email);
            if (user == null) return BadRequest(new { message = "Invalid Credentials" });

            if (!BCrypt.Net.BCrypt.Verify(dto.Password, user.Password))
            {
                return BadRequest(new { message = "Invalid Credentials" });
            }

            var jwt = _jwtService.Generate(user.Id);

            // jwt will be in http only cookie, where front end cannot access it
            // just to get from backend, front end only get and send
            Response.Cookies.Append("jwt", jwt, new CookieOptions
            {
                HttpOnly = false
            });

            return Ok(new
            {
                message = "success",
                jwt = jwt
            });
        }


        [HttpGet("user")]
        public IActionResult User()
        {
            try
            {
                var jwt = Request.Cookies["jwt"];
                var token = _jwtService.Verify(jwt);
                int userId = int.Parse(token.Issuer);
                var user = _repo.GetById(userId);
                return Ok(user);
            }
            catch (Exception)
            {
                return Unauthorized();
            }

        }

        [HttpGet("user/{id}")]
        public IActionResult GetUserById(int id)
        {
            var user = _repo.GetById(id);
            return Ok(user);

        }

        [HttpPost("logout")]
        public IActionResult LogOut()
        {
            Console.Write(Response);
            Response.Cookies.Delete("jwt");

            return Ok(new
            {
                message = "Successfully Logged Out"
            });
        }
        
    }
}