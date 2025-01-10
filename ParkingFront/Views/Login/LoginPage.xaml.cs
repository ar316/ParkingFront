using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using ParkingFront.Views.Register;


namespace ParkingFront.Views.Login
{
    public sealed partial class LoginPage : Page
    {


        public LoginPage()
        {
            this.InitializeComponent();
        }

        // Lógica para Iniciar Sesión
        private void OnLoginClick(object sender, RoutedEventArgs e)
        {

            string identificacion = IdentificationTextBox.Text;
            string contrasena = PasswordBox.Password;

            if (string.IsNullOrEmpty(identificacion) || string.IsNullOrEmpty(contrasena))
            {
                ContentDialog dialog = new ContentDialog
                {
                    Title = "Error",
                    Content = "Por favor, completa todos los campos.",
                    CloseButtonText = "OK"
                };
                dialog.ShowAsync();
                return;
            }

        }

     
        private void OnRegisterClick(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(RegisterPage));
        }


  
    }
}
