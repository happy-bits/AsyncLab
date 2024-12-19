using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AsyncLab.Data;
using AsyncLab.Models;

namespace AsyncLab.Controllers;

public class ProductsController : Controller
{
    private readonly ApplicationDbContext _context;

    public ProductsController(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var products = await _context.Products.ToListAsync();
        return View(products);
    }
} 