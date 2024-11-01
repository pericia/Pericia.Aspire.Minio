using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Pericia.Aspire.Minio.SampleApp.Models;
using Pericia.Aspire.Minio.SampleApp.Service;

namespace Pericia.Aspire.Minio.SampleApp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IS3Service _s3Service;

    public HomeController(ILogger<HomeController> logger, IS3Service s3Service)
    {
        _logger = logger;
        _s3Service = s3Service;
    }

    public async Task< IActionResult> Index()
    {
        var model = new IndexViewModel { ContainerName = "test-container" };


        await _s3Service.CreateContainer(model.ContainerName);


        return View();
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
