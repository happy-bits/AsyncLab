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

    // Utan async/await - blockernade kod
    public IActionResult Index()
    {
        var products = _context.Products.ToList();  // Blockerar tråden tills data hämtats
        return View("Index", products);
    }

    // Med async/await - icke-blockerande kod
    public async Task<IActionResult> Index2Async()
    {
        var products = await _context.Products.ToListAsync(); // Blockerar inte tråden
        return View("Index", products);
    }

    public int Add(int a, int b)
    {
        Thread.Sleep(1000); // Simulerar en långsam operation
        return a + b;
    }

    public async Task<int> AddAsync(int a, int b)
    {
        await Task.Delay(1000); // Simulerar en långsam operation
        return a + b;
    }

    public string Starify(string text)
    {
        Thread.Sleep(1000); // Simulerar en långsam operation
        return $"***{text}***";
    }

    public async Task<string> StarifyAsync(string text)
    {
        await Task.Delay(1000); // Simulerar en långsam operation

        return $"***{text}***";
    }

    public async Task SomeFunction()
    {
        // Do stuff
        var result = await StarifyAsync("abc");
    }

    public string ReadSomething()
    {
        var result = System.IO.File.ReadAllText("some-file.txt");
        return result;
    }

    public async Task<string> ReadSomethingAsync()
    {
        var result = await System.IO.File.ReadAllTextAsync("some-file.txt");
        return result;
    }

    public IActionResult PerformanceTest()
    {
        return View();
    }

    public IActionResult SlowOperation()
    {
        Thread.Sleep(1000); // Simulerar långsam operation
        return Json(new { success = true });
    }

    public async Task<IActionResult> SlowOperationAsync()
    {
        await Task.Delay(1000); // Simulerar långsam operation
        return Json(new { success = true });
    }
}