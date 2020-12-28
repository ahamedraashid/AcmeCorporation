using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AcmeCorporation.API.Data.Models;
using AcmeCorporation.API.Dto;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using AcmeCorporation.API.Services;
using System.Security.Claims;
using AcmeCorporation.API.Shared.Enums;
using System;

namespace AcmeCorporation.API.Data.Contracts
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : Controller
    {
        private IProductRepository _productRepository;
        private readonly IUserRepository _userRepository;
        private readonly IFileUploadService _fileUploadService;
        private readonly IMapper _mapper;

        public ProductController(IProductRepository productRepository, IUserRepository userRepository, IFileUploadService fileUploadService, IMapper mapper)
        {
            _mapper = mapper;
            _productRepository = productRepository;
            _userRepository = userRepository;
            _fileUploadService = fileUploadService;
        }
        [HttpGet]
        [AllowAnonymous]
        public IList<ProductDto> Get()
        {
            var products = _productRepository.GetAll();
            return _mapper.Map<IList<Product>, IList<ProductDto>>(products.ToList()); ;
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ProductDto> Get(int id)
        {
            var product = await _productRepository.Get(id);
            return _mapper.Map<Product, ProductDto>(product);
        }

        [HttpGet]
        public async Task<IList<ProductDto>> GetActiveProducts()
        {
            var activeProducts = await _productRepository.GetActiveProducts();
            var productDtos = _mapper.Map<IList<Product>, IList<ProductDto>>(activeProducts.ToList());
            return productDtos;
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ProductDto> Create([FromForm] ProductDto newProduct)
        {
            var product = _mapper.Map<ProductDto, Product>(newProduct);
            product.Photos = _fileUploadService.UploadFiles(newProduct.Photos);
            var addedProduct = await _productRepository.Add(product);
            _productRepository.SaveChanges();

            return _mapper.Map<Product, ProductDto>(addedProduct);
        }

        [HttpDelete]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            _productRepository.Delete(id);
            _productRepository.SaveChanges();
            return Ok();
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update([FromForm] ProductDto updatedProduct)
        {
            var product = await _productRepository.Get(updatedProduct.Id);
            _mapper.Map<ProductDto, Product>(updatedProduct, product);
            if (updatedProduct.IsFileModified)
            {
                product.Photos.Clear();
                product.Photos = _fileUploadService.UploadFiles(updatedProduct.Photos);
            }
            _productRepository.SaveChanges();
            return Ok();
        }

        [HttpPost]
        [Authorize(Roles = "Admin, User")]
        public async Task<ProductDto> AddTransactionToProduct([FromBody] Transaction transaction)
        {
            var product = await _productRepository.Get(transaction.ProductId);
            var userUniqueIdentifier = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            transaction.User = _userRepository.GetUserByEmailAddress(userUniqueIdentifier);
            transaction.UpdatedTime = DateTime.Now;
            product.Transactions.Add(transaction);
            _productRepository.SaveChanges();
            return _mapper.Map<Product, ProductDto>(product);
        }

        [HttpPost]
        [Authorize(Roles = "Admin, User")]
        public async Task<IActionResult> UpdateStatus([FromBody] ProductDto productDto)
        {
            var product = await _productRepository.Get(productDto.Id);
            product.Status = (ProductStatus)Enum.Parse(typeof(ProductStatus), productDto.Status);
            _productRepository.SaveChanges();
            return Ok();
        }
    }
}