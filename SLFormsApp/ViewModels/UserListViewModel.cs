﻿using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Plugin.Settings;
using SLFormsApp.Models;
using SLFormsApp.Services;
using Softeq.XToolkit.Common.Command;
using Softeq.XToolkit.Common.Extensions;
using Softeq.XToolkit.WhiteLabel.Mvvm;

namespace SLFormsApp.ViewModels
{
    public class UserListViewModel : ViewModelBase
    {
        private Database _dataBase;

        public UserListViewModel(Database dataBase)
        {
            _dataBase = dataBase;

            Items = new ObservableCollection<User>();

            DeleteUserCommand = new AsyncCommand<User>(DeleteUserAsync);

            LoadDataAsync().SafeTaskWrapper();
        }

        public ICommand<User> DeleteUserCommand { get; }

        public ObservableCollection<User> Items { get; }

        private async Task LoadDataAsync()
        {
            IsBusy = true;

            var users = await _dataBase.GetUsersAsync();

            users = users
                .Where(x => x.Login != CrossSettings.Current.GetValueOrDefault(Defines.CurrentUserKey, null))
                .ToList(); 

            Items.Clear();
            Items.AddRange(users);

            IsBusy = false;
        }

        private async Task DeleteUserAsync(User user)
        {
            IsBusy = true;

            await _dataBase.DeleteUserAsync(user);

            IsBusy = false;

            await LoadDataAsync();
        }
    }
}
