using Blazor_ToDo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blazor_ToDo.Data
{
    public interface IToDoService
    {
        Task<IList<ToDo>> GetToDosAsync(bool? status, int? userId);
        Task AddToDoAsync(ToDo toDo);
        Task RemoveToDoAsync(int toDoId);
        Task UpdateToDoAsync(ToDo toDo);
    }
}
