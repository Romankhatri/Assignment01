class Program
{
    static void Main(string[] args)
    {
        var parser = new CSVParser();
        parser.Parse(@"C:\Users\learn\Desktop\Trainingship\Assignment01\People.csv");
        parser.PrintNames();
    }
}