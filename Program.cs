using System;
using System.Collections.Generic;
using System.Globalization;

namespace ConsoleApp4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UI uI = new UI();
            uI.Label = "Notepad";

            List<Note> list = new List<Note>();

            DateTime dateTime = DateTime.Today;
            Note note = new Note();

            note.Name = "12";
            note.Description = "12";
            note.Time = DateTime.Today;

            Note note2 = new Note();
            note2.Name = "1";
            note2.Time = dateTime.AddDays(+1);
            note.Description = "15";

            list.Add(note);
            list.Add(note2);

            int[] index = new int[2];
            do
            {

                

                uI.Menu = DrawMenu(list,uI.SetData) ;

                index = uI.MenuDisplay01();


                switch (index)
                {
                    case [2, 0]:
                        break;
                    case [0, 0]:
                        break;
                    case [3, 0]:
                        break;
                    case [1, 0]:
                        break;
                    default:
                        break;
                }

            } while (true);
        }

        static string[,] DrawMenu(List<Note> notes, int SetData)
        {
            string[,] menuMatrix = new string[20, 20];

            int i = 3;

            DateTime dateTime = DateTime.Today;

            string setedData = dateTime.AddDays(SetData).ToString("dd'.'MM'.'yyyy");

            menuMatrix[0, 0] = "Сегодня: " + dateTime.ToString("dd'.'MM'.'yyyy");
            menuMatrix[1, 0] = "Выбрана дата: " + setedData;
            menuMatrix[2, 0] = "Создать заметку";
            menuMatrix[3, 0] = "Заметки:";
            for (int j = 0; j < notes.Count; j++)
            {
                if (notes[j].Time == dateTime.AddDays(SetData))
                {
                    i++;
                    menuMatrix[i, 0] = notes[j].Name;
                }
            }
            return menuMatrix;
        }
    }
}