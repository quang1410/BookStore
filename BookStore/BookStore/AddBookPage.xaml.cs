using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BookStore
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddBookPage : ContentPage
    {
        public AddBookPage()
        {
            InitializeComponent();
        }

        public AddBookPage(Book book)
        {
            InitializeComponent();
            bookTitle.Text = book.title;
            bookPrice.Text = book.price.ToString();
            bookImg.Text = book.img;
        }

        private void addBookBtn_Clicked(object sender, EventArgs e)
        {
            Book newBook = new Book();
            newBook.title = bookTitle.Text;
            newBook.price = Int32.Parse(bookPrice.Text);
            newBook.img = bookImg.Text;

            Database db = new Database();
            if(db.AddBook(newBook))
            {
                DisplayAlert("Thông Báo", "Thêm Sách Thành Công", "OK");
                Navigation.PushAsync(new AdminPage());
            }
            else
            {
                DisplayAlert("Thông Báo", "Thêm Sách Thất bại", "OK");
            }
        }
    }
}