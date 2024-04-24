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
