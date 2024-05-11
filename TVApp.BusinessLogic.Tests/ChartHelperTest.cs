using OxyPlot.Series;
using TVAppBusinessLogic;

namespace TVApp.BusinessLogic.Tests;

public class ChartHelperTest
{
    ChartHelper classtotest;
    [SetUp]
    public void Setup()
    {
        classtotest = new ChartHelper();
    }

    [Test]
    public void CreateDictionary_Creates_A_Dictionary_With_The_Correct_Number_Of_Items()
    {
        DateTime startDate = new DateTime(2024, 5, 1);
        DateTime endDate = new DateTime(2024, 5, 10);

        var result = classtotest.CreateDictionary(startDate, endDate);

        Assert.AreEqual(10, result.Count);
    }

    [Test]
    public void CreateBarItems_Returns_With_The_Correct_Number_Of_Items()
    {
        Dictionary<DateTime, int> dict = new Dictionary<DateTime, int>
        {
            { new DateTime(2024, 5, 1), 10 },
            { new DateTime(2024, 5, 2), 20 },
            { new DateTime(2024, 5, 3), 15 }
        };

        List<BarItem> result = classtotest.CreateBarItems(dict);

        Assert.AreEqual(dict.Count, result.Count);
    }

}
