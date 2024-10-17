namespace Async
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            LongProcess();
            ShortProcess();

            Task<int> result = AnotherLongProcess();
            Console.WriteLine($"Result: {await result}");

            Console.ReadLine();
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
