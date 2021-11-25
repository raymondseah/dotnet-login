using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using dotnet_login.Data;
using dotnet_login.Dtos;
using dotnet_login.Helpers;
using dotnet_login.Models;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_login.Controllers
{
    [Route("api")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IProductRepo _repo;
        private readonly JwtService _jwtService;
        // private readonly IMapper _mapper;

        public ProductController(IProductRepo repo, JwtService jwtService)
        {
            _repo = repo;
            _jwtService = jwtService;
            // _mapper = mapper;
        }

        [HttpPost("createproduct")]
        public IActionResult CreateProduct(ProductCreateDto dto)
        {
            try
            {
                var jwt = Request.Cookies["jwt"];
                var token = _jwtService.Verify(jwt);
                // Console.WriteLine(token);
                int userId = int.Parse(token.Issuer);
                var product = new Product
                {
                    ProductName = dto.ProductName,
                    ProductDescription = dto.ProductDescription,
                    ProductPrice = dto.ProductPrice,
                    PictureUrl = dto.PictureUrl,
                    UserId = userId

                };

                return Created("Success", new
                {
                    message = "Created",
                    data = _repo.Create(product)

                });
            }
            catch (Exception)
            {
                return Unauthorized();
            }


        }

        [HttpGet("getproducts")]
        public async Task<ActionResult<List<Product>>> GetAllProducts()
        {
            var productItems = await _repo.GetAllProductsAsync();
            // return Ok("success");
            return Ok(productItems);
        }

        [HttpGet("getproducts/{id}")]
        public async Task<ActionResult<Product>> GetProductById(int id)
        {
            var productItem = await _repo.GetProductByIdAsync(id);
            // return Ok("success");
            return Ok(productItem);
        }


    }
}