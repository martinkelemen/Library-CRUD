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
    public class MainWindowViewModel : ObservableRecipient
    {
        public ICommand BookEditorCommand { get; set; }
        public ICommand RenterEditorCommand { get; set; }
        public ICommand WorkerEditorCommand { get; set; }

        public MainWindowViewModel()
        {
            BookEditorCommand = new RelayCommand(() =>
            {
                new BookEditorWindow().ShowDialog();
            });

            RenterEditorCommand = new RelayCommand(() =>
            {
                new RenterEditorWindow().ShowDialog();
            });

            WorkerEditorCommand = new RelayCommand(() =>
            {
                new WorkerEditorWindow().ShowDialog();
            });
        }
    }
}
