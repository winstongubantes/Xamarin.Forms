using System.Collections.Generic;
using Sample.Models;

namespace Sample.Services
{
    public interface ITodoItemService
    {
        void Add(TodoItem item);
        void Update(TodoItem item);
        void Delete(TodoItem item);
        IList<TodoItem> Get();
    }
}