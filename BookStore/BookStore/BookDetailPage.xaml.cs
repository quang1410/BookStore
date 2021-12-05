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
    public partial class BookDetailPage : ContentPage
    {
        Book book;
        public BookDetailPage(Book book)
        {
            InitializeComponent();
            bookImg.Source = book.img;
            bookTitle.Text = book.title;
            bookPrice.Text = book.price.ToString();
            this.book = book;
        }

        private void delBtn_Clicked(object sender, EventArgs e)
        {
            Database db = new Database();
            if (db.DeleteOnebook(book))
            {
                DisplayAlert("Thông Báo", "Xóa Sách Thành Công", "OK");
                Navigation.PushAsync(new AdminPage());
            }
            else
            {
                DisplayAlert("Thông Báo", "Xóa Sách Thất bại", "OK");
            }
        }

        private void editBtn_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new EditBookPage(book));
        }
    }
}