using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Sample.Models;
using Sample.Services;
using Xamarin.Forms;

namespace Sample.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly ITodoItemService _todoItemService;
        private ObservableCollection<TodoItem> _todoItems;

        public MainPageViewModel(
            INavigationService navigationService, 
            ITodoItemService todoItemService) 
            : base (navigationService)
        {
            _navigationService = navigationService;
            _todoItemService = todoItemService;
            Title = "Main Page";
        }

        private ICommand _navigatePageCommand;

        public ICommand NavigatePageCommand =>
            _navigatePageCommand ?? (_navigatePageCommand = new DelegateCommand(() =>
                {
                    _navigationService.NavigateAsync(nameof(ContentPage));
                }));


        private ICommand _addTodoCommand;

        public ICommand AddTodoCommand =>
            _addTodoCommand ?? (_addTodoCommand = new DelegateCommand(() =>
            {
                var item = new TodoItem
                {
                    Id = "0",
                    Name = "Do Laundry",
                    IsComplete = false
                };

                _todoItemService.Add(item);

                RefreshRecord();
            }));

        public ObservableCollection<TodoItem> TodoItems
        {
            get => _todoItems;
            set => SetProperty(ref _todoItems, value);
        }

        private void RefreshRecord()
        {
            TodoItems = new ObservableCollection<TodoItem>(_todoItemService.Get());
        }
    }
}
