using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wordleconsole
{
    public record Day(string word, bool used, int day)
    {
        public override string ToString()
        {
            return $"DAY [{day}, {word}, {used}]";

        }
    }
    public record Stat(int day, int guesses, int streak, int maxStreak, ValueTuple<int, int, int, int, int, int> guessDistribution)
    {
        public override string ToString()
        {
            return $"STAT [ {day}, {guesses}, {streak}, {maxStreak}, {guessDistribution}]";
        }
    }

}
