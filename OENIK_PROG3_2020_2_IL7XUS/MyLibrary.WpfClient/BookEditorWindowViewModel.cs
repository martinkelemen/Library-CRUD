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
    public class InvalidInputEventArgs : EventArgs
    {
        public string Message { get; set; }

        public string Caption { get; set; }

        public InvalidInputEventArgs(string message, string caption)
        {
            Message = message;
            Caption = caption;
        }
    }
    public class BookEditorWindowViewModel : ObservableRecipient
    {
        private string errorMessage;

        public string ErrorMessage
        {
            get { return errorMessage; }
            set { SetProperty(ref errorMessage, value); }
        }

        public event EventHandler invalidInput;

        public RestCollection<Book> Books { get; set; }

        private string actual_isbn;

        private Book selectedBook;

        public Book SelectedBook
        {
            get { return selectedBook; }
            set
            {
                if (value != null)
                {
                    selectedBook = new Book()
                    {
                        Title = value.Title,
                        AuthorName = value.AuthorName,
                        Year = value.Year,
                        Language = value.Language,
                        Category = value.Category,
                        PageNumber = value.PageNumber,
                        Publisher = value.Publisher,
                        ISBN = value.ISBN
                    };
                    actual_isbn = SelectedBook.ISBN;
                    OnPropertyChanged();
                    (DeleteBookCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }


        public ICommand CreateBookCommand { get; set; }
        public ICommand DeleteBookCommand { get; set; }
        public ICommand UpdateBookCommand { get; set; }

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }

        public BookEditorWindowViewModel()
        {
            if (!IsInDesignMode)
            {
                Books = new RestCollection<Book>("http://localhost:1967/", "book", "hub");
                CreateBookCommand = new RelayCommand(() =>
                {
                    if (SelectedBook.PageNumber == 0 || SelectedBook.Year == 0)
                    {
                        invalidInput?.Invoke(this, new InvalidInputEventArgs("The page number and the year can be only a number!", "Invalid input"));
                    }
                    else
                    {
                        Books.Add(new Book()
                        {
                            ISBN = SelectedBook.ISBN,
                            Title = SelectedBook.Title,
                            AuthorName = SelectedBook.AuthorName,
                            Year = SelectedBook.Year,
                            Language = SelectedBook.Language,
                            Category = SelectedBook.Category,
                            PageNumber = SelectedBook.PageNumber,
                            Publisher = SelectedBook.Publisher
                        });
                    }
                });

                DeleteBookCommand = new RelayCommand(() =>
                {
                    Books.DeleteString(SelectedBook.ISBN);
                },
                () =>
                {
                    return SelectedBook.ISBN != null;
                });

                UpdateBookCommand = new RelayCommand(() =>
                {
                    try
                    {
                        Books.Update(SelectedBook);
                    }
                    catch (ArgumentException ex)
                    {
                        ErrorMessage = ex.Message;
                    }
                },
                () =>
                {
                    return actual_isbn == SelectedBook.ISBN;
                });

                SelectedBook = new Book();
            }
        }
    }
}
