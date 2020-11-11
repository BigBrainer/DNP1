using Blazor_ToDo.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Resources;
using System.Runtime.Versioning;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using System.Threading.Tasks;

namespace Blazor_ToDo.Data
{
    public class ToDoService : IToDoService
    {
        private string toDoFile = "toDos.json";
        private IList<ToDo> toDos;

        public ToDoService()
        {
            if(!File.Exists(toDoFile))
            {
                Seed();
                WriteToDosToFile();
            }
            else
            {
                string content = File.ReadAllText(toDoFile);
                toDos = JsonSerializer.Deserialize<IList<ToDo>>(content);
            }
        }
        public async Task AddToDoAsync(ToDo toDo)
        {
            int max = toDos.Count > 0 ? toDos.Max(toDo => toDo.TodoId) : 0;
            toDo.TodoId = ++max;
            toDos.Add(toDo);
            WriteToDosToFile();
        }

        public async Task<IList<ToDo>> GetToDosAsync(bool? status, int? userId)
        {
            List<ToDo> tmp = new List<ToDo>(toDos);
            List<ToDo> filteredToDos = tmp.Where(t => (userId != null && userId == t.UserId || userId == null) &&
       (status != null && t.IsCompleted == status || status == null)).ToList();
            return filteredToDos;
        }

        public async Task RemoveToDoAsync(int toDoId)
        {
            ToDo toRemove = toDos.First(t => t.TodoId == toDoId);
            toDos.Remove(toRemove);
            WriteToDosToFile();
        }
        public async Task UpdateToDoAsync(ToDo toDo)
        {
            ToDo toUpdate = toDos.First(todo => todo.TodoId == toDo.TodoId);
            toUpdate.IsCompleted = toDo.IsCompleted;
            WriteToDosToFile();
        }

        private void WriteToDosToFile()
        {
            string productAsJson = JsonSerializer.Serialize(toDos);
            File.WriteAllText(toDoFile, productAsJson);
        }

        private void Seed()
        {
            ToDo[] ts =
            {
                new ToDo
                {
                    UserId = 1,
                    TodoId = 1,
                    Title = "Make some steak and beans mmmmm",
                    IsCompleted = false
                },
                new ToDo
                {
                    UserId = 1,
                    TodoId = 2,
                    Title = "Wash dishes",
                    IsCompleted = false
                },
                new ToDo
                {
                    UserId = 1,
                    TodoId = 3,
                    Title = "Do homework",
                    IsCompleted = false
                },
                new ToDo
                {
                    UserId = 2,
                    TodoId = 4,
                    Title = "Sleep-sleep",
                    IsCompleted = true
                }
            };
            toDos = ts.ToList();
        }
    }
}
