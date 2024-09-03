using Moq;
using System;
using Xunit;

public class StudentRepositoryTests
{
    [Fact]
    public void AddStudent_ShouldSendEmail()
    {
        // Arrange
        var mockEmail = new Mock<EMail>();
        mockEmail.Setup(e => e.SendMail(It.IsAny<Student>())).Returns(true);

        var studentRepository = new StudentRepository
        {
            Email = mockEmail.Object // Inject mock email
        };

        var student = new Student
        {
            Name = "John Doe",
            DateOfBirth = new DateTime(2000, 1, 1),
            Marks = 85,
            Batch = "A",
            Course = "Computer Science"
        };

        // Act
        studentRepository.AddStudent(student);

        // Assert
        mockEmail.Verify(e => e.SendMail(It.IsAny<Student>()), Times.Once);
    }

    [Fact]
    public void NumberOfStudents_ShouldBeFive()
    {
        // Arrange
        var studentRepository = new StudentRepository();
        // You need to implement a way to count the students in the database
        // This is a placeholder for demonstration purposes
        int studentCount = studentRepository.GetStudentCount();

        // Act & Assert
        Assert.Equal(5, studentCount);
    }
}
