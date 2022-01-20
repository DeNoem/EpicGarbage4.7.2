using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using ClassLibrary;

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
        static Garbage garbage8 = new Garbage(2, "Central", 8, 8, 8);
        static Garbage garbage9 = new Garbage(2, "New", 9, 9, 9);
        static Garbage garbage10 = new Garbage(3, "Industrial", 10, 10, 10);
        static Garbage garbage11 = new Garbage(3, "Central", 11, 11, 11);
        static Garbage garbage12 = new Garbage(3, "New", 12, 12, 12);
        static Garbage garbage13 = new Garbage(4, "Industrial", 13, 13, 13);
        static Garbage garbage14 = new Garbage(4, "Central", 14, 14, 14);
        static Garbage garbage15 = new Garbage(4, "New", 15, 15, 15);
        static Garbage garbage16 = new Garbage(5, "Industrial", 16, 16, 16);
        static Garbage garbage17 = new Garbage(5, "Central", 17, 17, 17);
        static Garbage garbage18 = new Garbage(5, "New", 18, 18, 18);
        static Garbage garbage19 = new Garbage(6, "Industrial", 19, 19, 19);
        static Garbage garbage20 = new Garbage(6, "Central", 20, 20, 20);
        static Garbage garbage21 = new Garbage(6, "New", 21, 21, 21);
        static Garbage garbage22 = new Garbage(7, "Industrial", 22, 22, 22);
        static Garbage garbage23 = new Garbage(7, "Central", 23, 23, 23);
        static Garbage garbage24 = new Garbage(7, "New", 24, 24, 24);
        static Garbage garbage25 = new Garbage(8, "Industrial", 25, 25, 25);



        List<Garbage> Garbages = new List<Garbage>() { garbage1, garbage2, garbage3, garbage4, garbage5,
                                                        garbage6, garbage7, garbage8, garbage9, garbage10,
                                                        garbage11, garbage12, garbage13, garbage14, garbage15,
                                                        garbage16, garbage17, garbage18, garbage19, garbage20,
                                                        garbage21, garbage22, garbage23, garbage24, garbage25};

        [TestMethod]
        public void TestSearchTypeMonth()
        {
            string type = "Industrial";
            int month = 3;
            FileCore.Add(FileCore.Serializer<Garbage>(Garbages));

            var actual = FileCore.Search(type, month);
            var expected = garbage10;

            Assert.AreEqual(expected.Month, actual.Month);
            Assert.AreEqual(expected.DistrictType, actual.DistrictType);
            Assert.AreEqual(expected.AmountConstruction, actual.AmountConstruction);
            Assert.AreEqual(expected.AmountIndustrial, actual.AmountIndustrial);
            Assert.AreEqual(expected.AmountMunicipal, actual.AmountMunicipal);

        }

        [TestMethod]
        public void TestSearchMonth()           
        {
            int month = 6;
            FileCore.Add(FileCore.Serializer<Garbage>(Garbages));

            var actual = FileCore.Search(month);
            var expected = new List<Garbage> { garbage19,garbage20,garbage21 };

            Assert.AreEqual(expected.Count, actual.Count);
            for (int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i].Month, actual[i].Month);
                Assert.AreEqual(expected[i].DistrictType, actual[i].DistrictType);
                Assert.AreEqual(expected[i].AmountConstruction, actual[i].AmountConstruction);
                Assert.AreEqual(expected[i].AmountIndustrial, actual[i].AmountIndustrial);
                Assert.AreEqual(expected[i].AmountMunicipal, actual[i].AmountMunicipal);
            }
        }

        [TestMethod]
        public void TestSearchMonthPeriod()  
        {

            int monthS = 2;
            int monthF = 4;

            FileCore.Add(FileCore.Serializer<Garbage>(Garbages));

            var actual = FileCore.Search(monthS, monthF);
            var expected = new List<Garbage> { garbage7, garbage8, garbage9, garbage10, garbage11, garbage12, garbage13, garbage14, garbage15 };
            
            Assert.AreEqual(expected.Count, actual.Count);
            for (int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i].Month, actual[i].Month);
                Assert.AreEqual(expected[i].DistrictType, actual[i].DistrictType);
                Assert.AreEqual(expected[i].AmountConstruction, actual[i].AmountConstruction);
                Assert.AreEqual(expected[i].AmountIndustrial, actual[i].AmountIndustrial);
                Assert.AreEqual(expected[i].AmountMunicipal, actual[i].AmountMunicipal);
            }
        }
        [TestMethod]
        public void TestTypeSelect()
        {
            var garbageType = "индустриальный";
            FileCore.Add(FileCore.Serializer<Garbage>(Garbages));
            List<Garbage> mainList = JsonSerializer.Deserialize<List<Garbage>>(File.ReadAllText(@"MyTest.json"));

            var actual = FileCore.TypeSelect(garbageType, mainList);
            var expected = new List<int> { 6,15,24,33,42,51,60,69,25};

            Assert.AreEqual(expected.Count, actual.Count);
            for (int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }

        }

        [TestMethod]
        public void TestMonthAddition()
        {
            FileCore.Add(FileCore.Serializer<Garbage>(Garbages));
            List<Garbage> mainList = JsonSerializer.Deserialize<List<Garbage>>(File.ReadAllText(@"MyTest.json"));

            var actual = FileCore.MonthAddition(mainList);
            var expected = new List<Garbage> { new Garbage(0, null, 6, 6, 6), new Garbage(1, null, 15, 15, 15), 
                                                new Garbage(2, null, 24, 24, 24), new Garbage(3, null, 33, 33, 33),
                                                new Garbage(4, null, 42, 42, 42), new Garbage(5, null, 51, 51, 51),
                                                new Garbage(6, null, 60, 60, 60), new Garbage(7, null, 69, 69, 69),
                                                new Garbage(8, null, 25, 25, 25)};

            for (int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i].Month, actual[i].Month);
                Assert.AreEqual(expected[i].DistrictType, actual[i].DistrictType);
                Assert.AreEqual(expected[i].AmountConstruction, actual[i].AmountConstruction);
                Assert.AreEqual(expected[i].AmountIndustrial, actual[i].AmountIndustrial);
                Assert.AreEqual(expected[i].AmountMunicipal, actual[i].AmountMunicipal);
            }
        }
    }
}
