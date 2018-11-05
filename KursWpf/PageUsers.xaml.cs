using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace KursWpf
{
    /// <summary>
    /// Логика взаимодействия для Users.xaml
    /// </summary>
    public partial class PageUsers : Page
    {
        private Server _server;
        private ObservableCollection<Account> accounts;

        public PageUsers(Server server)
        {
            InitializeComponent();
            _server = server;
            accounts = new ObservableCollection<Account>(_server.Accounts);
            //AccountList.ItemsSource = accounts;
            AccountList.ItemsSource = _server.Accounts;
            //MessageBox.Show(_server.Status());
        }
    }
}
