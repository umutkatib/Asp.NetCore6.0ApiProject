using ApiProjectCamp.WebApi.Context;
using ApiProjectCamp.WebApi.Dtos.ProductDtos;
using ApiProjectCamp.WebApi.Entities;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiProjectCamp.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductsController : ControllerBase
	{
		private readonly IMapper _mapper;
		private readonly IValidator<CreateProductDto> _createProductValidator;
		private readonly IValidator<UpdateProductDto> _updateProductValidator;
		private readonly ApiContext _context;

		public ProductsController(ApiContext context, IMapper mapper, IValidator<CreateProductDto> createProductValidator, IValidator<UpdateProductDto> updateProductValidator)
		{
			_context = context;
			_mapper = mapper;
			_createProductValidator = createProductValidator;
			_updateProductValidator = updateProductValidator;
		}

		[HttpGet]
		public IActionResult ProductList()
		{
			return Ok(_mapper.Map<List<ResultProductDto>>(_context.Products.ToList()));
		}

		[HttpPost]
		public IActionResult ProductCreate(CreateProductDto createProductDto)
		{
			createProductDto.ProductStatus = true;
			var validationResult = _createProductValidator.Validate(createProductDto);
			if (!validationResult.IsValid)
			{
				return BadRequest(validationResult.Errors.Select(x => x.ErrorMessage));
			}
			else
			{
				var value = _mapper.Map<Product>(createProductDto);
				_context.Products.Add(value);
				_context.SaveChanges();
				return Ok();
			}
		}

		[HttpDelete("{id}")]
		public IActionResult ProductDelete(int id)
		{
			_context.Products.Remove(_context.Products.Find(id));
			_context.SaveChanges();
			return Ok();
		}

		[HttpPut]
		public IActionResult ProductUpdate(UpdateProductDto updateProductDto)
		{
			updateProductDto.ProductStatus = true;
			var validationResult = _updateProductValidator.Validate(updateProductDto);
			if (!validationResult.IsValid)
			{
				return BadRequest(validationResult.Errors.Select(x => x.ErrorMessage));
			}
			else
			{
				var value = _mapper.Map<Product>(updateProductDto);
				_context.Products.Update(value);
				_context.SaveChanges();
				return Ok();
			}
		}

		[HttpGet("{id}")]
		public IActionResult ProductGet(int id)
		{
			var value = _context.Products.Find(id);
			return Ok(_mapper.Map<GetProductDto>(value));
		}


		[HttpGet("ProductListWithCategoryName")]
		public IActionResult ProductListWithCategoryName()
		{
			var value = _context.Products.Include(x => x.Category).ToList();
			return Ok(_mapper.Map<List<ResultProductWithCategoryNameDto>>(value));
		}

		[HttpPost("CreateProductWithCategoryName")]
		public IActionResult CreateProductWithCategoryName(CreateProductDto createProductDto)
		{
			var value = _mapper.Map<Product>(createProductDto);
			_context.Products.Add(value);
			_context.SaveChanges();
			return Ok();
		}

		[HttpGet("ProductChangeStatus/{id}")]
		public IActionResult ProductChangeStatus(int id)
		{
			var value = _context.Products.Find(id);
			value.ProductStatus = !value.ProductStatus;
			_context.SaveChanges();
			return Ok();
		}
	}
}
