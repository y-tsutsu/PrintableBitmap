namespace PrintableBitmap
{
    class Program
    {
        static void Main(string[] args)
        {
            var bmp = new PrintableBitmap(args[0]);
            System.Console.WriteLine(bmp);
        }
    }
}
