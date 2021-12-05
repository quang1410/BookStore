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
    public partial class CartPage : ContentPage
    {
        int total = 0;
        public CartPage()
        {
            InitializeComponent();
            CartInit();
            amount.Text = "Thành tiền: " + total.ToString();
        }

        void CartInit()
        {
            List<Book> books = new List<Book>();
            Database db = new Database();
            List<Cart> carts = db.GetCart();

            foreach(Cart cart in carts)
            {
                var bookId = cart.bId;
                List<Book> temp = db.GetOneBook(bookId);
                if (temp.Count > 0)
                {
                    temp.ElementAt(0).cId = cart.cId;
                    books.Add(temp.ElementAt(0));
                    total += temp.ElementAt(0).price;
                }
                
            };
            lstCart.ItemsSource = books;
        }

        private void lstCart_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Book seletedBook = e.SelectedItem as Book;
            Navigation.PushAsync(new CartDetailPage(seletedBook));
        }
    }
}