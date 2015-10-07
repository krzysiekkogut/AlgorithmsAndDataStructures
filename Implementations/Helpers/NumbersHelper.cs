namespace Implementations.Helpers
{
    public static class NumbersHelper
    {
        public static bool Odd(this long number)
        {
            return (number & 1) == 1;
        }

        public static bool Odd(this int number)
        {
            return (number & 1) == 1;
        }

        public static bool Even(this long number)
        {
            return !number.Odd();
        }

        public static bool Even(this int number)
        {
            return !number.Odd();
        }
    }
}
