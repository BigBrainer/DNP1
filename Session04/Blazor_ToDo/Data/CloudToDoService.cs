using Blazor_ToDo.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Blazor_ToDo.Data
{
    public class CloudToDoService : IToDoService
    {
        private readonly HttpClient client;
        private string uri = "https://jsonplaceholder.typicode.com";
        public CloudToDoService()
        {
            client = new HttpClient();
        }
        public async Task AddToDoAsync(ToDo toDo)
        {
            string toDoSerialized = JsonSerializer.Serialize(toDo);
            StringContent content = new StringContent(
                toDoSerialized,
                Encoding.UTF8,
                "application/json"
                );

            HttpResponseMessage response = await client.PostAsync(uri + "/todos", content);
            Console.WriteLine(response);
        }

        public async Task<IList<ToDo>> GetToDosAsync(bool? status, int? userId)
        {
            string message = null;
            string stat = status.ToString().ToLower();
            if (userId != null && status == null)
            {
                message = await client.GetStringAsync($"{uri}/todos?userId={userId}");
            }
            else if(userId != null && status != null)
            {
                message = await client.GetStringAsync($"{uri}/todos?userId={userId}&completed={stat}");
            }
            else if(userId == null && status != null)
            {
                message = await client.GetStringAsync($"{uri}/todos?completed={stat}");
            }
            if(message != null)
            {
                List<ToDo> allToDos = JsonSerializer.Deserialize<List<ToDo>>(message);
                List<ToDo> filteredToDos = allToDos.Where(t => (userId != null && userId == t.UserId || userId == null) &&
           (status != null && t.IsCompleted == status || status == null)).ToList();
                return filteredToDos;
            }
            else
            {
                throw new Exception("Please select a filter to search for To Dos.");
            }
        }

        public async Task RemoveToDoAsync(int toDoId)
        {
            HttpResponseMessage response = await client.DeleteAsync($"{uri}/todos/{toDoId}");
            Console.WriteLine(response);
        }

        public async Task UpdateToDoAsync(ToDo toDo)
        {
            int toDoToUpdateId = toDo.TodoId;
            string toDoAsJson = JsonSerializer.Serialize(toDo);
            StringContent content = new StringContent(
                toDoAsJson,
                Encoding.UTF8,
                "application/json"
                );
            HttpResponseMessage response = await client.PutAsync($"{uri}/todos/{toDoToUpdateId}", content);
            Console.WriteLine(response);
        }
    }
}
