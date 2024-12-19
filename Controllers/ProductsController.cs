using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AsyncLab.Data;

namespace AsyncLab.Controllers;

public class ProductsController : Controller
{
    private readonly ApplicationDbContext _context;

    public ProductsController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var products = _context.Products.ToList(); 
        return View("Index", products);
    }
    
}