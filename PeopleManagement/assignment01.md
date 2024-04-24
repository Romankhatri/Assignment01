//Person.cs

// //creating class Person
// class Person
// {
//     //field names
//     public int Index;
//     public string UserId;
//     public string FirstName;
//     public string LastName;
//     public string Sex;
//     public string Email;
//     public string Phone;
//     public DateTime DateOfBirth;
//     public string JobTitle;

//     //constructor
//     public Person(int index, string userId, string firstName, string lastName, string sex, string email, string phone, DateTime dateOfBirth, string jobTitle)
//     {
//         Index = index;
//         UserId = userId;
//         FirstName = firstName;
//         LastName = lastName;
//         Sex = sex;
//         Email = email;
//         Phone = phone;
//         DateOfBirth = dateOfBirth;
//         JobTitle = jobTitle;
//     }
// }



//CSVParser.cs

class CSVParser
{
    private List<Person> people;

    public CSVParser()
    {
        people = new List<Person>();
    }

public void Parse(string filePath)
    {
        using (var reader = new StreamReader(filePath))
        {
            reader.ReadLine();
            string line;
            #pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            while ((line = reader.ReadLine()) != null)
            {
                var data = line.Split(',');
                var index = int.Parse(data[0]);
                   var userId = data[1];
                   var firstName = data[2];
                   var lastName = data[3];
                   var sex = data[4];
                   var email = data[5];
                   var phone = data[6];
                   var dateOfBirth = data[7];
                   var jobTitle = data[8];
                       
                   var person = new Person(index, userId, firstName, lastName, sex, email, phone, dateOfBirth, jobTitle);
                   people.Add(person);
                }
            }
    }
    public void PrintNames()
    {
        foreach (var person in people)
        {
            Console.WriteLine($"{person.FirstName} {person.LastName}");
        }
    }
}

//Program.cs

// class Program
// {
//     static void Main(string[] args)
//     {
//         var parser = new CSVParser(); //CSVParser instance
//         parser.Parse(@"C:\Users\learn\Desktop\Trainingship\Assignment01\People.csv");
//         parser.PrintNames(); //call point
//     }
// }


//PeopleReport.cs
class PeopleReport
{
    public void SaveMales(List<Person> people, string outputPath)
    {
        var males = people.Where(p => p.Sex.Equals("Male", StringComparison.OrdinalIgnoreCase));
        WriteToFile(males, outputPath);
    }

    public void SaveFemales(List<Person> people, string outputPath)
    {
        var adultFemales = people.Where(p => p.Sex.Equals("Female", StringComparison.OrdinalIgnoreCase) &&
                                              (DateTime.Now.Year - p.DateOfBirth.Year) >= 20);
        WriteToFile(adultFemales, outputPath);
    }

    public void SaveDotComUsers(List<Person> people, string outputPath)
    {
        var dotComUsers = people.Where(p => p.Email.EndsWith("@example.com"));
        var dataToWrite = dotComUsers.Select(p => $"{p.UserId},{p.Email},{p.Phone}");

        File.WriteAllLines(outputPath, dataToWrite);
    }

    private void WriteToFile(IEnumerable<Person> people, string outputPath)
    {
        var dataToWrite = people.Select(p => $"{p.Index},{p.UserId},{p.FirstName},{p.LastName},{p.Sex},{p.Email},{p.Phone},{p.DateOfBirth},{p.JobTitle}");
        File.WriteAllLines(outputPath, dataToWrite);
    }
}

//Program.cs
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