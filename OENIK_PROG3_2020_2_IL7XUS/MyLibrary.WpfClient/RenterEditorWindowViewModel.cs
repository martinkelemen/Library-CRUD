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
    public class RenterEditorWindowViewModel : ObservableRecipient
    {
        private string errorMessage;

        public string ErrorMessage
        {
            get { return errorMessage; }
            set { SetProperty(ref errorMessage, value); }
        }

        public RestCollection<Renter> Renters { get; set; }

        private Renter selectedRenter;

        public Renter SelectedRenter
        {
            get { return selectedRenter; }
            set
            {
                if (value != null)
                {
                    selectedRenter = new Renter()
                    {
                        Name = value.Name,
                        Address = value.Address,
                        Email = value.Email,
                        MembershipType = value.MembershipType,
                        JoinDate = value.JoinDate,
                        RenterId = value.RenterId
                    };
                    OnPropertyChanged();
                    (DeleteRenterCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }


        public ICommand CreateRenterCommand { get; set; }
        public ICommand DeleteRenterCommand { get; set; }
        public ICommand UpdateRenterCommand { get; set; }

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }

        public RenterEditorWindowViewModel()
        {
            if (!IsInDesignMode)
            {
                Renters = new RestCollection<Renter>("http://localhost:1967/", "renter", "hub");
                CreateRenterCommand = new RelayCommand(() =>
                {
                    Renters.Add(new Renter()
                    {
                        Name = SelectedRenter.Name,
                        Address = SelectedRenter.Address,
                        Email = SelectedRenter.Email,
                        MembershipType = SelectedRenter.MembershipType,
                        JoinDate = SelectedRenter.JoinDate
                    });
                });

                DeleteRenterCommand = new RelayCommand(() =>
                {
                    Renters.Delete(SelectedRenter.RenterId);
                },
                () =>
                {
                    return SelectedRenter.Name != null;
                });

                UpdateRenterCommand = new RelayCommand(() =>
                {
                    try
                    {
                        Renters.Update(SelectedRenter);
                    }
                    catch (ArgumentException ex)
                    {
                        ErrorMessage = ex.Message;
                    }
                });

                SelectedRenter = new Renter();
            }
        }
    }
}