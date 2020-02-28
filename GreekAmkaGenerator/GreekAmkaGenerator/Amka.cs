using System;
using System.Linq;

namespace GreekAmkaGenerator
{
    public static class Amka
    {
        static readonly int[] Results = { 0, 2, 4, 6, 8, 1, 3, 5, 7, 9 };

        public static string GenerateAmka()
        {
            var amka = RandomDay().ToString("ddMMyy") + RandomNumber();
            return amka.GetAmkaWithDigit();
        }

        static string RandomNumber()
        {
            Random random = new Random();
            return random.Next(1, 1000).ToString("0000");
        }

        static DateTime RandomDay()
        {
            Random gen = new Random();
            DateTime start = new DateTime(1900, 1, 1);
            int range = (DateTime.Today - start).Days;
            return start.AddDays(gen.Next(range));
        }

        public static string GetAmkaWithDigit(this string amka)
        {
            var i = 0;
            var digits = amka.Select(d => d - 48).ToList();
            var lengthMod = digits.Count % 2;
            var s = (digits.Sum(d => i++ % 2 == lengthMod ? d : Results[d]) * 9) % 10;
            return amka + s;
        }
    }
}
