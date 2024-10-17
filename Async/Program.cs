namespace Async
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Task<string> slowDog = SlowDogAsync();
            Task<string> fastDog = FastDogAsync();

            string slowDogResult = await slowDog;
            string fastDogResult = await fastDog;

            Console.WriteLine(slowDogResult);
            Console.WriteLine(fastDogResult);

            LongProcess();
            ShortProcess();

            Task<int> result = AnotherLongProcess();
            Console.WriteLine($"Result: {await result}");

            Console.ReadLine();
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
