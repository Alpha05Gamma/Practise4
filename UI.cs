using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    internal class UI
    {
        private int indexX=0;
        private int indexY=0;
        private int[] indexRet = new int[2];
        private string[,] menu;
        private int top;
        private string label = "Menu";
        private int vGap=2;
        private int gap=0;
        public int SetData=0;

        public int Gap
        {
            get { return gap; }
            set { gap = value; }
        }

        public int VGap
        {
            get { return vGap; }
            set { vGap = value; }
        }

        public int Top
        {
            get { return top; }
            set { top = value; }
        }

        public string Label
        {
            get { return label; }
            set { label = value; }
        }

        public string[,] Menu
        {
            get { return menu; }
            set { menu = value; }
        }

         

        public void DrawMenyY()
        {
            Console.CursorVisible = false;
            int prevString=0;

            for (int i = 0; i < menu.GetLength(0); i++)
            {
                for (int j = 0; j < menu.GetLength(1); j++)
                {
                    string curientString = menu[i, j];
                    if (string.IsNullOrEmpty(curientString))
                    {
                        continue;
                    }
                    if (indexX == j&indexY == i&curientString!="*"& curientString != "!"& curientString != "?")
                    {
                        curientString = $" <{curientString}> ";
                    }
                    else
                    {
                        
                    }
                    switch (curientString)
                    {
                        case "*":
                            prevString = prevString+3;
                            break;
                        case "!":
                            prevString = prevString + 5;
                            break;
                        case "?":
                            prevString = prevString + 10;
                            break;
                        default:
                            Console.SetCursorPosition(j + 5 + Gap + prevString, i + vGap);
                            Console.Write(curientString);
                            prevString = prevString + curientString.Length;
                            break;
                    }
                    prevString = 0;
                }
            }
            Console.ResetColor();

        }

        public int[] MenuDisplay01()
        {
            
            ConsoleKey consoleKey;
            do
            {
                Console.SetCursorPosition(Console.BufferWidth / 2 - label.Length / 2, top);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(label);

                new Thread(DrawMenyY).Start();

                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                consoleKey = keyInfo.Key;
                if (indexY == 1 & indexX == 0)
                {
                    if (consoleKey == ConsoleKey.RightArrow)
                    {
                        SetData = SetData + 1;
                        indexRet[0] = indexY;
                        indexRet[1] = indexX;
                        Console.Clear();
                        return indexRet;
                    }
                    else if (consoleKey == ConsoleKey.LeftArrow)
                    {
                        SetData = SetData - 1;
                        indexRet[0] = indexY;
                        indexRet[1] = indexX;
                        Console.Clear();
                        return indexRet;
                    }
                }
                if (consoleKey == ConsoleKey.DownArrow)
                {
                    indexY++;
                    if (menu[indexY, indexX] is null)
                    {
                        indexY--;
                    }
                }
                else if (consoleKey == ConsoleKey.UpArrow)
                {
                    indexY--;
                    if(indexY<0)
                    {
                        indexY++;
                    }
                    else if (menu[indexY, indexX] is null)
                    {
                        indexY++;
                    }
                }

                if(consoleKey == ConsoleKey.RightArrow)
                {
                    indexX++;
                    if (menu[indexY, indexX] is null)
                    {
                        indexX--;
                    }
                }
                else if(consoleKey == ConsoleKey.LeftArrow)
                {
                    indexX--;
                    if (indexX < 0)
                    {
                        indexX++;
                    }
                    else if (menu[indexY, indexX] is null)
                    {
                        indexX++;
                    }
                }
                Console.Clear();

            } while (consoleKey != ConsoleKey.Enter);

            indexRet[0] = indexY;
            indexRet[1] = indexX;
            return indexRet;
        }
    }
}
