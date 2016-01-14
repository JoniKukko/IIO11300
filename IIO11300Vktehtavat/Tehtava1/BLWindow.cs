using System;


namespace Tehtava1
{
    public class BusinessLogicWindow
    {
        public static double CalculatePerimeter(double widht, double height)
        {
            if (widht == 0 || height == 0)
            {
                throw new Exception("Annetut arvot olivat virheelliset!");
            }

            return 2 * widht + 2 * height;
        }
    }
}
