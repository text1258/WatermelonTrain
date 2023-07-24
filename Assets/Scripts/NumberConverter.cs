public static class NumberConverter
{
    public static string FormatNumber(double number)
    {
        if (number >= 100000000)
        {
            return (number / 1000000D).ToString("0.#M");
        }
        if (number >= 1000000)
        {
            return (number / 1000000D).ToString("0.##M");
        }
        if (number >= 100000)
        {
            return (number / 1000D).ToString("0.#k");
        }
        if (number >= 10000)
        {
            return (number / 1000D).ToString("0.##k");
        }

        return number.ToString("#,0");
    }
}