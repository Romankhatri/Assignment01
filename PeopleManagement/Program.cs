class Program
{
    static void Main(string[] args)
    {
        CSVParser csvParser = new CSVParser();
        List<Person> people = new List<Person>();
        csvParser.Parse(@"C:\Users\learn\Desktop\Trainingship\Assignment01\People.csv");

        PeopleReport report = new PeopleReport();
        report.SaveMales(people, "males.csv");
        report.SaveFemales(people, "adultfemales.csv");
        report.SaveDotComUsers(people, "dotcomusers.csv");
    }
}