using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TestAPI
{
    class Program
    {
        static async Task Main(string[] args)
        {
            TodoService todoService = new TodoService();
            await todoService.Save(new Todo
            {
                userId = 5,
                id = 203,
                title = "Hello part 3",
                completed = true
            });
            //List<Todo> todoList = new List<Todo>();
            //await todoService.FindAll();
            //await todoService.FindById(1);
            //foreach(var td in todoList)
            //{
            //    Console.WriteLine(td.ToString());
            //}
            //await todoService.Update(1, new Todo
            //{
            //    userId = 5,
            //    id = 203,
            //    title = "Hello part 3",
            //    completed = true
            //});
            //await todoService.DeleteTodo(200);

        }
    }
}
