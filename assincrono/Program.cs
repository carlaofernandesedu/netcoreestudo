using System;
using System.Threading;
using System.Threading.Tasks;

namespace assincrono
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // 1 MELHORIA
            // Coffee cup = PourCoffee();
            // Console.WriteLine("coffee is ready");
            // Task<Egg> taskEggs = FryEggsAsync(2);
            // Egg eggs = await taskEggs;
            // Console.WriteLine("eggs are ready");
            // Task<Bacon> taskbacon = FryBaconAsync(3);
            // Bacon bacon = await taskbacon;
            //  Console.WriteLine("bacon is ready");
            // Task<Toast> tasktoast = ToastBreadAsync(2);
            // Toast toast = await tasktoast;
            // ApplyButter(toast);
            // ApplyJam(toast);
            // Console.WriteLine("toast is ready");
            // Juice oj = PourOJ();
            // Console.WriteLine("oj is ready");
            // Console.WriteLine("Breakfast is ready!");


            // 2 MEHLORIA 
            // Coffee cup = PourCoffee();
            // Console.WriteLine("coffee is ready");
            // Task<Egg> taskEggs = FryEggsAsync(2);
            // Task<Bacon> taskbacon = FryBaconAsync(3);
            // Task<Toast> tasktoast = ToastBreadAsync(2);
            // Toast toast = await tasktoast;
            // ApplyButter(toast);
            // ApplyJam(toast);
            // Console.WriteLine("toast is ready");
            // Juice oj = PourOJ();
            // Console.WriteLine("oj is ready");
            // Egg eggs = await taskEggs;
            // Console.WriteLine("eggs are ready");
            // Bacon bacon = await taskbacon;
            // Console.WriteLine("bacon is ready");
            // Console.WriteLine("Breakfast is ready!");

            Coffee cup = PourCoffee();
            Console.WriteLine("coffee is ready");
            Task<Egg> taskEggs = FryEggsAsync(2);
            Task<Bacon> taskbacon = FryBaconAsync(3);
            Task<Toast> tasktoast = ToastBreadWithButterAndJamAsync(2);
            Toast toast = await tasktoast;
            Console.WriteLine("toast is ready");
            Bacon bacon = await taskbacon;
            Console.WriteLine("bacon is ready");
            Egg eggs = await taskEggs;
            Console.WriteLine("eggs are ready");
            Juice oj = PourOJ();
            Console.WriteLine("oj is ready");
            Console.WriteLine("Breakfast is ready!");
        }

        private static void ApplyJam(Toast toast)
        {
            var x = 2 + 1;
        }

        private static void ApplyButter(Toast toast)
        {
            var x = 2 + 1;
        }

        private static Juice PourOJ()
        {
            return new Juice();
        }

        private static Toast ToastBread(int v)
        {
             Thread.Sleep(4000);
             return new Toast();
        }

        private static Bacon FryBacon(int v)
        {
             Thread.Sleep(3000);
             return new Bacon();
        }

        private static Egg FryEggs(int v)
        {
             Thread.Sleep(2000);
             return new Egg();
        }

        private static Coffee PourCoffee()
        {
            return new Coffee();
        }

        private static async Task<Toast> ToastBreadAsync(int v)
        {
             await Task.Delay(4000);
             return new Toast();
        }

        private static async Task<Toast> ToastBreadWithButterAndJamAsync(int v)
        {
             var toast = await ToastBreadAsync(v);
             ApplyButter(toast);
             ApplyJam(toast);
             return toast;
        }

        private static async Task<Bacon> FryBaconAsync(int v)
        {
             await Task.Delay(3000);
             return new Bacon();
        }

        private static async Task<Egg> FryEggsAsync(int v)
        {
             await Task.Delay(2000);
             return new Egg();
        }


    }

    internal class Coffee
    {
    }

    internal class Egg
    {
    }

    internal class Bacon
    {
    }

    internal class Toast
    {
    }

    internal class Juice
    {
    }
}
