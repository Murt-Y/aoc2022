using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;  

namespace aoc2022
{
    class D7
    {

        public class directory
        {
            public string? name { get; set; }
            public int size { get; set; }
            public string[]? sub { get; set; }
            public int parent { get; set; }
            public List<int> subdir { get; set; }
            public List<file> files { get; set; }
        }
        public class file
        {
            public string? name { get; set; }
            public int size { get; set; }
        }
        string[] ReadMyInput()
        {
        string text = File.ReadAllText(@"/users/muratyilmaz/Documents/aoc2022/7.txt");
        string[] move = text.Split("\n");
        return move;

        }





       int Part1()
        {
        string[] code =ReadMyInput();
        string currentdir = "/";
        int currentdirindex = 0;
        List<directory> dirs = new List<directory>();

        int CheckSize(int x)
        {
            if (dirs[x].size!=0)
            {
                return dirs[x].size;
            }
            
            int tsize=0;
            int k=0;
            int fcount=dirs[x].files.Count();
            while(k<fcount)
            {
                tsize=tsize+dirs[x].files[k].size;
                k++;
            }
            k=0;
            int dcount=dirs[x].subdir.Count();
            
            while(k<dcount)
            {
                tsize=tsize+CheckSize(dirs[x].subdir[k]);
                k++;
            }
            dirs[x].size=tsize;
            return tsize;
        }
        int line =0;
        while(line<code.Count())
        {
            string[] command=code[line].Split(" ");
            if (command[0]=="$")
            {
                if (command[1]=="cd")
                {
                    if (command[2]=="..")
                    {
                        currentdir=dirs[dirs[currentdirindex].parent].name;
                        currentdirindex=dirs[currentdirindex].parent;
                    }
                    else{
                    currentdir=command[2];
                    int k=0;
                    int dcount=0;
                    if(dirs.Count!=0)
                    {
                    dcount=dirs[currentdirindex].subdir.Count();
                    }
                    bool sube=false;
                    
                    while(k<dcount)            
                    {
                string temp=dirs[(dirs[currentdirindex].subdir[k])].name;
                if(temp==currentdir){

                currentdirindex=dirs[currentdirindex].subdir[k];
                sube=true;
                break;
                }
                k++;
            }
                    if(sube==false)
                    {
                        dirs.Add(new directory(){name=currentdir, subdir=new List<int>(), files=new List<file>()});
                        currentdirindex=dirs.Count()-1;
                    }
                    }
                }
                else if (command[1]=="ls")
                {
                    bool run =true;
                    while (run==true && line<code.Count()-1)
                    {
                        line++;
                        command=code[line].Split(" ");
                        if (command[0]=="$")
                        {
                            line--;
                            run=false;
                        }
                        else if (command[0]=="dir")
                        {

                        dirs.Add(new directory(){name=command[1],subdir=new List<int>(), files=new List<file>(), parent=currentdirindex});
                        int z =dirs.Count()-1;
                        dirs[currentdirindex].subdir.Add(z);                        
                        }
                        else
                        {
                        dirs[currentdirindex].files.Add(new file(){size=Convert.ToInt32(command[0]), name=command[1]});
                        }
                    }


                }                
            }

        line++;
        }
        int totalsize= CheckSize(0);
        int smallsize=0;
        foreach(directory dc in dirs)
        {
            if(dc.size<100000)
            {
                smallsize=smallsize+dc.size;
            }
        }

  
        return  smallsize;
        }
        int Part2()
        {
        string[] code =ReadMyInput();
        string currentdir = "/";
        int currentdirindex = 0;
        List<directory> dirs = new List<directory>();

        int CheckSize(int x)
        {
            if (dirs[x].size!=0)
            {
                return dirs[x].size;
            }
            
            int tsize=0;
            int k=0;
            int fcount=dirs[x].files.Count();
            while(k<fcount)
            {
                tsize=tsize+dirs[x].files[k].size;
                k++;
            }
            k=0;
            int dcount=dirs[x].subdir.Count();
            
            while(k<dcount)
            {
                tsize=tsize+CheckSize(dirs[x].subdir[k]);
                k++;
            }
            dirs[x].size=tsize;
            return tsize;
        }
        int line =0;
        while(line<code.Count())
        {
            string[] command=code[line].Split(" ");
            if (command[0]=="$")
            {
                if (command[1]=="cd")
                {
                    if (command[2]=="..")
                    {
                        currentdir=dirs[dirs[currentdirindex].parent].name;
                        currentdirindex=dirs[currentdirindex].parent;
                    }
                    else{
                    currentdir=command[2];
                    int k=0;
                    int dcount=0;
                    if(dirs.Count!=0)
                    {
                    dcount=dirs[currentdirindex].subdir.Count();
                    }
                    bool sube=false;
                    
                    while(k<dcount)            
                    {
                string temp=dirs[(dirs[currentdirindex].subdir[k])].name;
                if(temp==currentdir){

                currentdirindex=dirs[currentdirindex].subdir[k];
                sube=true;
                break;
                }
                k++;
            }
                    if(sube==false)
                    {
                        dirs.Add(new directory(){name=currentdir, subdir=new List<int>(), files=new List<file>()});
                        currentdirindex=dirs.Count()-1;
                    }
                    }
                }
                else if (command[1]=="ls")
                {
                    bool run =true;
                    while (run==true && line<code.Count()-1)
                    {
                        line++;
                        command=code[line].Split(" ");
                        if (command[0]=="$")
                        {
                            line--;
                            run=false;
                        }
                        else if (command[0]=="dir")
                        {

                        dirs.Add(new directory(){name=command[1],subdir=new List<int>(), files=new List<file>(), parent=currentdirindex});
                        int z =dirs.Count()-1;
                        dirs[currentdirindex].subdir.Add(z);                        
                        }
                        else
                        {
                        dirs[currentdirindex].files.Add(new file(){size=Convert.ToInt32(command[0]), name=command[1]});
                        }
                    }


                }                
            }

        line++;
        }
        int delsize=int.MaxValue;
        int totalsize= CheckSize(0);
        int need=30000000-(70000000-totalsize);
        foreach(directory dc in dirs)
        {
            if(dc.size>need && dc.size<delsize)
            {
                delsize=dc.size;
            }
        }

        return  delsize;

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