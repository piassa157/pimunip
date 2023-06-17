namespace test;

public class UnitTest1
{
    [Fact]
   public void TestStringEquality()
    {
        // Arrange
        string testString = "this";

        // Act

        // Assert
        Assert.Equal("this", testString);
    }
}