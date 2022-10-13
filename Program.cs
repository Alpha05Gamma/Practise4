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

            note.Name = "Прийти на пары";
            note.Description = "Опять куча пар...";
            note.Time = DateTime.Today;

            Note note2 = new Note();
            note2.Name = "Опять идти на пары...";
            note2.Time = dateTime.AddDays(+1);
            note2.Description = "Еще один день с кучей пар... ...";

            list.Add(note);
            list.Add(note2);

            int[] index = new int[2];
            do
            {

                

                uI.Menu = DrawMenu(list,uI.SetData) ;

                index = uI.MenuDisplay01();

                int noteNum = index[0]-4;


                switch (index)
                {
                    case [0, 0]:
                        break;
                    case [1, 0]:
                        break;
                    case [2, 0]:
                        list.InsertRange(0, NewNotes(uI.SetData));
                        break;
                    case [3, 0]:
                        break;
                    default:
                        List<Note> list2 = new List<Note>();
                        for (int j = 0; j < list.Count; j++)
                        {
                            if (list[j].Time == dateTime.AddDays(uI.SetData))
                            {
                                list2.Add(list[j]);
                            }
                        }
                        do
                        {
                            uI.Menu = DrawNote(list2, noteNum);
                            index = uI.MenuDisplay01();
                        } while (index[0] !=3);
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

        static string[,] DrawNote(List<Note> notes, int noteNum)
        {
            string[,] note = new string[20, 20];

            note[0, 0] = notes[noteNum].Name;
            note[1, 0] = notes[noteNum].Time.ToString("dd'.'MM'.'yyyy");
            note[2, 0] = notes[noteNum].Description;
            note[3, 0] = "Выход";

            return note;
        }

        static List<Note>  NewNotes(int SetData)
        {
            DateTime dateTime = DateTime.Today;
            List<Note> notes = new List<Note>();
            Note note = new Note();

            Console.WriteLine("Введите название заметки");
            note.Name = Console.ReadLine();
            note.Time = dateTime.AddDays(SetData);
            Console.WriteLine("Введите описание заметки");
            note.Description = Console.ReadLine();

            notes.Add(note);
            Console.Clear();
            return notes;
        } 
    }
}