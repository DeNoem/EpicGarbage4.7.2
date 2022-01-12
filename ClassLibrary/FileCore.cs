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
            List<Garbage> temp = Read().Where(Garbage => Garbage.Month == month).ToList();
            return temp;
        }

        public static List<Garbage> Search(int monthS, int monthF)  //Отбор из коллекции по периоду
        {
            List<Garbage> temp = Read().Where(Garbage => Garbage.Month >= monthS && Garbage.Month <= monthF).ToList();
            return temp;
        }

        public static void DeleteFile() //удаление файла
        {
            File.Delete(@"C:\temp\MyTest.txt");
        }

        public static List<Garbage> RandomList()    //Рандомная коллекция на год
        {
            Random rand = new Random();
            List<Garbage> ranList = new List<Garbage>();

            for (int i = 0; i < 12; i++)
            {
                Garbage First = new Garbage(i, "Industrial", rand.Next(100, 150), rand.Next(10, 50), rand.Next(10, 50));
                Garbage Second = new Garbage(i, "Central", rand.Next(0, 10), rand.Next(50, 100), rand.Next(100, 150));
                Garbage Third = new Garbage(i, "New", rand.Next(50, 100), rand.Next(50, 150), rand.Next(50, 100));

                ranList.Add(First);
                ranList.Add(Second);
                ranList.Add(Third);
            }


            return ranList;
        }

        public static List<int> Addition(int garbageType, List<Garbage> glist)
        {
            List<int> result = new List<int>();
            int temp = 0;
            int i = 0;
            switch (garbageType)
            {
                
                case 0:

                    foreach (var item in glist)
                    {
                        temp += item.AmountIndustrial;
                        i++;
                        if (i % 3 == 0)
                        {
                            result.Add(temp);
                            i = 0;
                            temp = 0;
                        }
                    }
                    return result;

                case 1:
                    foreach (var item in glist)
                    {
                        temp += item.AmountConstruction;
                        i++;
                        if (i % 3 == 0)
                        {
                            result.Add(temp);
                            i = 0;
                            temp = 0;
                        }
                    }
                    return result;

                case 2:
                    foreach (var item in glist)
                    {
                        temp += item.AmountMunicipal;
                        i++;
                        if (i % 3 == 0)
                        {
                            result.Add(temp);
                            i = 0;
                            temp = 0;
                        }
                    }
                    return result;
            }
            return null;

        }

        public static List<int> Addition(Func<Garbage, int> garbageType, List<Garbage> glist)
        {
            var result = glist.GroupBy(g=> g.Month)
                .OrderBy(g=> g.Key)
                .Select(g=> g.Sum(garbageType))
                .ToList();
            
            return result;
        }


        public static List<Garbage> MonthAddition(List<Garbage> mainList)
        {
            //List<Garbage> result = new List<Garbage>();

            //for (int i = 0; i < 12; i++)
            //{
            //    Garbage temp = new Garbage();
            //    var tempList = mainList.Where(Garbage => Garbage.Month == i);

            //    foreach (var item in tempList)
            //    {
            //        temp.AmountIndustrial += item.AmountIndustrial;
            //        temp.AmountConstruction += item.AmountConstruction;
            //        temp.AmountMunicipal += item.AmountMunicipal;
            //    }
            //    result.Add(temp);
            //}

            var result = mainList.GroupBy(g => g.Month)
                .Select(g => new Garbage
                {
                    Month = g.Key,
                    AmountIndustrial = g.Sum(garbage => garbage.AmountIndustrial),
                    AmountConstruction = g.Sum(garbage => garbage.AmountConstruction),
                    AmountMunicipal = g.Sum(garbage => garbage.AmountMunicipal)
                }).ToList();

            return result;
        }



    }
}
