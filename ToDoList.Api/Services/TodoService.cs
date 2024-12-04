using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoList.Api.Models;
using ToDoList.Api.Controllers;

namespace ToDoList.Api.Services
{
    public class TodoService
    {
        private readonly List<Todo> _todos = new List<Todo>();

        public Task<List<Todo>> GetAllTodosAsync()
        {
            return Task.FromResult(_todos);
        }

        public Task<Todo> GetTodoByIdAsync(int id)
        {
            var todo = _todos.FirstOrDefault(t => t.Id == id);
            return Task.FromResult(todo);
        }

        public Task<Todo> CreateTodoAsync(Todo newTodo)
        {
            newTodo.Id = _todos.Count + 1;
            _todos.Add(newTodo);
            return Task.FromResult(newTodo);
        }

        public Task<bool> UpdateTodoAsync(int id, Todo updatedTodo)
        {
            var todo = _todos.FirstOrDefault(t => t.Id == id);
            if (todo == null)
            {
                return Task.FromResult(false);
            }

            todo.Title = updatedTodo.Title;
            todo.Description = updatedTodo.Description;
            todo.Priority = updatedTodo.Priority;
            todo.IsCompleted = updatedTodo.IsCompleted;
            todo.AssignedTo = updatedTodo.AssignedTo;
            todo.DueDate = updatedTodo.DueDate;

            return Task.FromResult(true);
        }

        public Task<bool> DeleteTodoAsync(int id)
        {
            var todo = _todos.FirstOrDefault(t => t.Id == id);
            if (todo != null)
            {
                _todos.Remove(todo);
                return Task.FromResult(true);
            }
            return Task.FromResult(false);
        }
    }
}
