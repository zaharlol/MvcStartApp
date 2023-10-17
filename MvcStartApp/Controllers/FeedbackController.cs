using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MvcStartApp.Models;
using System.Diagnostics;

public class FeedbackController : Controller
{
    private readonly IBlogRepository _repo;

    public FeedbackController(IBlogRepository repo)
    {
        _repo = repo;
    }
    /// <summary>
    ///  Метод, возвращающий страницу с отзывами
    /// </summary>
    [HttpGet]
    public IActionResult Add()
    {
        return View();
    }

    /// <summary>
    /// Метод для Ajax-запросов
    /// </summary>
    [HttpPost]
    public IActionResult Add(Feedback feedback, Request request)
    {
        _repo.AddFeedbackOnBd(request);
        return StatusCode(200, $"{feedback.From}, спасибо за отзыв!");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}