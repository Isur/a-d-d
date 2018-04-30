using Common;
using System.Threading;

namespace Common_Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Logger.Info("Rozpoczęcie działania programu");
            Thread.Sleep(1000);
            Logger.Warning("Wielokrotnie nieudana próba logowania");
            Thread.Sleep(1000);
            Logger.Error("Próba dodania użytkownika z lustym hasłem");
            Thread.Sleep(1000);
            Logger.Fatal("Błąd krytyczny... Zamykanie programu...");
        }
    }
}
