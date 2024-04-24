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