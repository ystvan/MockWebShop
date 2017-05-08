using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProductManager.Models;

namespace ProductManager.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository _repository;

        public ProductController(IProductRepository repo)
        {
            _repository = repo;
        }

        public ViewResult List() => View(_repository.Products);
    }
}
