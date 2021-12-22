using Flee.PublicTypes;

namespace Codewars_Sharp
{
    public class GreedGame
    {
        static ExpressionContext context = new ExpressionContext();
        static int[] acceptableRange = { 2, 3, 4, 6 };

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
            Func<int, bool> than3 = value => value >= 3;
            int howManyPairs = keyValue.Value / 3;
            string calculation = $"({keyValue.Key * 100} * {keyValue.Value / 3})";

            if (acceptableRange.Contains(keyValue.Key))
            {
                if (than3(keyValue.Value))
                {
                    return calculation;
                }
            }
            else if (keyValue.Key == 5)
            {
                calculation = $"({keyValue.Key * 10} * {keyValue.Value - (howManyPairs * 3)})";
                if (than3(keyValue.Value))
                {
                    int times100 = 0;
                    foreach (int pair in Enumerable.Range(0, howManyPairs))
                    {
                        times100++;
                    }
                    calculation = string.Concat(calculation, $" + ({(keyValue.Key * 100) * times100})");
                }
                return calculation;
            }
            else if (keyValue.Key == 1)
            {
                calculation = $"({keyValue.Key * 100} * {keyValue.Value - (howManyPairs * 3)})";
                if (than3(keyValue.Value))
                {
                    int times1000 = 0;
                    foreach (int pair in Enumerable.Range(0, howManyPairs))
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