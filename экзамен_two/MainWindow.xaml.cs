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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace экзамен_two
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Code_Click(object sender, RoutedEventArgs e)
        {
            RandomCode random = new RandomCode();
            random.Show();

        }

        private void cancl_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void inSign_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors =  new StringBuilder();

            using (var db = new testUsersEntities())
            {
                var login = db.Users.AsNoTracking().FirstOrDefault(u => u.login == inputLogin.Text && u.login == inputLogin.Text);
                var pass = db.Users.AsNoTracking().FirstOrDefault(u => u.password == inputPassword.Password);

                if (inputLogin.Text.Length == 0)
                    MessageBox.Show("Вы не ввели логин");

                else
                {
                    if (inputPassword.Password.Length == 0)
                    
                       MessageBox.Show("Вы не ввели пароль");
                    

                    else
                    {
                        if (pass == null)
                        {
                            MessageBox.Show("Не верный пароль");
                        }

                        else
                        {
                            if (pass.isAdmin == true)
                            {
                                string inpCode = inputCode.Text.ToString();
                                string code = RandomCode.RC.ToString();

                                if(inpCode == code)
                                {
                                    Admin ad = new Admin();
                                    ad.Show();
                                    Close();
                                }
                                else
                                {
                                    MessageBox.Show("Неверный код");
                                }
                            }

                            else if (pass.isAdmin == false)
                            {
                                string inputCod = inputCode.Text.ToString();
                                string rancode = RandomCode.RC.ToString();

                                if (rancode == inputCod)
                                {
                                    NonAdmin no = new NonAdmin();
                                    no.Show();
                                    Close();
                                }
                                else
                                {
                                    MessageBox.Show("Неверный код");
                                }
                            }
                             
                            

                            
                        }
                    }
                }

            }
        }
    }
}
