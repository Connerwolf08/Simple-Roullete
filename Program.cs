using System;
using System.Threading;

namespace Table {

    struct GambleObj {
        public bool state;
        public int balance;
        public int seed;
        public string roll;
        public string bet;
        public int amt;
    }
    internal class Program
    {
        public static void RunTime(int starting_balance) {
            GambleObj pool = new GambleObj();
            pool.state = true;
            pool.balance = starting_balance;
            pool.roll = "Pending";
            pool.seed = 1234;
            pool.bet = "Pending";
            pool.amt = 0;
            while (pool.state) {
                Console.Clear();
                Console.WriteLine("==== Balance: {0} =({1})= Roll: {2} ====", pool.balance, pool.seed, pool.roll);
                if (pool.balance <= 0) {
                    pool.state = false;
                    break;
                }
                Console.Write("[BET]: ");
                pool.bet = Console.ReadLine();
                Console.Write("[AMT]: ");
                pool.amt = Convert.ToInt32(Console.ReadLine());
                while (pool.amt > pool.balance)
                {
                    Console.WriteLine("Not Enough Balance");
                    Console.Write("[AMT]: ");
                    pool.amt = Convert.ToInt32(Console.ReadLine());
                }
                Random num = new Random();
                int outcome = num.Next(1, 100);
                pool.balance = pool.balance - pool.amt;
                pool.seed = outcome;
                if (outcome <= 40) {
                    pool.roll = "Red";
                }
                else if (outcome <= 80)
                {
                    pool.roll = "Black";
                }
                else {
                    pool.roll = "Green";
                }
                if (pool.roll == pool.bet)
                {
                    if (pool.bet == "Red")
                    {
                        pool.balance = (pool.amt * 2) + pool.balance;
                        Console.WriteLine("You Win!!! ${0}", pool.amt * 2);
                        Thread.Sleep(2000);
                    }
                    else if (pool.bet == "Black")
                    {
                        pool.balance = (pool.amt * 2) + pool.balance;
                        Console.WriteLine("You Win!!! ${0}", pool.amt * 2);
                        Thread.Sleep(2000);
                    }
                    else if (pool.bet == "Green")
                    {
                        pool.balance = (pool.amt * 14) + pool.balance;
                        Console.WriteLine("You Win!!! ${0}", pool.amt * 14);
                        Thread.Sleep(2000);
                    }
                    else
                    {
                        Console.WriteLine("Invalid Bet.");
                    }
                }
                else {
                    Console.WriteLine("You Lose!!! ${0}", pool.amt);
                    Thread.Sleep(2000);
                }
            }
        }
        public static void Main() {
            RunTime(1000);
        }
    }

}