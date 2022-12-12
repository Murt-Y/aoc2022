using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;  

namespace aoc2022
{
    class D8
    {

        public class tree
        {
            public int x { get; set; }
            public int y { get; set; }
            public bool visible { get; set; }
            public int height { get; set; }
            public int ls { get; set; }
            public int rs { get; set; }
            public int us { get; set; }
            public int ds { get; set; }

        }

        string[] ReadMyInput()
        {
        string text = File.ReadAllText(@"/users/muratyilmaz/Documents/aoc2022/8.txt");
        string[] move = text.Split("\n");
        return move;
        }





       int Part1()
        {
        string[] code =ReadMyInput();
        int wmax=code[0].Count();
        int hmax=code.Count();
        List<tree> coord = new List<tree>();

        bool CheckR(int t)
        {
            if(coord[t].x==wmax-1)
            {
                return true;
            }
            int r=1;
            while(coord[t].x+r<wmax)
            {
                if(coord[t].height<=coord[t+r].height)
                {
                    return false;
                }
                r++;
            }
            return true;
        }

        bool CheckL(int t)
        {
            if(coord[t].x==0)
            {
                return true;
            }
            int r=1;
            while(coord[t].x-r>=0)
            {
                if(coord[t].height<=coord[t-r].height)
                {
                    return false;
                }
                r++;
            }
            return true;
        }

        bool CheckU(int t)
        {
            if(coord[t].y==0)
            {
                return true;
            }
            int r=1;
            while(coord[t].y-r>=0)
            {
                if(coord[t].height<=coord[t-(r*wmax)].height)
                {
                    return false;
                }
                r++;
            }
            return true;
        }
        bool CheckD(int t)
        {
            if(coord[t].y==hmax-1)
            {
                return true;
            }
            int r=1;
            while(coord[t].y+r<hmax)
            {
                if(coord[t].height<=coord[t+(r*wmax)].height)
                {
                    return false;
                }
                r++;
            }
            return true;
        }
        
        int i = 0;
        int k=0;
        while (i<hmax)
        {
            while(k<wmax)
            {   
                bool v =false;
                

                if(i==0 || k==0 || k==wmax-1 || i==hmax-1)
                {
                    v=true;
                }
                coord.Add(new tree(){x=k%wmax, y=i%hmax, visible=v, height=code[i][k]-48});
                k++;
            }
        i++;
        k=0;
        }

        int vcount=0;

        foreach(tree tr in coord)
        {
            int m = coord.IndexOf(tr);
            
            if(tr.visible==true)
            {
                vcount++;
            }
            else if(CheckD(m))
            {
                vcount++;
            }
                        else if(CheckU(m))
            {
                vcount++;
            }
                        else if(CheckL(m))
            {
                vcount++;
            }
                        else if(CheckR(m))
            {
                vcount++;
            }
            
        }
  
        return  vcount;
        }
        int Part2()
        {
       
        string[] code =ReadMyInput();
        int wmax=code[0].Count();
        int hmax=code.Count();
        List<tree> coord = new List<tree>();

        bool CheckR(int t)
        {
            if(coord[t].x==wmax-1)
            {
                coord[t].rs=0;
                return true;
            }
            int r=1;
            while(coord[t].x+r<wmax)
            {
                if(coord[t].height<=coord[t+r].height)
                {
                    coord[t].rs=r;
                    return false;
                }
                r++;
            }
            coord[t].rs=r-1;
            return true;
        }

        bool CheckL(int t)
        {
            if(coord[t].x==0)
            {
                coord[t].ls=0;
                return true;
            }
            int r=1;
            while(coord[t].x-r>=0)
            {
                if(coord[t].height<=coord[t-r].height)
                {
                    coord[t].ls=r;
                    return false;
                }
                r++;
            }
            coord[t].ls=r-1;
            return true;
        }

        bool CheckU(int t)
        {
            if(coord[t].y==0)
            {
                coord[t].us=0;
                return true;
            }
            int r=1;
            while(coord[t].y-r>=0)
            {
                if(coord[t].height<=coord[t-(r*wmax)].height)
                {
                    coord[t].us=r;
                    return false;
                }
                r++;
            }
            coord[t].us=r-1;
            return true;
        }
        bool CheckD(int t)
        {
            if(coord[t].y==hmax-1)
            {
                coord[t].ds=0;
                return true;
            }
            int r=1;
            while(coord[t].y+r<hmax)
            {
                if(coord[t].height<=coord[t+(r*wmax)].height)
                {
                    coord[t].ds=r;
                    return false;
                }
                r++;
            }
            coord[t].ds=r-1;
            return true;
        }
        
        int i = 0;
        int k=0;
        while (i<hmax)
        {
            while(k<wmax)
            {   
                bool v =false;
                

                if(i==0 || k==0 || k==wmax-1 || i==hmax-1)
                {
                    v=true;
                }
                coord.Add(new tree(){x=k%wmax, y=i%hmax, visible=v, height=code[i][k]-48});
                k++;
            }
        i++;
        k=0;
        }

        int vcount=0;

        foreach(tree tr in coord)
        {
            int m = coord.IndexOf(tr);
            
  
            CheckD(m);
            CheckR(m);
            CheckL(m);
            CheckU(m);
   
   
            
        }
        int score=0;
  
          foreach(tree tr in coord)
        {
            int scenescore=tr.ls*tr.ds*tr.us*tr.rs;
            if(scenescore>score)
            {
                score=scenescore;
            }
            
        }
        return  score;

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