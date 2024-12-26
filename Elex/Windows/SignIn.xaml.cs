using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Elex.Queries;
using Elex.Instances;

namespace Elex.Windows
{
    /// <summary>
    /// Interaction logic for SignIn.xaml
    /// </summary>
    public partial class SignIn : Window
    {
        private WorkerQueries workerQuery = new WorkerQueries();
        public SignIn()
        {
            InitializeComponent();
        }

        private void showError(string message)
        {
            errorBox.Text = message;
            errorBox.Visibility = Visibility.Visible;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string phone = phoneBox.Text.Trim();
            string password = passwordBox.Password.Trim();
            if(phone == "" || password == "")
            {
                showError("Заполните поля!");
                return;
            }

            try
            {
                Worker worker = workerQuery.auth(phone, password);
                Console.Write(worker.RoleId);
                if(worker.Id == 0)
                {
                    showError("Неверный телефон или пароль!");
                    return;
                }
                if(worker.RoleId == 2)
                {
                    MainWindow main = new MainWindow();
                    main.Show();
                    this.Close();
                }
                else if(worker.RoleId == 1)
                {
                    MainWindow2 main = new MainWindow2();
                    main.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Ошибка аутентификации");
                }
            }
            catch(Exception ex)
            {
                showError("Ошибка!");
                return;
            }
        }
    }
}
