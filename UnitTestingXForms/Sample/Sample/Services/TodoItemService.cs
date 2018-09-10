using System;
using System.Collections.Generic;
using System.Text;
using Sample.Models;

namespace Sample.Services
{
    public class TodoItemService : ITodoItemService
    {
        public void Add(TodoItem item)
        {
            //Do your logic here
        }

        public void Update(TodoItem item)
        {
            //Do your logic here
        }

        public void Delete(TodoItem item)
        {
            //Do your logic here
        }

        public IList<TodoItem> Get()
        {
            return new List<TodoItem>();
        }
    }
}
