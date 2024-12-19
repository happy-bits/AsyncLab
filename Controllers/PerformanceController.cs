using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AsyncLab.Data;

namespace AsyncLab.Controllers;

public class PerformanceController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult SlowOperation(int id)
    {
        // var threadId = Thread.CurrentThread.ManagedThreadId;
        // Console.WriteLine($"Sync operation {id} started at: {DateTime.Now:HH:mm:ss.fff} on thread {threadId}");
        
        Thread.Sleep(1000); 
        
        // Console.WriteLine($"Sync operation {id} completed at: {DateTime.Now:HH:mm:ss.fff} on thread {threadId}");
        return Json(new { success = true}); 
    }

    public async Task<IActionResult> SlowOperation2(int id)
    {
        // var threadId = Thread.CurrentThread.ManagedThreadId;
        // Console.WriteLine($"Async operation {id} started at: {DateTime.Now:HH:mm:ss.fff} on thread {threadId}");
        
        await Task.Delay(1000);
        
        // var newThreadId = Thread.CurrentThread.ManagedThreadId;
        // Console.WriteLine($"Async operation {id} completed at: {DateTime.Now:HH:mm:ss.fff} on thread {newThreadId}");
        return Json(new { success = true });
    }
}