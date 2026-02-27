using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CharlieDobson_OffbrandPlagueInc_Programming1
{
    internal class Program
    {

        static string[,] ground = { 
            {"^", "^", "-", "-", "-", "-", "-", "-", "^", "-", "-", "-"},
            {"-", "^", "-", "-", "-", "-", "~", "-", "-", "-", "-", "-"},
            {"-", "-", "-", "-", "-", "~", "~", "-", "-", "-", "-", "-"},
            {"-", "-", "-", "-", "-", "~", "~", "~", "-", "-", "-", "^"},
            {"^", "^", "-", "-", "-", "-", "~", "~", "~", "-", "-", "-"},
            {"~", "~", "~", "-", "-", "-", "-", "-", "~", "-", "-", "-"},
            {"~", "~", "~", "~", "-", "-", "-", "-", "-", "-", "-", "-"},};

        static List<(int, int)> viruses = new List<(int, int)>();

        static Random chance = new Random();


        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            PaintGround();
            viruses.Add((3, 0));
            viruses.Add((5, 5));
            viruses.Add((10, 2));
            VirusSpawn();

            while(true)
            {
                Thread.Sleep(1000);
                VirusMove();
            }
        }

        static void PaintGround()
        {
            for (int i = 0; i < ground.GetLength(0); i++)
            {
                for (int j = 0; j < ground.GetLength(1); j++)
                {
                    Console.Write(ground[i, j]);
                }
                Console.Write("\n");
            }
        }
        
        static void VirusSpawn()
        {
            foreach((int x, int y)  in viruses)
            {
                Console.SetCursorPosition(x, y);
                Console.Write("X");
            }
        }

        static void VirusMove()
        {
            for(int i = 0; i < viruses.Count(); i++)
            {
                double opp = chance.NextDouble();

                if (opp < 0.1)
                {
                    viruses.Add((viruses[i].Item1, viruses[i].Item2));
                    Console.SetCursorPosition(viruses[i].Item1, viruses[i].Item2);
                    Console.Write("X");
                }
                else
                {
                    Console.SetCursorPosition(viruses[i].Item1, viruses[i].Item2);
                    Console.Write("-");
                }
                        

                int move = chance.Next(1, 5);
                int xAxis = 0;
                int yAxis = 0;

                if(move == 1) // Right
                {
                    xAxis++;
                }
                else if(move == 2) //Down
                {
                    yAxis++;
                }
                else if(move == 3) //Left
                {
                    xAxis--;
                }
                else if(move == 4) //Up
                {
                    yAxis--;
                }

                int axisX = xAxis + viruses[i].Item1;
                int axisY = yAxis + viruses[i].Item2;
                

                if (axisX > 0 && axisX < 12 && axisY > 0 && axisY < 7)
                {
                    
                    if (ground[axisY, axisX] == "^" || ground[axisY, axisX] == "~" || ground[axisY, axisX] == "X")
                    {
                        return;
                    }
                    else
                    {
                        viruses[i] = (axisX, axisY);
                    }
                }
                else
                {
                    return;
                }

                Console.SetCursorPosition(viruses[i].Item1, viruses[i].Item2);
                Console.Write("X");
            }
        }
        
    }
}
