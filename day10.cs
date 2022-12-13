using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;  

namespace aoc2022
{
    class D10
    {
        string[] ReadMyInput()
        {
        string text = File.ReadAllText(@"/users/muratyilmaz/Documents/aoc2022/10.txt");
        string[] move = text.Split("\n");
        return move;

        }




       int Part1()
        {
        string[] code =ReadMyInput();

        int [] cval = new int[221];
        int cycle = 1;
        cval[0]=1;

        foreach (string c in code)
        {
            if(cycle>=220)
            {
                break;
            }
            string [] command = c.Split(" ");
            if(command[0]=="noop")
            {
            cval[cycle]=cval[cycle-1];
            cycle++;
            }
            else if(command[0]=="addx")
            {
            cval[cycle]=cval[cycle-1];
            cycle++;
            cval[cycle]=cval[cycle-1]+Convert.ToInt32(command[1]);
            cycle++;

            }


        }

        int signal = cval[19]*20 + cval[59]*60 + cval[99]*100 + cval[139]*140 + cval[179]*180 + cval[219]*220;

        return signal;
        }
        int Part2()
        {
        string[] code =ReadMyInput();

        int [] cval = new int[240];
        int cycle = 0;
        int spos=1;


        void Draw(int c, int p)
        {
            if (c%40==0)
            {
                Console.WriteLine();
            }
            c=c%40;
            if (c<=p+1 && c>=p-1)
            {
                Console.Write("#");
            }
            else
            {
                Console.Write(".");
            }
        }
        foreach (string c in code)
        {
            if(cycle>=240)
            {
                break;
            }

            string [] command = c.Split(" ");
            if(command[0]=="noop")
            {
            Draw(cycle, spos);
            cycle++;
            }
            else if(command[0]=="addx")
            {
            Draw(cycle, spos);
            cycle++;
            Draw(cycle, spos);
            cycle++;
            spos=spos+Convert.ToInt32(command[1]);
            }


        }

        Console.WriteLine();

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