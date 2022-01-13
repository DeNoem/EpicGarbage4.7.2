using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ClassLibrary;
using System.Linq;
using System.IO;
using System.Collections.Generic;
using System.Text.Json;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {

        static Garbage garbage1 = new Garbage(0, "Industrial", 1, 1, 1);
        static Garbage garbage2 = new Garbage(0, "Central", 2, 2, 2);
        static Garbage garbage3 = new Garbage(0, "New", 3, 3, 3);
        static Garbage garbage4 = new Garbage(1, "Industrial", 4, 4, 4);
        static Garbage garbage5 = new Garbage(1, "Central", 5, 5, 5);
        static Garbage garbage6 = new Garbage(1, "New", 6, 6, 6);
        static Garbage garbage7 = new Garbage(2, "Industrial", 7, 7, 7);

        List<Garbage> Garbages = new List<Garbage>() { garbage1, garbage2, garbage3, garbage4, garbage5, garbage6, garbage7 };

        [TestMethod]
        public void TestSearchTypeMonth()
        {
            string type = "Industrial";
            int month = 0;
            File.WriteAllText(@"C:\temp\MyTest.json", JsonSerializer.Serialize(Garbages));
            List<Garbage> temp = JsonSerializer.Deserialize<List<Garbage>>(File.ReadAllText(@"C:\temp\MyTest.json"));
                
            List<Garbage> result = temp.Where(Garbage => Garbage.Month == month && Garbage.DistrictType == type).ToList();

            var actual = temp[0].AmountConstruction;
            var expected = 1;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestSearchMonth()           //Отбор из коллекции по месяцу
        {
            int month = 0;

            List<Garbage> temp = JsonSerializer.Deserialize<List<Garbage>>(File.ReadAllText(@"C:\temp\MyTest.json"));
            var result = temp.Where(Garbage => Garbage.Month == month).ToList();

            var actual = temp[0].AmountIndustrial;
            var expected = 1;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestSearchMonthPeriod()  //Отбор из коллекции по периоду
        {

            int monthS = 0;
            int monthF = 1;
            List<Garbage> temp = JsonSerializer.Deserialize<List<Garbage>>(File.ReadAllText(@"C:\temp\MyTest.json"));
            var result = temp.Where(Garbage => Garbage.Month >= monthS && Garbage.Month <= monthF).ToList();
            
            var actual = result[1].AmountIndustrial;
            var expected = 2;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMonthAddition()
        {
            List<Garbage> mainList = JsonSerializer.Deserialize<List<Garbage>>(File.ReadAllText(@"C:\temp\MyTest.json")); ;
            var result = mainList.GroupBy(g => g.Month)
                .Select(g => new Garbage
                {
                    Month = g.Key,
                    AmountIndustrial = g.Sum(garbage => garbage.AmountIndustrial),
                    AmountConstruction = g.Sum(garbage => garbage.AmountConstruction),
                    AmountMunicipal = g.Sum(garbage => garbage.AmountMunicipal)
                }).ToList();

            //var actual = result.Select(Garbage => Garbage.AmountIndustrial).ToList();


            var actual = result[2].AmountIndustrial;
            var expected = 7;
            Assert.AreEqual(expected, actual);
        }
    }
}
