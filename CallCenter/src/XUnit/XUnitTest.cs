// using Xunit;
// using CallCenter.Services;
// using CallCenter.Controllers;
// using CallCenter.Models;

// namespace XUnitTestProject
// {
//     public class UnitTest1
//     {
//         [Fact]
//         public void LoginTest_InvalidUsername()
//         {
//             // Arrange
//             AddLoginRequest bump = new AddLoginRequest(); 
//             LoginServices login = new LoginServices();

//             // Act
//             string result = login.AuthenticateUser(bump);

//             // Assert
//             Assert.Equal("Invalid Username", result);
//         }

//         [Fact]
//         public void SearchTest_InvalidIDFormat()
//         {
//             // Arrange
//             ClientController clientController = new ClientController();

//             // Act
//             string result = clientController.GetClientByClientId("user"); // Pass an invalid ID format

//             // Assert
//             Assert.Equal("Invalid ID format", result);
//         }
//     }
// }
