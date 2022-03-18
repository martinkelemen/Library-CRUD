using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using MyLibrary.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MyLibrary.WpfClient
{
    public class WorkerEditorWindowViewModel : ObservableRecipient
    {
        private string errorMessage;

        public string ErrorMessage
        {
            get { return errorMessage; }
            set { SetProperty(ref errorMessage, value); }
        }

        public RestCollection<Worker> Workers { get; set; }

        private Worker selectedWorker;

        public Worker SelectedWorker
        {
            get { return selectedWorker; }
            set
            {
                if (value != null)
                {
                    selectedWorker = new Worker()
                    {
                        Name = value.Name,
                        BirthDate = value.BirthDate,
                        Gender = value.Gender,
                        Address = value.Address,
                        Email = value.Email,
                        Salary = value.Salary,
                        HireDate = value.HireDate,
                        WorkerId = value.WorkerId
                    };
                    OnPropertyChanged();
                    (DeleteWorkerCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }


        public ICommand CreateWorkerCommand { get; set; }
        public ICommand DeleteWorkerCommand { get; set; }
        public ICommand UpdateWorkerCommand { get; set; }

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }

        public WorkerEditorWindowViewModel()
        {
            if (!IsInDesignMode)
            {
                Workers = new RestCollection<Worker>("http://localhost:1967/", "worker", "hub");
                CreateWorkerCommand = new RelayCommand(() =>
                {
                    Workers.Add(new Worker()
                    {
                        Name = SelectedWorker.Name,
                        BirthDate = SelectedWorker.BirthDate,
                        Gender = SelectedWorker.Gender,
                        Address = SelectedWorker.Address,
                        Email = SelectedWorker.Email,
                        Salary = SelectedWorker.Salary,
                        HireDate = SelectedWorker.HireDate
                    });
                });

                DeleteWorkerCommand = new RelayCommand(() =>
                {
                    Workers.Delete(SelectedWorker.WorkerId);
                },
                () =>
                {
                    return SelectedWorker.Name != null;
                });

                UpdateWorkerCommand = new RelayCommand(() =>
                {
                    try
                    {
                        Workers.Update(SelectedWorker);
                    }
                    catch (ArgumentException ex)
                    {
                        ErrorMessage = ex.Message;
                    }
                });

                SelectedWorker = new Worker();
            }
        }
    }
}