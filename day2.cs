using System;
using System.IO;
using System.Collections.Generic;

namespace aoc2022
{
    class D2
    {
        string[] ReadMyInput()
        {
        string text = File.ReadAllText(@"/users/muratyilmaz/Documents/aoc2022/2.txt");
        string[] move = text.Split("\n");
        return move;

        }

       int Part1()
        {
        string[] moveindex =ReadMyInput();
        int score = 0;


        foreach(string s in moveindex)
        {
            string[] x =s.Split(" ");
            char[] d = {'0','0'};
            d[0]=Convert.ToChar(x[0]);
            d[1]=Convert.ToChar(x[1]);
            if(d[1]=='X')
            {
                score=score+1;
                if(d[0]=='A')
                {
                    score=score+3;
                }
                else if(d[0]=='C')
                {
                    score=score+6;
                }
            }
            else if(d[1]=='Y')
            {
                score=score+2;
                if(d[0]=='B')
                {
                    score=score+3;
                }
                else if(d[0]=='A')
                {
                    score=score+6;
                }
            }
            else if(d[1]=='Z')
            {
                score=score+3;
                if(d[0]=='C')
                {
                    score=score+3;
                }
                else if(d[0]=='B')
                {
                    score=score+6;
                }
            }
        }
        return score;
        }
        int Part2()
        {
        string[] moveindex =ReadMyInput();
        int score = 0;


        foreach(string s in moveindex)
        {
            string[] x =s.Split(" ");
            char[] d = {'0','0'};
            d[0]=Convert.ToChar(x[0]);
            d[1]=Convert.ToChar(x[1]);
            if(d[1]=='X')
            {
                if(d[0]=='A')
                {
                    score=score+3;
                }
                else if(d[0]=='B')
                {
                    score=score+1;
                }
                else if(d[0]=='C')
                {
                    score=score+2;
                }
            }
            else if(d[1]=='Y')
            {
                score=score+3;
                if(d[0]=='A')
                {
                    score=score+1;
                }
                else if(d[0]=='B')
                {
                    score=score+2;
                }
                else if(d[0]=='C')
                {
                    score=score+3;
                }
            }
            else if(d[1]=='Z')
            {
                score=score+6;
                if(d[0]=='A')
                {
                    score=score+2;
                }
                else if(d[0]=='B')
                {
                    score=score+3;
                }
                else if(d[0]=='C')
                {
                    score=score+1;
                }
            }

        }
        return score;
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