﻿using ElVegetarianoFurio.Models;
using ElVegetarianoFurio.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElVegetarianoFurio.Controllers
{
    [Route("api/[controller]")]
    public class DishesController : Controller
    {
        private readonly IDishRepository _repository;

        public DishesController(IDishRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IEnumerable<Dish> Get()
        {
            return _repository.GetDishes();
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var dish = _repository.GetDishById(id);
            if(dish == null)
            {
                return NotFound();
            }
        
            return Ok(dish);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Dish dish)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = _repository.CreateDish(dish);
            return CreatedAtAction("Get", new { id = dish.Id }, result);
        }

        
    }
}
