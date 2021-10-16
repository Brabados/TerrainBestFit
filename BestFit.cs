using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    class BestFit
    {
    float[,] SetSlope(float[,] calc)
    {
        Random ran = new Random();
        int size = ran.Next(10, 30);
        //setting handed array to a changeable array


        float[,] ToMod = calc;

        //Arrays to contain the X,Y and Z of each point
        Double[] Xmod = new double[ToMod.Length];
        Double[] Ymod = new double[ToMod.Length];
        Double[] Zmod = new double[ToMod.Length];

        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                ToMod[i, j] = (float)ran.NextDouble();
            }
        }

        int lengthComp = 0;

        //setting up one dimentional arrays to store points
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                Xmod[lengthComp] = i;
                Ymod[lengthComp] = j;
                Zmod[lengthComp] = ToMod[i, j];
                lengthComp++;
            }

            if (lengthComp > ToMod.Length)
            {
                i = size;
            }
        }

        //sets up X and Y to be seperate from Z
        double[,] tmp_A = new double[Xmod.Length, 3];
        double[] tmp_b = new double[Xmod.Length];
        for (int i = 0; i < Xmod.Length; i++)
        {
            tmp_A[i, 0] = Xmod[i];
            tmp_A[i, 1] = Ymod[i];
            tmp_A[i, 2] = 1;
            tmp_b[i] = Zmod[i];
        }

        double[,] b = Accord.Math.Matrix.Transpose(tmp_b);
        double[,] A = tmp_A;

        //Uses the left psudoinverse to calculate the sum of the slope as [x , y , z]
        double[,] fit = Accord.Math.Matrix.PseudoInverse(A);
        fit = Accord.Math.Matrix.Dot(fit, b);


        int iterator = 0;
        //one dimentional array to contain new Z points
        double[] NewZ = new double[100];

        //Uses found sum of AX + BY + C = Z and sets into array
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                NewZ[iterator] = (Xmod[i] * ((double)fit[0, 0])) + (Ymod[j] * ((double)fit[1, 0])) + ((double)fit[2, 0]);
                iterator++;
            }
        }

        iterator = 0;
        //rearranges new points back into original array to be returned
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                ToMod[i, j] = (float)NewZ[iterator];
                iterator++;
            }

        }

        return ToMod;
    }

    float median(float[,] calc)
    {
        List<float> AverageList = new List<float>(); // list of each hight value to find the average value
        float found = 0;

        foreach (float x in calc)
        {
            AverageList.Add(x);
        }

        AverageList.Sort();

        if (AverageList.Count % 2 == 0)
        {
            found = AverageList[(AverageList.Count / 2)];
        }
        else
        {
            found = AverageList[((AverageList.Count - 1) / 2)];
        }

        return found;
    }
    float mean(float[,] calc)
    {
        List<float> AverageList = new List<float>(); // list of each hight value to find the average value
        AverageList.Clear();
        float found = 0;

        foreach (float x in calc)
        {
            AverageList.Add(x);
            found = found + x;
        }

        found = found / AverageList.Count;


        return found;
    }
}

