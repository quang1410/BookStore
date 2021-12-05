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
    public partial class CartDetailPage : ContentPage
    {
        Book book;
        public CartDetailPage()
        {
            InitializeComponent();
        }

        public CartDetailPage(Book book)
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
            var item = new Cart { cId = book.cId };
            if (db.DeleteItemCart(item))
            {
                DisplayAlert("Thông Báo", "Xóa Sản Phẩm Thành Công", "OK");
                Navigation.PushAsync(new CartPage());
            }
            else
            {
                DisplayAlert("Thông Báo", "Xóa Sản Phẩm Thất bại", "OK");
            }
        }
    }
}