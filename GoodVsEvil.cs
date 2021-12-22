using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codewars_CSharp
{
    public class GoodVsEvil
    {
        public static void TestGoodVsEvil(string[] args)
        {
            string goodTest = "0 0 0 0 0 10";
            string evilTest = "0 1 1 1 1 0 0";

            var result = GoodVsEvil.MakeJudgement(goodTest, evilTest);
            Console.WriteLine(result);
        }
        public class UnitWorth
        {
            public const int Hobbits = 1;
            public const int Men = 2;
            public const int Elves = 3;
            public const int Dwarves = 3;
            public const int Eagles = 4;
            public const int Wizards = 10;
            public const int Orcs = 1;
            public const int Wargs = 2;
            public const int Goblins = 2;
            public const int UrukHai = 3;
            public const int Trolls = 5;
        }


        //The Good: Hobbits, Men, Elves, Dwarves, Eagles, Wizards.
        //The Evil: Orcs, Men, Wargs, Goblins, Uruk Hai, Trolls, Wizards.
        public static string MakeJudgement(string good, string evil)
        {
            int goodWorth = 0;
            int evilWorth = 0;

            int[] goodArray = good.Split(" ").Select(n => Convert.ToInt32(n)).ToArray();
            int[] evilArray = evil.Split(" ").Select(n => Convert.ToInt32(n)).ToArray();


            Dictionary<int, int[]> goodUnitsCount = new Dictionary<int, int[]>()
            {
                { 1, new int[]{ UnitWorth.Hobbits, goodArray[0] } },
                { 2, new int[]{ UnitWorth.Men, goodArray[1] }},
                { 3, new int[]{ UnitWorth.Elves, goodArray[2] }},
                { 4, new int[]{ UnitWorth.Dwarves, goodArray[3] }},
                { 5, new int[]{ UnitWorth.Eagles, goodArray[4] }},
                { 6, new int[]{ UnitWorth.Wizards, goodArray[5] }},
            };

            Dictionary<int, int[]> evilUnitsCount = new Dictionary<int, int[]>()
            {
                {1, new int[]{ UnitWorth.Orcs, evilArray[0] } },
                {2, new int[]{ UnitWorth.Men, evilArray[1] }},
                {3, new int[]{ UnitWorth.Wargs, evilArray[2] }},
                {4, new int[]{ UnitWorth.Goblins, evilArray[3] }},
                {5, new int[]{ UnitWorth.UrukHai, evilArray[4] }},
                {6, new int[]{ UnitWorth.Trolls, evilArray[5] }},
                {7, new int[]{ UnitWorth.Wizards, evilArray[6] }},
            };

            foreach (KeyValuePair<int, int[]> keyValue in goodUnitsCount)
            {
                goodWorth += keyValue.Value[0] * keyValue.Value[1];
            }

            foreach (KeyValuePair<int, int[]> keyValue in evilUnitsCount)
            {
                evilWorth += keyValue.Value[0] * keyValue.Value[1];
            }



            Console.WriteLine(goodWorth);
            Console.WriteLine(evilWorth);
            Console.WriteLine("");

            if (goodWorth > evilWorth)
            {
                return "Battle Result: Good triumphs over Evil";
            }
            else if (goodWorth < evilWorth)
            {
                return "Battle Result: Evil eradicates all trace of Good";
            }

            return "Battle Result: No victor on this battle field";
        }
    }
}

