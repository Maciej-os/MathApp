namespace MathApp.Tests
{
    public class StatisticsTests
    {
        [Test]
        public void CheckingMemoryStatistics()
        {
            // arange
            var test01 = new Test("Maciek", "Kowalski");
            test01.pointsInMemory.Add(30);
            test01.pointsInMemory.Add(10);
            test01.pointsInMemory.Add(50);

            //act
            var statistics = test01.GetMemoryStatistics();
            var max = statistics.Max;
            var min = statistics.Min;
            var avg = statistics.Avg;

            //assert
            Assert.AreEqual(10, min);
            Assert.AreEqual(50, max);
            Assert.AreEqual(30, avg);
        }

        [Test]
        public void CheckingFileStatistics()
        {
            
            // arange
            var test01 = new Test("Maciek", "Kowalski");
            var fileName = test01.FileName;

            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }    
                
            test01.RecordPoints(30);
            test01.RecordPoints(10);
            test01.RecordPoints(50);

            //act
            var statistics = test01.GetFileStatistics();
            var max = statistics.Max;
            var min = statistics.Min;
            var avg = statistics.Avg;

            //assert
            Assert.AreEqual(10, min);
            Assert.AreEqual(50, max);
            Assert.AreEqual(30, avg);
        }
    }
}