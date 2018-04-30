using DAL;
using System;

namespace DAL_Test
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (var user in UsersRepository.GetList())
            {
                Console.WriteLine($"{user.Id} : {user.FirstName} : {user.LastName}");
            }

            Console.WriteLine("done!");
            Console.ReadKey();
        }
    }
}
