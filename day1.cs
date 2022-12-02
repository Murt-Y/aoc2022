using System;
using System.IO;
using System.Collections.Generic;

namespace aoc2022
{
    class D1
    {
        string[] ReadMyInput()
        {
        string text = File.ReadAllText(@"/users/muratyilmaz/Documents/aoc2022/1.txt");
        string[] cals = text.Split("\n\n");
        return cals;

        }
        public int [] Solution()
        {
        string[] deerindex =ReadMyInput();
        int deers = deerindex.Count();
        int maxcal1=0;
        int maxcal2=0;
        int maxcal3=0;

        foreach(string s in deerindex)
        {
            string[] d =s.Split("\n");
            int i=0;
            foreach (string x in d)
            {
                int k=Convert.ToInt32(x);
                i=i+k;
            }
            if (i>maxcal1)
            {
                maxcal3=maxcal2;
                maxcal2=maxcal1;
                maxcal1=i;
            }
            else if(i>maxcal2)
            {
                maxcal3=maxcal2;
                maxcal2=i;
            }
                        else if(i>maxcal3)
            {
                maxcal3=i;
            }
        }
        int[] result = {maxcal1, maxcal1+maxcal2+maxcal3};
        return result;
        }



    }
}