using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectWithDataBase
{
    public partial class  MainWindowVM : ObservableObject
    {
        [ObservableProperty]
        public string firstName;

        [ObservableProperty]
        public string lastName;

        [ObservableProperty]
        public int age;

        [ObservableProperty]
        ObservableCollection<Person> people;

        [RelayCommand]
        public void InsertPerson()
        {
            Person p = new Person()
            {
                FirstName = firstName,
                LastName = lastName,
                Age = age
            };
            using ( var db = new PersonContext())
            {
                db.Persons.Add(p);
                db.SaveChanges();
            }
        }

        public void LoadPerson()
        {
            using(var db = new PersonContext())
            {
                var list = db.Persons.ToList();
                People = new ObservableCollection<Person>(list);
            }
        }
        public MainWindowVM()
        {   
            LoadPerson();

        }
    }

}
