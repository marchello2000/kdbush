using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KDBush.Tests
{
    [TestClass]
    public class BasicTests
    {
        List<Point> points = new List<Point>()
            {
                new Point(54, 1, 0),
                new Point(97, 21, 1),
                new Point(65, 35, 2),
                new Point(33, 54, 3),
                new Point(95, 39, 4),
                new Point(54, 3, 5),
                new Point(53, 54, 6),
                new Point(84, 72, 7),
                new Point(33, 34, 8),
                new Point(43, 15, 9),
                new Point(52, 83, 10),
                new Point(81, 23, 11),
                new Point(1, 61, 12),
                new Point(38, 74, 13),
                new Point(11, 91, 14),
                new Point(24, 56, 15),
                new Point(90, 31, 16),
                new Point(25, 57, 17),
                new Point(46, 61, 18),
                new Point(29, 69, 19),
                new Point(49, 60, 20),
                new Point(4, 98, 21),
                new Point(71, 15, 22),
                new Point(60, 25, 23),
                new Point(38, 84, 24),
                new Point(52, 38, 25),
                new Point(94, 51, 26),
                new Point(13, 25, 27),
                new Point(77, 73, 28),
                new Point(88, 87, 29),
                new Point(6, 27, 30),
                new Point(58, 22, 31),
                new Point(53, 28, 32),
                new Point(27, 91, 33),
                new Point(96, 98, 34),
                new Point(93, 14, 35),
                new Point(22, 93, 36),
                new Point(45, 94, 37),
                new Point(18, 28, 38),
                new Point(35, 15, 39),
                new Point(19, 81, 40),
                new Point(20, 81, 41),
                new Point(67, 53, 42),
                new Point(43, 3, 43),
                new Point(47, 66, 44),
                new Point(48, 34, 45),
                new Point(46, 12, 46),
                new Point(32, 38, 47),
                new Point(43, 12, 48),
                new Point(39, 94, 49),
                new Point(88, 62, 50),
                new Point(66, 14, 51),
                new Point(84, 30, 52),
                new Point(72, 81, 53),
                new Point(41, 92, 54),
                new Point(26, 4, 55),
                new Point(6, 76, 56),
                new Point(47, 21, 57),
                new Point(57, 70, 58),
                new Point(71, 82, 59),
                new Point(50, 68, 60),
                new Point(96, 18, 61),
                new Point(40, 31, 62),
                new Point(78, 53, 63),
                new Point(71, 90, 64),
                new Point(32, 14, 65),
                new Point(55, 6, 66),
                new Point(32, 88, 67),
                new Point(62, 32, 68),
                new Point(21, 67, 69),
                new Point(73, 81, 70),
                new Point(44, 64, 71),
                new Point(29, 50, 72),
                new Point(70, 5, 73),
                new Point(6, 22, 74),
                new Point(68, 3, 75),
                new Point(11, 23, 76),
                new Point(20, 42, 77),
                new Point(21, 73, 78),
                new Point(63, 86, 79),
                new Point(9, 40, 80),
                new Point(99, 2, 81),
                new Point(99, 76, 82),
                new Point(56, 77, 83),
                new Point(83, 6, 84),
                new Point(21, 72, 85),
                new Point(78, 30, 86),
                new Point(75, 53, 87),
                new Point(41, 11, 88),
                new Point(95, 20, 89),
                new Point(30, 38, 90),
                new Point(96, 82, 91),
                new Point(65, 48, 92),
                new Point(33, 18, 93),
                new Point(87, 28, 94),
                new Point(10, 10, 95),
                new Point(40, 34, 96),
                new Point(10, 20, 97),
                new Point(47, 29, 98),
                new Point(46, 78, 99),
        };

        [TestMethod]
        public void IndexIsSorted()
        {
            // Verify that indexing works
            int[] ids = new int[] { 97, 74, 95, 30, 77, 38, 76, 27, 80, 55, 72, 90, 88, 48, 43, 46, 65, 39, 62, 93, 9, 96, 47, 8, 3, 12, 15, 14, 21, 41, 36, 40, 69, 56, 85, 78, 17, 71, 44,
                19, 18, 13, 99, 24, 67, 33, 37, 49, 54, 57, 98, 45, 23, 31, 66, 68, 0, 32, 5, 51, 75, 73, 84, 35, 81, 22, 61, 89, 1, 11, 86, 52, 94, 16, 2, 6, 25, 92,
                42, 20, 60, 58, 83, 79, 64, 10, 59, 53, 26, 87, 4, 63, 50, 7, 28, 82, 70, 29, 34, 91 };

            KDBush kdbush = new KDBush(10);
            kdbush.Index(points);

            for (int i = 0; i < points.Count; i++)
            {
                Assert.AreEqual(ids[i], kdbush.points[i].Id);
            }
        }

        [TestMethod]
        public void TestRectQuery()
        {
            // Verify that rectangular query works
            KDBush kdbush = new KDBush(10);
            kdbush.Index(points);

            var result = kdbush.Query(20, 30, 50, 70);

            List<int> correctPoints = new List<int>(new int[] { 60, 20, 45, 3, 17, 71, 44, 19, 18, 15, 69, 90, 62, 96, 47, 8, 77, 72 });

            AssertPointsMatch(correctPoints, result);
        }

        [TestMethod]
        public void TestRadiusQuery()
        {
            // Verify that circular query works
            KDBush kdbush = new KDBush(10);
            kdbush.Index(points);

            var result = kdbush.Query(50, 50, 20);

            List<int> correctPoints = new List<int>(new int[] { 60, 6, 25, 92, 42, 20, 45, 3, 71, 44, 18, 96 });
            AssertPointsMatch(correctPoints, result);
        }

        private void AssertPointsMatch(List<int> correctPoints, List<Point> result)
        {
            Assert.AreEqual(correctPoints.Count, result.Count);

            foreach (Point p in result)
            {
                Assert.IsTrue(correctPoints.Contains(p.Id));
            }
        }

    }
}
