using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Excel = Microsoft.Office.Interop.Excel;


namespace HW_WebAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests : HW_AuthTestBase
    {

        public static IEnumerable<GroupData> RandomGroupDataProvider()
        {
            List<GroupData> groups = new List<GroupData>();
            for (int i = 0; i < 5; i++)
                {
                groups.Add(new GroupData(GenerateRandomString(30))
                {
                    Gheader = GenerateRandomString(100),
                    Gfooter = GenerateRandomString(100)
                });
                }
            return groups;
        }


        public static IEnumerable<GroupData> GroupDataFromCsvFile()
        {
            List<GroupData> fGroups = new List<GroupData>();
            string[] lines = File.ReadAllLines(@"groups.csv");
            foreach(string l in lines)
            {
                string[] parts = l.Split(',');
                fGroups.Add(new GroupData(parts[0])
                {
                    Gheader = parts[1],
                    Gfooter = parts[2]
                });
            }
            return fGroups;
        }

        public static IEnumerable<GroupData> GroupDataFromXmlFile()
        {
            return (List<GroupData>) new XmlSerializer(typeof(List<GroupData>)).Deserialize(new StreamReader(@"groups.xml"));
        }

        public static IEnumerable<GroupData> GroupDataFromJsonFile()
        {
            return JsonConvert.DeserializeObject<List<GroupData>>(File.ReadAllText(@"groups.json"));
        }

        public static IEnumerable<GroupData> GroupDataFromExcelFile()
        {
            List<GroupData> groups =  new List<GroupData>();
            Excel.Application app = new Excel.Application();
            Excel.Workbook wb = app.Workbooks.Open(Path.Combine(Directory.GetCurrentDirectory(), @"groups.xlsx"));
            Excel.Worksheet sheet = wb.ActiveSheet;
            Excel.Range range = sheet.UsedRange;
            for(int i = 1; i <=range.Rows.Count; i++)
            {
                groups.Add(new GroupData()
                {
                    Gname = range.Cells[i, 1].Value,
                    Gheader = range.Cells[i, 2].Value,
                    Gfooter = range.Cells[i, 3].Value
                    
                });
            }
            wb.Close();
            app.Visible = false;
            app.Quit();
            return groups;

        }

        [Test, TestCaseSource("RandomGroupDataProvider")]
        public void HW_GroupCreationTest(GroupData group)
        {
            /*GroupData group = new GroupData("Focus Group A")
            {
                Gheader = "Focus A",
                Gfooter = "Focus A footer"
            };*/

            List<GroupData> oldGroups = appMan.Group.GetGroupList();
            appMan.Group.Create(group);

            List<GroupData> newGroups = appMan.Group.GetGroupList();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }

        [Test, TestCaseSource("GroupDataFromCsvFile")]
        public void HW_GroupCreationTestfromCsvFile(GroupData group)
        {
            List<GroupData> oldGroups = appMan.Group.GetGroupList();
            appMan.Group.Create(group);

            List<GroupData> newGroups = appMan.Group.GetGroupList();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }

        [Test, TestCaseSource("GroupDataFromXmlFile")]
        public void HW_GroupCreationTestfromXmlFile(GroupData group)
        {
            List<GroupData> oldGroups = appMan.Group.GetGroupList();
            appMan.Group.Create(group);

            List<GroupData> newGroups = appMan.Group.GetGroupList();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }

        [Test, TestCaseSource("GroupDataFromJsonFile")]
        public void HW_GroupCreationTestfromJsonFile(GroupData group)
        {
            List<GroupData> oldGroups = appMan.Group.GetGroupList();
            appMan.Group.Create(group);

            List<GroupData> newGroups = appMan.Group.GetGroupList();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }

        [Test, TestCaseSource("GroupDataFromExcelFile")]
        public void HW_GroupCreationTestfromExcelFile(GroupData group)
        {
            List<GroupData> oldGroups = appMan.Group.GetGroupList();
            appMan.Group.Create(group);

            List<GroupData> newGroups = appMan.Group.GetGroupList();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }

        /*[Test]
         public void HW_EmptyGroupCreationTest()
        {
            GroupData group = new GroupData("")
            {
                Gheader = "",
                Gfooter = ""
            };

            List<GroupData> oldGroups = appMan.Group.GetGroupList();
            appMan.Group.Create(group);

            List<GroupData> newGroups = appMan.Group.GetGroupList();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }*/

        [Test]
        public void HW_BadNameGroupCreationTest()
        {
            GroupData group = new GroupData("a'a")
            {
                Gheader = "",
                Gfooter = ""
            };

            List<GroupData> oldGroups = appMan.Group.GetGroupList();
            appMan.Group.Create(group);

            List<GroupData> newGroups = appMan.Group.GetGroupList();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}