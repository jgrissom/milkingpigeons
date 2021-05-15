using System;
namespace MilkingPigeons.Utilities
{
    public static class Numbers
    {
        private static int Base10ToBase4(int n){
            int num = 0;
            int quotient = n;
            int i = 0;
            while (quotient != 0){
                int rem = quotient % 4;
                quotient = quotient / 4;
                num += rem * (int)Math.Pow(10, i);
                i++;
            }
            return num;
        }
    }
}

