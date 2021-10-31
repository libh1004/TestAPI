using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TestAPI
{
    public class TodoService
    {
        private static string ApiBaseUrl = "https://jsonplaceholder.typicode.com";
        private static string ApiPostPath = "/todos";
        private static string ApiDataType = "application/json";
        public async Task<bool> Save(Todo todo)
        {
            try
            {
                using(var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(ApiBaseUrl);
                    var jsonContent = Newtonsoft.Json.JsonConvert.SerializeObject(todo);
                    var contentToSend = new StringContent(jsonContent, Encoding.UTF8, ApiDataType);
                    var result = await client.PostAsync(ApiPostPath, contentToSend);
                    string resultContent = await result.Content.ReadAsStringAsync();
                    Console.WriteLine(resultContent);
                    return true;
                }
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
        public async Task<List<Todo>> FindAll()
        {
            List<Todo> list = new List<Todo>();
            try
            {
                using(var httpClient = new HttpClient())
                {
                    httpClient.BaseAddress = new Uri(ApiBaseUrl);
                    var result = await httpClient.GetAsync(ApiPostPath);
                    var resultContent = await result.Content.ReadAsStringAsync();
                    Console.WriteLine(resultContent);
                    list = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Todo>>(resultContent);
                }
                return list;
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
        public async Task<Todo> FindById(int id)
        {
            try
            {
                using(var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(ApiBaseUrl);
                    var result = await client.GetAsync($"{ApiPostPath}/{id}");
                    var resultContent = await result.Content.ReadAsStringAsync();
                    var todo = Newtonsoft.Json.JsonConvert.DeserializeObject<Todo>(resultContent);
                    Console.WriteLine(todo);
                    return todo;
                }
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
        public async Task<bool> Update(int id, Todo updateTodo)
        {
            try
            {
                using(var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(ApiBaseUrl);
                    var jsonContent = Newtonsoft.Json.JsonConvert.SerializeObject(updateTodo);
                    var contentToSend = new StringContent(jsonContent, Encoding.UTF8, ApiDataType);
                    var result = await client.PutAsync($"{ApiPostPath}/{id}", contentToSend);
                    string resultContent = await result.Content.ReadAsStringAsync();
                    Console.WriteLine(resultContent);
                    return true;
                }
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
        public async Task<bool> DeleteTodo(int id)
        {
            try
            {
                using(var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(ApiBaseUrl);
                    var result = await client.DeleteAsync($"{ApiPostPath}/{id}");
                    var resultContent = await result.Content.ReadAsStringAsync();
                    Console.WriteLine("delete success");
                    return true;
                }
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
    }
}
