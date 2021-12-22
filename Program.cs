using Flee;
using System.Linq;

namespace Codewars_Sharp
{
    class Program
    {
        public static void Main(string[] args)
        {
            TestGreedGame();
        }

        private static void TestGreedGame()
        {
            int[] dice1 = { 5, 1, 3, 4, 1 };
            int[] dice2 = { 6, 6, 6, 6, 6, 6, 3, 3, 3, 3, 3 };
            int[] dice3 = { 1, 1, 1, 1, 3 };
            int[] dice4 = { 4, 4, 4, 3, 3 };
            int[] dice5 = { 5, 5, 5, 5, 2 };
            int[] finalDice = { 1, 1, 1, 1, 1, 1, 1, 5, 5, 5, 5, 2, 2, 2, 3, 3 };
            var result = GreedGame.Score(dice3);
            Console.WriteLine(result);
        }
    }
}