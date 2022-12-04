using System;
using System.IO;
using System.Collections.Generic;

namespace aoc2022
{
    class D4
    {
        string[] ReadMyInput()
        {
        string text = File.ReadAllText(@"/users/muratyilmaz/Documents/aoc2022/4.txt");
        string[] move = text.Split("\n");
        return move;

        }

       int Part1()
        {
        string[] task =ReadMyInput();
        int lap = 0;

        foreach (string s in task)
        {
            string [] partners = s.Split(",");

            string [] partner1s = partners[0].Split("-");
            int[] partner1 = {0,0};
            partner1[0]=Convert.ToInt32(partner1s[0]);
            partner1[1]=Convert.ToInt32(partner1s[1]);
            string [] partner2s = partners[1].Split("-");
            int[] partner2 = {0,0};
            partner2[0]=Convert.ToInt32(partner2s[0]);
            partner2[1]=Convert.ToInt32(partner2s[1]);

            if((partner1[0]>=partner2[0] && partner1[1]<=partner2[1]) || (partner2[0]>=partner1[0] && partner2[1]<=partner1[1]))
            {
                lap++;
            }
            else if ((partner1[0]<=partner2[0] && partner1[1]>=partner2[1]) || (partner2[0]<=partner1[0] && partner2[1]>=partner1[1]) )
            {
                lap++;
            }

        }



        return lap;
        }
        int Part2()
        {
        string[] task =ReadMyInput();
        int lap = 0;

        foreach (string s in task)
        {
            string [] partners = s.Split(",");

            string [] partner1s = partners[0].Split("-");
            int[] partner1 = {0,0};
            partner1[0]=Convert.ToInt32(partner1s[0]);
            partner1[1]=Convert.ToInt32(partner1s[1]);
            string [] partner2s = partners[1].Split("-");
            int[] partner2 = {0,0};
            partner2[0]=Convert.ToInt32(partner2s[0]);
            partner2[1]=Convert.ToInt32(partner2s[1]);

            if((partner2[0]<=partner1[1] && partner2[0]>=partner1[0]) || (partner2[1]>=partner1[0] && partner2[1]<=partner1[1]))
            {
                lap++;
            }
            else if((partner1[0]<=partner2[1] && partner1[0]>=partner2[0]) || (partner1[1]>=partner2[0] && partner1[1]<=partner2[1]))
            {
                lap++;
            }

        }



        return lap;
        }
        public int [] Solution()
        {
        int[] result = {0,0};
        result[0]=Part1();
        result[1]=Part2();
        return result;
        }



    }
}