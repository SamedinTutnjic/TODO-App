using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Tasker.MVVM.Models;

namespace Tasker.MVVM.ViewModels
{


    public class MainViewModel : INotifyPropertyChanged
    {
        public void OnPropertyChanged([CallerMemberName] string name = "") =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        public ObservableCollection<Category> Categories { get; set; }
        public ObservableCollection<MyTask> Tasks { get; set; }

        public MainViewModel()
        {
            FillData();
            Tasks.CollectionChanged += Tasks_CollectionChanged;
        }

        private void Tasks_CollectionChanged(object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            UpdateData();
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void FillData()
        {
            Categories = new ObservableCollection<Category>
            {
                new Category
                    {
                         Id = 1,
                         CategoryName = "Finansije",
                         Color = "#CF14DF"
                    },
                    new Category
                    {
                         Id = 2,
                         CategoryName = "Posao",
                         Color = "#df6f14"
                    },
                    new Category
                    {
                         Id = 3,
                         CategoryName = "Putovanja",
                         Color = "#14df80"
                    }
            };

            Tasks = new ObservableCollection<MyTask>
            {
                new MyTask
                {
                    TaskName = "Uplatiti Ratu",
                    Completed = false,
                    CategoryId = 1
                },
                new MyTask
                {
                    TaskName = "Uplatiti kurs Njemackog",
                    Completed = false,
                    CategoryId = 1
                },
                new MyTask
                {
                    TaskName = "Uraditi EXCEL fajl",
                    Completed = false,
                    CategoryId = 2
                },
                new MyTask
                {
                    TaskName = "Poslati PROJEKT Manageru",
                    Completed = false,
                    CategoryId = 2
                },
                new MyTask
                {
                    TaskName = "Godisnji ODMOR",
                    Completed = true,
                    CategoryId = 2
                },
                new MyTask
                {
                    TaskName = "Hrvatska MORE",
                    Completed = false,
                    CategoryId = 3
                },
                new MyTask
                {
                    TaskName = "Lista stvari za more",
                    Completed = false,
                    CategoryId = 3
                }
            };

           


            UpdateData();
        }

        public void UpdateData()
        {
            foreach (var c in Categories)
            {
                var tasks = from t in Tasks
                            where t.CategoryId == c.Id
                            select t;

                var completed = from t in tasks
                                where t.Completed == true
                                select t;

                var notCompleted = from t in tasks
                                   where t.Completed == false
                                   select t;



                c.PendingTasks = notCompleted.Count();
                c.Percentage = (float)completed.Count() / (float)tasks.Count();
            }
            foreach (var t in Tasks)
            {
                t.PropertyChanged += (s, e) =>
                {
                    if (e.PropertyName == "Completed")
                    {
                        FillData();
                    }
                };



                var catColor =
                     (from c in Categories
                      where c.Id == t.CategoryId
                      select c.Color).FirstOrDefault();
                t.TaskColor = catColor;
            }
        }

    }
}