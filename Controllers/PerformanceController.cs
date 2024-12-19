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
        var threadId = Thread.CurrentThread.ManagedThreadId;
        var startTime = DateTime.Now.Ticks;   
        
        Thread.Sleep(1000); 
        
        var endTime = DateTime.Now.Ticks;
        return Json(new { id, threadId, startTime, endTime, duration = endTime - startTime }); 
    }

    public async Task<IActionResult> SlowOperation2(int id)
    {
        var threadId = Thread.CurrentThread.ManagedThreadId;
        var startTime = DateTime.Now.Ticks;   
        
        await Task.Delay(1000);
        
        var endTime = DateTime.Now.Ticks;
        return Json(new { id, threadId, startTime, endTime, duration = endTime - startTime   }); 
    }
}