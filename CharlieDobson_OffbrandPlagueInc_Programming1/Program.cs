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
            viruses.Add((0, 3));
            viruses.Add((1, 5));
            viruses.Add((2, 10));
            VirusSpawn();

            while(true)
            {
                VirusMove();
                Thread.Sleep(1000);
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
                Console.SetCursorPosition(y, x);
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
                    Console.SetCursorPosition(viruses[i].Item2, viruses[i].Item1);
                    Console.Write("X");
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

                if (axisX > 0 && axisX < 7 && axisY > 0 && axisY < 12)
                {
                    if()
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

                Console.SetCursorPosition(viruses[i].Item2, viruses[i].Item1);
                Console.Write("X");


            }
        }


        
    }
}
