using WebApiExercise;

namespace tests;

public class UnitTest1
{
    [Fact]
    public void PersonCreationTest()
    {
        //Arrange
        var service = new PersonService();
        var testPerson = new NewPerson { name = "John", age = 25, gender = 'M', email = "banana@gmail.com" };
        
        //Act
        service.CreatePerson(testPerson);
        var createdPerson = service.People.Last();
        
        //Assert
        Assert.Equal("John", createdPerson.name);
    }
    
    [Fact]
    public void GetSpecificPersonTest()
    {
        //Arrange
     var service = new PersonService();
     
        //Act
        Person testPerson = service.GetSpecificPerson(1);
        
        //Assert
        Assert.Equal("John", testPerson.name);
    }
    
    [Fact]
    public void GetSpecificPersonTestFail()
    {
        //Arrange
        var service = new PersonService();
        
        //Assert
        Assert.Throws<Exception>(() => service.GetSpecificPerson(999));
    }

    [Fact]
    public void UpdatePersonTest()
    {
        //Arrange
        var service = new PersonService();
        
        //Act
        var testPerson = service.People.First();
        testPerson.age = 126;
        service.UpdatePerson(testPerson);
        
        //Assert
        Assert.Equal(126, service.People.First().age);
    }
    
    [Fact]
    public void UpdatePersonTestFail()
    {
        //Arrange
        var service = new PersonService();
        
        //Act
        var testPerson = new Person() { id = 999, age = 126, email = "test@gmail.com", gender = 'M', name = "Harry"};
        
        //Assert
        Assert.Throws<Exception>(() => service.UpdatePerson(testPerson));
        
    }
    
    [Fact]
    public void DeletePersonTest()
    {
        //Arrange
        var service = new PersonService();
        
        //Act
        var testPerson = service.People.First();
        service.DeletePerson(testPerson.id);
        
        //Assert
        Assert.Equal(2, service.People.Count);
        
    }
    
    [Fact]
    public void DeletePersonTestFail()
    {
        //Arrange
        var service = new PersonService();
        
        
        //Assert
        Assert.Throws<Exception>(() => service.DeletePerson(999));
        
    }
}
