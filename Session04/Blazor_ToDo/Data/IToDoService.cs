using Blazor_ToDo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blazor_ToDo.Data
{
    public interface IToDoService
    {
        IList<ToDo> GetToDos();
        void AddToDo(ToDo toDo);
        void RemoveToDo(int toDoId);
    }
}
