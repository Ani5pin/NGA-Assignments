using System;

public class EMail
{
    public bool SendMail(Student student)
    {
        // Email sending code goes here
        Console.WriteLine($"Sending email to {student.Name}...");
        // Simulate email sending
        return true;
    }
}
