namespace Threading
{
    internal class Program
    {
        static async Task Main(string[] args)
        {

            Car competitor1 = new Car("Volvo");
            Car competitor2 = new Car("Citroen");

            Console.WriteLine("Ready, set, GO!");

            Task race1 = Task.Run(competitor1.RaceAsync);
            Task race2 = Task.Run(competitor2.RaceAsync);

            while (!race1.IsCompleted || !race2.IsCompleted)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey(intercept: true);

                    if (keyInfo.Key == ConsoleKey.Enter)
                    {
                        Console.WriteLine("\nStatus:");
                        Console.WriteLine($"{competitor1.Name}: {competitor1.Distance:0.#} km, {competitor1.Speed} km/h");
                        Console.WriteLine($"{competitor2.Name}: {competitor2.Distance:0.#} km, {competitor2.Speed} km/h");
                    }
                }
            }

            await Task.WhenAll(race1, race2);
            Console.ReadLine();
        }
    }
}
