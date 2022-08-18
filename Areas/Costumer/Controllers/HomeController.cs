using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BullyBookWeb.Models;
using BullyBookWeb.Data.Repository.IRepository;


namespace BullyBookWeb.Controllers;

[Area("Costumer")]
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IUnitOfWork _unitOfWork;

    public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
    {
        _logger = logger;
        _unitOfWork = unitOfWork;
    }

    public IActionResult Index()
    {
        IEnumerable<Product> products = _unitOfWork.Product.GetAll(includeProtperties: "Category,CoverType");
        return View(products);
    }

    public IActionResult Details(int id)
    {
        ShoppingCart objCart = new()
        {
            Count = 1,
            Product = _unitOfWork.Product.GetFirstOrDefault(x => x.Id == id, includeProtperties: "Category,CoverType")
        };
        return View(objCart);
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
