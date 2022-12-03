using System;
using System.IO;
using System.Collections.Generic;

namespace aoc2022
{
    class D3
    {
        string[] ReadMyInput()
        {
        string text = File.ReadAllText(@"/users/muratyilmaz/Documents/aoc2022/3.txt");
        string[] move = text.Split("\n");
        return move;

        }

       int Part1()
        {
        string[] ruck =ReadMyInput();
        int priority = 0;


        foreach(string s in ruck)
        {
            int pval=0;
            int c= s.Count();
            string comp1=s.Substring(0,c/2);
            string comp2=s.Substring(c/2,c/2);
            bool pair=false;
            while (pair==false)
            {
                foreach(char x in comp1)
                {
                    foreach(char y in comp2)
                    {
                        if (x==y)
                        {
                            pair=true;
                            if(x>='A' && x<'a')
                            {
                            pval=x-'A'+27;
                            }
                            else
                            {
                            pval=x-'a'+1;
                            }
                            priority=priority+pval;
                            break;
                        }
                    }
                    if(pair==true)
                    {
                        break;
                    }
                }
            }
            
        }
        return priority;
        }
        int Part2()
        {

        string[] ruck =ReadMyInput();
        int priority = 0;
        int count=ruck.Count();
        int i=0;
        while (i<count)
        {
            int pval=0;
            bool pair=false;
            foreach(char x in ruck[i])
            {
                
                foreach(char y in ruck[i+1])
                {
                    foreach(char z in ruck[i+2])
                    {
                        if(x==y && y==z)
                        {
                            if(x>='A' && x<'a')
                            {
                            pval=x-'A'+27;
                            }
                            else
                            {
                            pval=x-'a'+1;
                            }
                            priority=priority+pval;
                            pair=true;
                            break;
                        }
                    }
                         if(pair==true)
                        {
                            break;
                        }               
                }
                        if(pair==true)
                        {
                            break;
                        }
            }


            i=i+3;
        }


        return priority;
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