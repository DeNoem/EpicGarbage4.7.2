using ClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
            File.WriteAllText(@"MyTest.json", JsonSerializer.Serialize(Garbages));
            List<Garbage> temp = JsonSerializer.Deserialize<List<Garbage>>(File.ReadAllText(@"MyTest.json"));

            var actual = temp.Where(Garbage => Garbage.Month == month && Garbage.DistrictType == type).ToList()[0].AmountConstruction;
            var expected = 1;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestSearchMonth()           //Отбор из коллекции по месяцу
        {
            int month = 0;
            File.WriteAllText(@"MyTest.json", JsonSerializer.Serialize(Garbages));
            List<Garbage> temp = JsonSerializer.Deserialize<List<Garbage>>(File.ReadAllText(@"MyTest.json"));

            var actual = temp.Where(Garbage => Garbage.Month == month)
                .Select(Garbage => Garbage.AmountIndustrial)
                .ToList();
            List<int> expected = new List<int> { 1, 2, 3 };

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestSearchMonthPeriod()  //Отбор из коллекции по периоду
        {

            int monthS = 0;
            int monthF = 1;
            File.WriteAllText(@"MyTest.json", JsonSerializer.Serialize(Garbages));
            List<Garbage> temp = JsonSerializer.Deserialize<List<Garbage>>(File.ReadAllText(@"MyTest.json"));

            var actual = temp.Where(Garbage => Garbage.Month >= monthS && Garbage.Month <= monthF)
                .Select(Garbage => Garbage.AmountIndustrial)
                .ToList();
            var expected = new List<int> { 1, 2, 3, 4, 5, 6 }; 

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMonthAddition()
        {
            File.WriteAllText(@"MyTest.json", JsonSerializer.Serialize(Garbages));
            List<Garbage> mainList = JsonSerializer.Deserialize<List<Garbage>>(File.ReadAllText(@"MyTest.json"));

            var actual = mainList.GroupBy(g => g.Month)
                .Select(g => new Garbage
                {
                    Month = g.Key,
                    AmountIndustrial = g.Sum(garbage => garbage.AmountIndustrial),
                    AmountConstruction = g.Sum(garbage => garbage.AmountConstruction),
                    AmountMunicipal = g.Sum(garbage => garbage.AmountMunicipal)
                })
                .Select(Garbage => Garbage.AmountIndustrial)
                .ToList();
            var expected = new List<int> { 6, 15, 7 };

            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
