using Flee.PublicTypes;

namespace Codewars_Sharp
{
    /// <summary>
    /// Greed Is Good is a game where dice are thrown. Each die has 6 sides. 
    /// <para>Sides 1 and 5 contribute to the score by 100 and 50 points respectively.</para>
    /// <para>Trios of sides award 100 times their value (except for side 1, which awards 10 times its value).</para>
    /// <para>Sides other than 1 and 5 can't contribute unless they're trios.</para>
    /// </summary>
    public class GreedGame
    {
        static ExpressionContext context = new ExpressionContext();
        static int[] acceptableRange = { 2, 3, 4, 6 };

        /// <summary>
        /// Transform an array of dice into a string that gets concatenated with members when appropriate and its treated as a mathmetical expression.
        /// </summary>
        /// <param name="dice">Collection of dice. Can be of any size.</param>
        /// <returns></returns>
        public static int Score(int[] dice)
        {
            int score = 0;
            string equation = "";

            Dictionary<int, int> diceCount = new Dictionary<int, int>();

            foreach (int die in dice)
            {
                if (!diceCount.ContainsKey(die))
                {
                    diceCount.Add(die, 0);
                }
                diceCount[die] += 1;
            }

            foreach (KeyValuePair<int, int> keyValue in diceCount)
            {
                Console.WriteLine($"{keyValue.Key} appears {keyValue.Value} times");

                var dieScore = DefineDieScore(keyValue);
                if (dieScore == null) continue;
                dieScore = string.Concat(dieScore, " + ");
                equation = string.Concat(equation, dieScore);

            }

            // this is a spaghetti fix
            // looking for solutions
            if (equation.EndsWith(" + "))
            {
                equation = equation.Substring(0, equation.Length - 3);
            }

            Console.WriteLine(equation);
            if (equation != "")
            {
                IDynamicExpression e = context.CompileDynamic(equation);

                score = (int)e.Evaluate();
            }

            return score;
        }
        private static string? DefineDieScore(KeyValuePair<int, int> keyValue)
        {
            Func<int, bool> largerOrEqualTo3 = value => value >= 3;
            int howManyTrios = keyValue.Value / 3;
            string calculation = $"({keyValue.Key * 100} * {keyValue.Value / 3})";

            if (acceptableRange.Contains(keyValue.Key))
            {
                if (largerOrEqualTo3(keyValue.Value))
                {
                    return calculation;
                }
            }
            else if (keyValue.Key == 5)
            {
                calculation = $"({keyValue.Key * 10} * {keyValue.Value - (howManyTrios * 3)})";
                if (largerOrEqualTo3(keyValue.Value))
                {
                    int times100 = 0;
                    foreach (int pair in Enumerable.Range(0, howManyTrios))
                    {
                        times100++;
                    }
                    calculation = string.Concat(calculation, $" + ({(keyValue.Key * 100) * times100})");
                }
                return calculation;
            }
            else if (keyValue.Key == 1)
            {
                calculation = $"({keyValue.Key * 100} * {keyValue.Value - (howManyTrios * 3)})";
                if (largerOrEqualTo3(keyValue.Value))
                {
                    int times1000 = 0;
                    foreach (int pair in Enumerable.Range(0, howManyTrios))
                    {
                        times1000++;
                    }
                    calculation = string.Concat(calculation, $" + ({(keyValue.Key * 1000) * times1000})");
                }
                return calculation;
            }
            return null;
        }
    }
}