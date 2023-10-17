﻿using System.Threading.Tasks;

public interface IBlogRepository
{
    Task AddUser(User user);

    Task<User[]> GetUsers();

    Task AddUserOnBd(Request request);
    Task AddFeedbackOnBd(Request request);
}