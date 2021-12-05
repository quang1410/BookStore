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
    public partial class EditBookPage : ContentPage
    {
        Book book;
        public EditBookPage()
        {
            InitializeComponent();
        }

        public EditBookPage(Book book)
        {
            InitializeComponent();
            bookTitle.Text = book.title;
            bookPrice.Text = book.price.ToString();
            bookImg.Text = book.img;
            this.book = book;
        }

        private void addBookBtn_Clicked(object sender, EventArgs e)
        {

        }

        private void editBookBtn_Clicked(object sender, EventArgs e)
        {
            var item = new Book { bID = book.bID, title = bookTitle.Text, price = Int32.Parse(bookPrice.Text), img = bookImg.Text };

           Database db = new Database();
            if (db.UpdateOnebook(item))
            {
                DisplayAlert("Thông Báo", "Sửa Thông Tin Sách Thành Công", "OK");
                Navigation.PushAsync(new AdminPage());
            }
            else
            {
                DisplayAlert("Thông Báo", "Sửa Thông Tin Sách Thất bại", "OK");
            }
        }
    }
}