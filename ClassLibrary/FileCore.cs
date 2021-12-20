using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ClassLibrary
{
    public static class FileCore
    {
        public static void Add(string contents)     //добавление единичной строки.
        {

            File.WriteAllText(@"C:\temp\MyTest.json", contents);
        }

        public static List<Garbage> Read()          //Чтение файла в коллекцию
        {
            string jsonString = File.ReadAllText(@"C:\temp\MyTest.json");
            return JsonSerializer.Deserialize<List<Garbage>>(jsonString);
        }       

        public static string Serializer<T>(List<T> list)        //Сериализация
        {
            return JsonSerializer.Serialize(list);
        }       

        public static Garbage Search(string type, int month)    //Отбор из коллекции по типу и месяцу
        {
            foreach (var item in Read())                
            {
                if (item.Month == month && item.DistrictType == type)
                    return item;
            }
            return null;
        }

        public static List<Garbage> Search(int month)           //Отбор из коллекции по месяцу
        {
            List < Garbage > temp = Read().Where(Garbage => Garbage.Month == month).ToList();
            return temp;
        }

        public static List<Garbage> Search(int monthS, int monthF)  //Отбор из коллекции по периоду
        {
            List<Garbage> temp = Read().Where(Garbage => Garbage.Month >= monthS && Garbage.Month
                    <= monthF).ToList();
            return temp;
        }

        public static void DeleteFile() //удаление файла
        {
            File.Delete(@"C:\temp\MyTest.txt");
        }

        /*СДЕЛАТЬ*/
        public static void EditFile()   //Редактирование файла
        {
            
        }   

        public static List<Garbage> RandomList()    //попытка в рандомизированную коллекцию
        {
            Random rand = new Random();
            List<Garbage> ranList = new List<Garbage>();

            for (int i = 0; i < 12; i++)
            {
                /* Раскоментить блок ниже и блок контрутора в Garbage*/

                //Garbage First = new Garbage(i, "Industrial", rand.Next(100, 150), rand.Next(10, 50), rand.Next(10, 50));
                //Garbage Second = new Garbage(i, "Central", rand.Next(10, 50), rand.Next(50, 100), rand.Next(100, 150));
                //Garbage Third = new Garbage(i, "New", rand.Next(50, 100), rand.Next(50, 150), rand.Next(50, 100));

                //ranList.Add(First);
                //ranList.Add(Second);
                //ranList.Add(Third);
            }


            return ranList;
        }   

        
    }
}
