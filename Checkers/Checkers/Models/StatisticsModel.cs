using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Checkers.Services.Repository;
using Checkers.Views;

namespace Checkers.Models
{
    public class StatisticsModel
    {
        private static ObservableCollection<User> _users;
        private static DBRepository _dbRepository;

        public static StatisticsWindow View { get; set; }
        
        public static void UpdateGrid()
        {
            _users = new ObservableCollection<User>();
            _dbRepository = new Json("D:\\users.json");

            foreach (var user in _dbRepository.GetData())
            {
                _users.Add(user);
            }

            View.DataGridStatistics.ItemsSource = _users;
        }
    }
}
