using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Prism.Navigation;
using Sample.Models;
using Sample.Services;
using Sample.ViewModels;
using Xamarin.Forms;

namespace UnitTestSample
{
    [TestClass]
    public class MainPageViewModelTests
    {
        private Mock<INavigationService> _navigationService;
        private Mock<ITodoItemService> _todoItemService;
        private MainPageViewModel _mainPageViewModel;

        [TestInitialize]
        public void Init()
        {
            //Create a mock
            _navigationService = new Mock<INavigationService>();
            _todoItemService = new Mock<ITodoItemService>();

            //Insert the mock's object
            _mainPageViewModel = new MainPageViewModel(_navigationService.Object, _todoItemService.Object);
        }

        [TestMethod]
        public void NavigatePageCommand_Should_Call_NavigateAsync_Method()
        {
            //Arrange
            _navigationService.Setup(e => e.NavigateAsync(nameof(ContentPage)));

            //Act
            _mainPageViewModel.NavigatePageCommand?.Execute(null);

            //Assert
            _navigationService.Verify(e=> e.NavigateAsync(nameof(ContentPage)));
        }


        [TestMethod]
        public void AddTodoCommand_Should_Be_Able_To_Add_Item_On_ToDo_Items_List()
        {
            //Arrange
            _todoItemService.Setup(e => e.Add(It.IsAny<TodoItem>()));
            _todoItemService.Setup(e => e.Get()) // we are mocking a get to return list
                            .Returns(new List<TodoItem>{ new TodoItem
                                {
                                    Name = "Test",
                                    IsComplete = true
                                }});

            //Act
            _mainPageViewModel.AddTodoCommand?.Execute(null);

            //Assert
            _todoItemService.Verify(e => e.Add(It.IsAny<TodoItem>()));
            _todoItemService.Verify(e => e.Get());
            Assert.IsTrue(_mainPageViewModel.TodoItems.Count > 0);
        }


        [TestCleanup]
        public void Cleanup()
        {
            //Cleanup here
            _navigationService = null;
            _todoItemService = null;
            _mainPageViewModel = null;
        }
    }
}
