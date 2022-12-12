using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;  

namespace aoc2022
{
    class D9
    {


                    public class rope
        {
            public int x { get; set; }
            public int y { get; set; }
        }
            public class coordinate
        {
            public int x { get; set; }
            public int y { get; set; }
            public bool visit { get; set; }
        }

        string[] ReadMyInput()
        {
        string text = File.ReadAllText(@"/users/muratyilmaz/Documents/aoc2022/9.txt");
        string[] move = text.Split("\n");
        return move;
        }





       int Part1()
        {
        string[] code =ReadMyInput();
        List<coordinate> coord = new List<coordinate>();
        int currentx=0;
        int currenty=0;
        int tx=0;
        int ty=0;
        coord.Add(new coordinate (){x=currentx, y=currenty, visit=true});

        void MoveD(int y)
        {
            int tempy=y-1;
            currenty=tempy;
            if(!coord.Any(item => item.x==currentx && item.y==tempy))
            {
                coord.Add(new coordinate (){x=currentx, y=currenty});
            }
            int distx =Math.Abs(currentx-tx);
            int disty =Math.Abs(currenty-ty);
            bool far = (distx >1 || disty>1);
            if (far)
            {
                if(tx==currentx)
                {
                    ty=ty-1;
                    int m=coord.FindIndex(item => item.x==tx && item.y==ty);
                    coord[m].visit=true;

                }
                else if(tx>currentx)
                {
                    ty=ty-1;
                    tx=tx-1;
                    int m=coord.FindIndex(item => item.x==tx && item.y==ty);
                    coord[m].visit=true;

                }
                else if(tx<currentx)
                {
                    ty=ty-1;
                    tx=tx+1;
                    int m=coord.FindIndex(item => item.x==tx && item.y==ty);
                    coord[m].visit=true;

                }
            }
        }
                void MoveU(int y)
        {
            int tempy=y+1;
            currenty=tempy;
            if(!coord.Any(item => item.x==currentx && item.y==tempy))
            {
                coord.Add(new coordinate (){x=currentx, y=currenty});
            }

            int dist =Math.Abs((currentx-tx)*(currenty-ty));            int distx =Math.Abs(currentx-tx);
            int disty =Math.Abs(currenty-ty);
            bool far = (distx >1 || disty>1);            
            if (far)
            {
                if(tx==currentx)
                {
                    ty=ty+1;
                    int m=coord.FindIndex(item => item.x==tx && item.y==ty);
                    coord[m].visit=true;

                }
                else if(tx>currentx)
                {
                    ty=ty+1;
                    tx=tx-1;
                    int m=coord.FindIndex(item => item.x==tx && item.y==ty);
                    coord[m].visit=true;

                }
                else if(tx<currentx)
                {
                    ty=ty+1;
                    tx=tx+1;
                    int m=coord.FindIndex(item => item.x==tx && item.y==ty);
                    coord[m].visit=true;

                }
            }
        }
                void MoveL(int x)
        {
            int tempx=x-1;
            currentx=tempx;
            if(!coord.Any(item => item.x==tempx && item.y==currenty))
            {
                coord.Add(new coordinate (){x=currentx, y=currenty});
            }

            int distx =Math.Abs(currentx-tx);
            int disty =Math.Abs(currenty-ty);
            bool far = (distx >1 || disty>1);
            if (far)
            {
                if(ty==currenty)
                {
                    tx=tx-1;
                    int m=coord.FindIndex(item => item.x==tx && item.y==ty);
                    coord[m].visit=true;

                }
                else if(ty>currenty)
                {
                    ty=ty-1;
                    tx=tx-1;
                    int m=coord.FindIndex(item => item.x==tx && item.y==ty);
                    coord[m].visit=true;

                }
                else if(ty<currenty)
                {
                    ty=ty+1;
                    tx=tx-1;
                    int m=coord.FindIndex(item => item.x==tx && item.y==ty);
                    coord[m].visit=true;

                }
            }
        }
                       void MoveR(int x)
        {
            int tempx=x+1;
            currentx=tempx;
            if(!coord.Any(item => item.x==tempx && item.y==currenty))
            {
                coord.Add(new coordinate (){x=currentx, y=currenty});
            }

            int distx =Math.Abs(currentx-tx);
            int disty =Math.Abs(currenty-ty);
            bool far = (distx >1 || disty>1);
            if (far)
            {
                if(ty==currenty)
                {
                    tx=tx+1;
                    int m=coord.FindIndex(item => item.x==tx && item.y==ty);
                    coord[m].visit=true;

                }
                else if(ty>currenty)
                {
                    ty=ty-1;
                    tx=tx+1;
                    int m=coord.FindIndex(item => item.x==tx && item.y==ty);
                    coord[m].visit=true;

                }
                else if(ty<currenty)
                {
                    ty=ty+1;
                    tx=tx+1;
                    int m=coord.FindIndex(item => item.x==tx && item.y==ty);
                    coord[m].visit=true;

                }
            }
        }
        int i = 0;
        int k=0;

        while (i<code.Count())
        {
               string[]command=code[i].Split(" ");
               k=Convert.ToInt32(command[1]);
                if(command[0]=="D")
                {
                    while(k>0)
                    {
                        MoveD(currenty);
                        k--;
                    }
                }
                else if(command[0]=="U")
                {
                    while(k>0)
                    {
                        MoveU(currenty);
                        k--;
                    }
                }
                else if(command[0]=="R")
                {
                    while(k>0)
                    {
                        MoveR(currentx);
                        k--;
                    }
                }
                else if(command[0]=="L")
                {
                    while(k>0)
                    {
                        MoveL(currentx);
                        k--;
                    }
                }

        i++;

        }
        int tcount=0;
        foreach(coordinate c in coord)
        {
            if(c.visit==true)
            {
                tcount++;
            }
        }
        
        return  tcount;
        }
        int Part2()
        {
       
      string[] code =ReadMyInput();
        List<coordinate> coord = new List<coordinate>();
        List<rope> ropes = new List<rope>();
        int currentx=0;
        int currenty=0;
        coord.Add(new coordinate (){x=currentx, y=currenty, visit=true});

        int z=9;
        while(z>0)
        {
            ropes.Add(new rope(){x=0, y=0});
            z--;
        }

        int[] newc (int x1, int x2, int y1, int y2)
        {
            int xr=x2;
            int yr=y2;
            if (x1>x2)
            {
                xr++;
            }
            else if(x1<x2)
            {
                xr--;
            }
            if (y1>y2)
            {
                yr++;
            }
            else if(y1<y2)
            {
                yr--;
            }
            int [] ret = new int[] {xr,yr};
            return ret;
        }

        void MoveD(int y)
        {
            int tempy=y-1;
            currenty=tempy;
            if(!coord.Any(item => item.x==currentx && item.y==tempy))
            {
                coord.Add(new coordinate (){x=currentx, y=currenty});
            }
            int z =0;
            while(z<9)
            {

            int tx=ropes[z].x;
            int ty=ropes[z].y;

            int hx=0;
            int hy=0;
            if(z==0)
            {
                hx=currentx;
                hy=currenty;
            }

            else
            {
                hx=ropes[z-1].x;
                hy=ropes[z-1].y;
            }

            int distx =Math.Abs(hx-tx);
            int disty =Math.Abs(hy-ty);
            bool far = (distx >1 || disty>1);
            if (far)
            {
              
                int[] newcr= newc(hx, tx, hy, ty);
                tx=newcr[0];
                ty=newcr[1];
                ropes[z].x=tx;
                ropes[z].y=ty;
                
                if(z==8)
                {
                    int m=coord.FindIndex(item => item.x==tx && item.y==ty);
                    if(m==-1)
                    {
                    coord.Add(new coordinate (){x=tx, y=ty,visit=true});
                    }
                    else{
                    coord[m].visit=true;
                    }
                }
            }
                        else
            {
                break;
            }
            z++;
            }

        }
                void MoveU(int y)
        {
            int tempy=y+1;
            currenty=tempy;
            if(!coord.Any(item => item.x==currentx && item.y==tempy))
            {
                coord.Add(new coordinate (){x=currentx, y=currenty});
            }
            int z =0;
            while(z<9)
            {

            int tx=ropes[z].x;
            int ty=ropes[z].y;

            int hx=0;
            int hy=0;
            if(z==0)
            {
                hx=currentx;
                hy=currenty;
            }
            else
            {
                hx=ropes[z-1].x;
                hy=ropes[z-1].y;
            }

            int distx =Math.Abs(hx-tx);
            int disty =Math.Abs(hy-ty);
            bool far = (distx >1 || disty>1);            
            if (far)
            {
                int[] newcr= newc(hx, tx, hy, ty);
                tx=newcr[0];
                ty=newcr[1];
                ropes[z].x=tx;
                ropes[z].y=ty;

                if(z==8)
                {
                    int m=coord.FindIndex(item => item.x==tx && item.y==ty);
                    if(m==-1)
                    {
                    coord.Add(new coordinate (){x=tx, y=ty,visit=true});
                    }
                    else{
                    coord[m].visit=true;
                    }
                }
            }
                        else
            {
                break;
            }
            z++;
            }
        }
                void MoveL(int x)
        {
            int tempx=x-1;
            currentx=tempx;
            if(!coord.Any(item => item.x==tempx && item.y==currenty))
            {
                coord.Add(new coordinate (){x=currentx, y=currenty});
            }
            int z =0;
            while(z<9)
            {

            int tx=ropes[z].x;
            int ty=ropes[z].y;

            int hx=0;
            int hy=0;
            if(z==0)
            {
                hx=currentx;
                hy=currenty;
            }

            else
            {
                hx=ropes[z-1].x;
                hy=ropes[z-1].y;
            }

            int distx =Math.Abs(hx-tx);
            int disty =Math.Abs(hy-ty);

            bool far = (distx >1 || disty>1);
            if (far)
            {
                  int[] newcr= newc(hx, tx, hy, ty);
                tx=newcr[0];
                ty=newcr[1];
                ropes[z].x=tx;
                ropes[z].y=ty;
                if(z==8)
                {
                    int m=coord.FindIndex(item => item.x==tx && item.y==ty);
                    if(m==-1)
                    {
                    coord.Add(new coordinate (){x=tx, y=ty,visit=true});
                    }
                    else{
                    coord[m].visit=true;
                    }
                }
            }
                        else
            {
                break;
            }
            z++;
            }
        }
            void MoveR(int x)
        {
            int tempx=x+1;
            currentx=tempx;
            if(!coord.Any(item => item.x==tempx && item.y==currenty))
            {
                coord.Add(new coordinate (){x=currentx, y=currenty});
            }

            int z =0;
            while(z<9)
            {

            int tx=ropes[z].x;
            int ty=ropes[z].y;

            int hx=0;
            int hy=0;
            if(z==0)
            {
                hx=currentx;
                hy=currenty;
            }

            else
            {
                hx=ropes[z-1].x;
                hy=ropes[z-1].y;
            }

            int distx =Math.Abs(hx-tx);
            int disty =Math.Abs(hy-ty);


            bool far = (distx >1 || disty>1);
            if (far)
            {
                
                int[] newcr= newc(hx, tx, hy, ty);
                tx=newcr[0];
                ty=newcr[1];
                ropes[z].x=tx;
                ropes[z].y=ty;


                if(z==8)
                {
                    int m=coord.FindIndex(item => item.x==tx && item.y==ty);
                    if(m==-1)
                    {
                    coord.Add(new coordinate (){x=tx, y=ty,visit=true});
                    }
                    else{
                    coord[m].visit=true;
                    }
                }
            }
            else
            {
                break;
            }
            z++;
            }
        }
        int i = 0;
        int k=0;

        while (i<code.Count())
        {
               string[]command=code[i].Split(" ");
               k=Convert.ToInt32(command[1]);
                if(command[0]=="D")
                {
                    while(k>0)
                    {
                        MoveD(currenty);
                        k--;
                    }
                }
                else if(command[0]=="U")
                {
                    while(k>0)
                    {
                        MoveU(currenty);
                        k--;
                    }
                }
                else if(command[0]=="R")
                {
                    while(k>0)
                    {
                        MoveR(currentx);
                        k--;
                    }
                }
                else if(command[0]=="L")
                {
                    while(k>0)
                    {
                        MoveL(currentx);
                        k--;
                    }
                }

        i++;

        }
        int tcount=0;
        foreach(coordinate c in coord)
        {
            if(c.visit==true)
            {
                tcount++;
            }
        }
        
        return  tcount;
 
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