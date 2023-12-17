namespace Threading
{
    internal class Car
    {
        Random random = new Random();
        public string Name { get; }
        public double Distance { get; private set; }
        public int Speed { get; private set; }

        private int RunRandomCarIssue = 0;

        public static string winner = "";

        public Car(string name)
        {
            Name = name;
            Distance = 0;
            Speed = 120;
        }

        public async Task RaceAsync()
        {
            Console.WriteLine($"{Name} starts!");
            while (Distance < 10)
            {
                await Task.Delay(1000);
                Distance += Speed / 3600.0;
                if (RunRandomCarIssue % 30 == 0)
                {
                    RandomCarIssues();
                }

                RunRandomCarIssue++;
            }

            if (Distance >= 10)
            {
                Console.WriteLine($"{Name} crossed the finish line!");
                string currentWinner = Name;
                Interlocked.CompareExchange(ref winner, currentWinner, "");

                if(Name == winner)
                {
                    Console.WriteLine($"{winner} won the race!");
                }
            }
        }

        public void RandomCarIssues()
        {
            int chance = random.Next(50);

            if (chance == 0)
            {
                Console.WriteLine($"{Name} stops for refueling for 30 sec.");
                Thread.Sleep(30000);
            }
            else if (chance <= 2)
            {
                Console.WriteLine($"{Name} has tire puncture and stops to change tires for 20 sec.");
                Thread.Sleep(20000);
            }
            else if (chance <= 7)
            {
                Console.WriteLine($"{Name} got a bird in its windshield and stops to clean it for 10 sec.");
                Thread.Sleep(10000);
            }
            else if (chance <= 17)
            {
                Console.WriteLine($"{Name} has angine failure and speed declines with 1 km/h.");
                Speed -= 1;
            }
        }
    }
}