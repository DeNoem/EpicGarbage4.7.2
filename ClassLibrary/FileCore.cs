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
        public static void Add(string contents)    
        {

            File.WriteAllText(@"MyGarbage.json", contents);
        }

        public static List<Garbage> Read()        
        {
            string jsonString = File.ReadAllText(@"MyGarbage.json");
            return JsonSerializer.Deserialize<List<Garbage>>(jsonString);
        }

        public static string Serializer<T>(List<T> list)        
        {
            return JsonSerializer.Serialize(list);
        }

        public static Garbage Search(string type, int month)
        {
            List<Garbage> temp = Read().Where(Garbage => Garbage.Month == month && Garbage.DistrictType == type).ToList();
            return temp[0];
        }

        public static List<Garbage> Search(int month)
        {
            List<Garbage> temp = Read().Where(Garbage => Garbage.Month == month).ToList();
            return temp;
        }

        public static List<Garbage> Search(int monthS, int monthF)
        {
            List<Garbage> temp = Read().Where(Garbage => Garbage.Month >= monthS && Garbage.Month <= monthF).ToList();
            return temp;
        }

        public static void DeleteFile()
        {
            File.Delete(@"C:\temp\MyTest.txt");
        }

        public static List<Garbage> RandomList()
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


        public static List<int> Addition(Func<Garbage, int> garbageType, List<Garbage> glist)
        {
            var result = glist.GroupBy(g=> g.Month)
                .OrderBy(g=> g.Key)
                .Select(g=> g.Sum(garbageType)) //(garbage => garbage.AmountIndustrial)
                .ToList();
            
            return result;
        }

        public static List<int> TypeSelect(int garbageType, List<Garbage> glist)
        {
            List<int> result = null;
            switch (garbageType)
            {
                case 0:
                    result = Addition((garbage => garbage.AmountIndustrial), glist);
                    break;

                case 1:
                    result = Addition((garbage => garbage.AmountConstruction), glist);
                    break;

                case 2:
                    result = Addition((garbage => garbage.AmountMunicipal), glist);
                    break;
            }

            return result;
        }


        public static List<Garbage> MonthAddition(List<Garbage> mainList)
        {
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
