using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BookStore
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }


        private void btn_Register_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RegisterPage());
        }

        private void btn_Login_Clicked(object sender, EventArgs e)
        {
            Database db = new Database();
            List<User> users = db.GetUser();
            foreach (User user in users)
            {
                if(username.Text == user.username && password.Text == user.password)
                {
                    if (user.permission == "Admin")
                    {
                        DisplayAlert("Thông Báo", "Đăng nhập thành công", "OK");
                        Navigation.PushAsync(new AdminPage(user.username));
                        break;
                    }
                    else
                    {
                        DisplayAlert("Thông Báo", "Đăng nhập thành công", "OK");
                        Navigation.PushAsync(new GuestPage(user.username));
                        break;
                    }
                }

            };
        }
    }
}
