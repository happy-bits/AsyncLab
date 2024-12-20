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
        var startThreadId = Environment.CurrentManagedThreadId;
        var startTime = DateTime.Now.Ticks;

        Thread.Sleep(1000);

        var endThreadId = Environment.CurrentManagedThreadId;
        var endTime = DateTime.Now.Ticks;

        return Json(new
        {
            id,
            startThreadId,
            endThreadId,
            startTime,
            endTime
        });
    }

    public async Task<IActionResult> SlowOperation2(int id)
    {
        var startThreadId = Environment.CurrentManagedThreadId;
        var startTime = DateTime.Now.Ticks;

        await Task.Delay(1000);

        var endThreadId = Environment.CurrentManagedThreadId;
        var endTime = DateTime.Now.Ticks;

        return Json(new
        {
            id,
            startThreadId,
            endThreadId,
            startTime,
            endTime
        });
    }
}