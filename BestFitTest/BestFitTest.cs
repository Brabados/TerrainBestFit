using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

[TestClass]
public class BestFitTest
{
    [TestMethod]
    public void CheckCoOrdinatesAreWorkingCorrectly()
    {
        int x = 55;
        int y = 55;
        int size = 10;

        var TestBest = new BestFit();

        float[,] result = TestBest.SetSlope(x, y, size);

        Assert.IsTrue(result != null);

    }

    [TestMethod]
    public void CheckHandlesOutOfRange()
    {
        int x = 12;
        int y = 550;
        int size = 10;

        var TestBest = new BestFit();

        float[,] result = TestBest.SetSlope(x, y, size);

        Assert.IsTrue(result == null);

    }


    [TestMethod]
    public void CheckSlopeForDirectionality()
    {
        int x = 55;
        int y = 55;
        int size = 10;

        var TestBest = new BestFit();

        float[,] result = TestBest.SetSlope(x, y, size);

        //direction should be sloping in the x axis
        Assert.IsTrue(result[0,0] <= result[size- 1,size -1 ]);

    }

}

