using System;
using System.Text.Json;

namespace Async
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var person = new Person {Name = "Joakim", Age = 37 };
            string jsonString = JsonSerializer.Serialize(person);
            Console.WriteLine(jsonString);
            Person deserializePerson = JsonSerializer.Deserialize<Person>(jsonString);
            Console.WriteLine(deserializePerson.Name + " " + deserializePerson.Age);

            /*string jsonData = await FetchData();
            Console.WriteLine(jsonData);*/

            /*Task<string> slowDog = SlowDogAsync();
            Task<string> fastDog = FastDogAsync();

            string slowDogResult = await slowDog;
            string fastDogResult = await fastDog;

            Console.WriteLine(slowDogResult);
            Console.WriteLine(fastDogResult);

            LongProcess();
            ShortProcess();

            Task<int> result = AnotherLongProcess();
            Console.WriteLine($"Result: {await result}");*/

            Console.ReadLine();
        }

        static async Task<string> FetchData()
        {
            using var client = new HttpClient();

            try
            {
                var url = "https://jsonplaceholder.typicode.com/users";
                //using HttpResponseMessage response = await client.GetAsync(url);
                //string responseBody = await response.Content.ReadAsStringAsync();
                string response = await client.GetStringAsync(url);

                return response;
            }
            catch(HttpRequestException ex)
            {
                return $"Http: {ex}";
            }
            catch (Exception ex)
            {
                return $"Ex: {ex}";
            }
        }

        static async Task<string> SlowDogAsync()
        {
            Console.WriteLine($"Långsam hund startar {DateTime.Now}");
            await Task.Delay(3000);
            return "Långsam hund är tillbaka om 3 sekunder!";
        }
        static async Task<string> FastDogAsync()
        {
            Console.WriteLine($"Snabb hund startar {DateTime.Now}");
            await Task.Delay(1000);
            return "Snabb hund är tillbaka om 1 sekunder!";
        }

        static async Task<int> AnotherLongProcess()
        {
            Console.WriteLine("Another Long process start!");
            await Task.Delay(2000);
            Console.WriteLine("Another Long process complete!");
            return 10;
        }

        static async void LongProcess()
        {
            Console.WriteLine("Long process start!");
            await Task.Delay(2000);
            Console.WriteLine("Long process complete!");
        }

        static void ShortProcess()
        {
            Console.WriteLine("Short process start!");
            Console.WriteLine("Short process complete!");
        }
    }
}

public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
}

