class Person
{
    public int Index { get; set; }
    public string UserId { get; set; } = "";
    public string FirstName { get; set; } = "";
    public string LastName { get; set; } = "";
    public Gender Sex { get; set; }
    public string Email { get; set; } = "";
    public string Phone { get; set; } = "";
    public DateTime DateOfBirth { get; set; }
    public string JobTitle { get; set; } = "";

    // Constructor
    public Person(int index, string userId, string firstName, string lastName, Gender sex, string email, string phone, DateTime dateOfBirth, string jobTitle)
    {
        Index = index;
        UserId = userId;
        FirstName = firstName;
        LastName = lastName;
        Sex = sex;
        Email = email;
        Phone = phone;
        DateOfBirth = dateOfBirth;
        JobTitle = jobTitle;
    }
}