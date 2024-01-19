using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Exam4.Web.Models;
using Exam4.Infrastructure.Repositories.Abstract;
using Exam4.Business.Services.Abstract;
using Exam4.Web.Models.Home;

namespace Exam4.Web.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IInstructorService _instructorService;

    public HomeController(ILogger<HomeController> logger,IInstructorService instructorService)
    {
        _logger = logger;
        this._instructorService = instructorService;
    }

    public async Task<IActionResult> Index()
    {
        var models = await _instructorService.GetSliderInstructors();
        var model = new IndexVM();
        model.Instructors = models;
        return View(model);
    }




    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
