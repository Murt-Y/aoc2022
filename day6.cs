using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;  

namespace aoc2022
{
    class D6
    {
        string[] ReadMyInput()
        {
        string text = File.ReadAllText(@"/users/muratyilmaz/Documents/aoc2022/6.txt");
        string[] move = text.Split("\n");
        return move;

        }

        bool Compare(string t)
        {
            int l =t.Count();
        if(l==1)
        {
            return true;
        }
        char x = t[0];
        string check=t.Substring(1,l-1);

        if(check.Contains(x))
        {
            return false;
        }
        else{
            return Compare(check);
        }
        }


       int Part1()
        {
        string[] code =ReadMyInput();
        string init =code[0].Substring(0,4);

        int marker=4;
        while(marker<code[0].Count())
        {
        if(Compare(init))
        {
            return marker;
        }
        marker ++;
        init=code[0].Substring(marker-4,4);
        }

        

        return 0;
        }
        int Part2()
        {
        string[] code =ReadMyInput();
        string init =code[0].Substring(0,14);

        int marker=14;
        while(marker<code[0].Count())
        {
        if(Compare(init))
        {
            return marker;
        }
        marker ++;
        init=code[0].Substring(marker-14,14);
        }

        

        return 0;

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