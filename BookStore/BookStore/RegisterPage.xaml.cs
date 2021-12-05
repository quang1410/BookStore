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
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();
            PickerInit();
        }

        void PickerInit()
        {
            string[] users = new string[]
            {
                "Admin",
                "Guest"
            };
            pickUser.ItemsSource = users;
        }

        private void btn_Register_Clicked(object sender, EventArgs e)
        {
            Database db = new Database();
            User newUser = new User();
            newUser.username = username.Text;
            newUser.password = password.Text;
            newUser.permission = pickUser.SelectedItem.ToString();

            if (db.AddUser(newUser))
            {
                DisplayAlert("Thông Báo", "Đăng kí thàng công. Vui lòng đăng nhập", "OK");
                Navigation.PushAsync(new MainPage());
            }
            else
            {
                DisplayAlert("Thông Báo", "Đăng kí thất bại", "OK");
            }
        }
    }
}