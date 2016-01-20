/*
* Copyright (C) JAMK/IT/Esa Salmikangas
* This file is part of the IIO11300 course project.
* Created: 12.1.2016 Modified: 20.1.2016
* Authors: Joni Kukko, Esa Salmikangas
*/
using System;


namespace Tehtava1
{
    public class BusinessLogicWindow
    {

        // metodi ikkunan koko pinta-alan laskemiseen
        public static double CalculateWindowArea(double windowWidht, double windowHeight)
        {
            if (windowWidht == 0 || windowHeight == 0)
            {
                throw new Exception("Annetut arvot olivat virheelliset!");
            }

            return windowWidht * windowHeight;
        }


        // metodi karmin piirin laskemisene
        public static double CalculateFrameSphere(double windowWidht, double windowHeight)
        {
            if (windowWidht == 0 || windowHeight == 0)
            {
                throw new Exception("Annetut arvot olivat virheelliset!");
            }

            return (windowWidht * 2) + (windowHeight * 2);
        }


        // metodi karmin pinta-alan laskemiseen
        public static double CalculateFrameArea(double windowWidht, double windowHeight, double frameWidht)
        {
            if (windowWidht == 0 || windowHeight == 0 || frameWidht == 0)
            {
                throw new Exception("Annetut arvot olivat virheelliset!");
            }

            return ((windowWidht - frameWidht) * frameWidht * 2) + (windowHeight * frameWidht * 2);
        }
    }
}
