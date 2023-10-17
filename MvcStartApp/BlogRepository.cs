using Microsoft.EntityFrameworkCore;
using static MvcStartApp.Startup;
using System.Threading.Tasks;
using System;

public class BlogRepository : IBlogRepository
{
    // ссылка на контекст
    private readonly BlogContext _context;

    // Метод-конструктор для инициализации
    public BlogRepository(BlogContext context)
    {
        _context = context;
    }

    public async Task AddUser(User user)
    {
        user.JoinDate = DateTime.Now;
        user.Id = Guid.NewGuid();

        // Добавление пользователя
        var entry = _context.Entry(user);
        if (entry.State == EntityState.Detached)
            await _context.Users.AddAsync(user);

        // Сохранение изенений
        await _context.SaveChangesAsync();
    }

    public async Task AddUserOnBd(Request request)
    {
        request.Date = DateTime.Now;
        request.Id = Guid.NewGuid();
        request.Url = $"Пользователь добавлен";

        await _context.Requests.AddAsync(request);
        await _context.SaveChangesAsync();
    }

    public async Task AddFeedbackOnBd(Request request)
    {
        request.Date = DateTime.Now;
        request.Id = Guid.NewGuid();
        request.Url = $"Отзыв добавлен";

        await _context.Requests.AddAsync(request);
        await _context.SaveChangesAsync();
    }

    public async Task<User[]> GetUsers()
    {
        // Получим всех активных пользователей
        return await _context.Users.ToArrayAsync();
    }
}