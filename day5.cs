using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;  

namespace aoc2022
{
    class D5
    {
        string[] ReadMyInput()
        {
        string text = File.ReadAllText(@"/users/muratyilmaz/Documents/aoc2022/5.txt");
        string[] move = text.Split("\n");
        return move;

        }

       int Part1()
        {
        string[] task =ReadMyInput();
        string[] stack1 = {"R" ,"S", "L" , "F", "Q"};
        string[] stack2 = {"N" ,"Z", "Q" , "G", "P", "T"};
        string[] stack3 = {"S" ,"M", "Q" , "B"};
        string[] stack4 = {"T" ,"G", "Z" , "J", "H", "C", "B", "Q"};
        string[] stack5 = {"P" ,"H", "M" , "B", "N", "F", "S"};
        string[] stack6 = {"P" ,"C", "Q" , "N", "S", "L", "V", "G"};
        string[] stack7 = {"W" ,"C", "F"};
        string[] stack8 = {"Q" ,"H", "G" , "Z", "W", "V", "P", "M"};
        string[] stack9 = {"G" ,"Z", "D" , "L", "C", "N", "R"};

        List<int> stackcount = new List<int>();
        stackcount.Add(stack1.Count());
        stackcount.Add(stack2.Count());
        stackcount.Add(stack3.Count());
        stackcount.Add(stack4.Count());
        stackcount.Add(stack5.Count());
        stackcount.Add(stack6.Count());
        stackcount.Add(stack7.Count());
        stackcount.Add(stack8.Count());
        stackcount.Add(stack9.Count());


        List<string[]> stacks = new List<string[]>();
        stacks.Add(stack1);
        stacks.Add(stack2);
        stacks.Add(stack3);
        stacks.Add(stack4);
        stacks.Add(stack5);
        stacks.Add(stack6);
        stacks.Add(stack7);
        stacks.Add(stack8);
        stacks.Add(stack9);


        foreach (string s in task)
        {
            string [] commands = s.Split(" ");
            int r= Convert.ToInt32(commands[1]);
            int from = Convert.ToInt32(commands[3]);
            int dest = Convert.ToInt32(commands[5]);
            while (r>0)
            {
                string temp = stacks[from-1][stackcount[from-1]-1];
                stacks[from-1]=stacks[from-1].Take(stackcount[from-1]-1).ToArray();
                stackcount[from-1]--;

                stacks[dest-1]=stacks[dest-1].Append(temp).ToArray();
                stackcount[dest-1]++;
                

                r--;
            }

        }
        string res1="Result for Part 1 is : ";
        int c=0;
        while (c<9)
        {
            res1=res1+stacks[c][stackcount[c]-1];   
            c++;
        }
        Console.WriteLine(res1);
        

        return 0;
        }
        int Part2()
        {
        string[] task =ReadMyInput();
        string[] stack1 = {"R" ,"S", "L" , "F", "Q"};
        string[] stack2 = {"N" ,"Z", "Q" , "G", "P", "T"};
        string[] stack3 = {"S" ,"M", "Q" , "B"};
        string[] stack4 = {"T" ,"G", "Z" , "J", "H", "C", "B", "Q"};
        string[] stack5 = {"P" ,"H", "M" , "B", "N", "F", "S"};
        string[] stack6 = {"P" ,"C", "Q" , "N", "S", "L", "V", "G"};
        string[] stack7 = {"W" ,"C", "F"};
        string[] stack8 = {"Q" ,"H", "G" , "Z", "W", "V", "P", "M"};
        string[] stack9 = {"G" ,"Z", "D" , "L", "C", "N", "R"};

        List<int> stackcount = new List<int>();
        stackcount.Add(stack1.Count());
        stackcount.Add(stack2.Count());
        stackcount.Add(stack3.Count());
        stackcount.Add(stack4.Count());
        stackcount.Add(stack5.Count());
        stackcount.Add(stack6.Count());
        stackcount.Add(stack7.Count());
        stackcount.Add(stack8.Count());
        stackcount.Add(stack9.Count());


        List<string[]> stacks = new List<string[]>();
        stacks.Add(stack1);
        stacks.Add(stack2);
        stacks.Add(stack3);
        stacks.Add(stack4);
        stacks.Add(stack5);
        stacks.Add(stack6);
        stacks.Add(stack7);
        stacks.Add(stack8);
        stacks.Add(stack9);


        foreach (string s in task)
        {
            string [] commands = s.Split(" ");
            int r= Convert.ToInt32(commands[1]);
            int from = Convert.ToInt32(commands[3]);
            int dest = Convert.ToInt32(commands[5]);


            while (r>0)
            {
                List<string> templist = new List<string>();
                templist = stacks[from-1].ToList();

                string temp = templist[stackcount[from-1]-r];
                templist.RemoveAt(stackcount[from-1]-r);

                stacks[from-1]=templist.ToArray();
                stackcount[from-1]--;

                stacks[dest-1]=stacks[dest-1].Append(temp).ToArray();
                stackcount[dest-1]++;
                

                r--;
            }

        }
        string res2="  + Result for Part 2 is :";
        int c=0;
        while (c<9)
        {
            res2=res2+stacks[c][stackcount[c]-1];   
            c++;
        }
        Console.WriteLine(res2);
        

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