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
    public partial class GuestPage : ContentPage
    {
        public GuestPage()
        {
            InitializeComponent();
            ListViewInit();
        }

        public GuestPage(string name)
        {
            InitializeComponent();
            userName.Text = "Chào " + name + " !" ;
            ListViewInit();
        }


        void ListViewInit()
        {
            Database db = new Database();
            List<Book> books = db.GetAllBooks();
            avaiBooks.ItemsSource = books;
        }

        private void cartBtn_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CartPage());
        }

        private void avaiBooks_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Book selectedBook = (Book)avaiBooks.SelectedItem;
            Navigation.PushAsync(new AddToCartPage(selectedBook));
        }
    }
}