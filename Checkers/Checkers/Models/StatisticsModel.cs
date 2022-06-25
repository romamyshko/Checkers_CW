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
        private readonly ObservableCollection<User> _users;
        private DBRepository _dbRepository;

        public StatisticsWindow View { get; set; }
        

        public StatisticsModel(StatisticsWindow view)
        {
            View = view;
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
