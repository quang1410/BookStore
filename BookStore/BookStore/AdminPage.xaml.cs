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
    public partial class AdminPage : ContentPage
    {

        public AdminPage()
        {
            InitializeComponent();
            ListViewInit();
        }

        public AdminPage(string name)
        {
            InitializeComponent();
            userName.Text = "Chào " + name + " !" ;
            ListViewInit();
        }

        void ListViewInit()
        {
            Database db = new Database();
            List<Book> books;

            books = db.GetAllBooks();
            avaiBooks.ItemsSource = books;
        }

        private void addBtn_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AddBookPage());
        }

        private void avaiBooks_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Book seletedBook = e.SelectedItem as Book;
            Navigation.PushAsync(new BookDetailPage(seletedBook));
        }
    }
}