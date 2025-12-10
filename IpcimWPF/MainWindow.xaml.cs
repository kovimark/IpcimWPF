using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace IpcimWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    
    public partial class MainWindow : Window
    {
        public class Domain
        {
            public string domainName { get; set; }
            public string ipAddress { get; set; }

            public Domain(string domainName, string ipAddress)
            {
                this.domainName = domainName;
                this.ipAddress = ipAddress;
            }
        }

        List<Domain> domainList = new List<Domain>();

        public MainWindow()
        {
            
            InitializeComponent();
            var adat = File.ReadAllLines("csudh.txt").Skip(1);

            foreach (var a in adat)
            {
                string[] darabok = a.Split(";");
                string domainName = darabok[0];
                string ipAddress = darabok[1];
                domainList.Add(new Domain(domainName, ipAddress));
            }
            dataGrid.ItemsSource = domainList;
        }

        private void bevitel(object sender, RoutedEventArgs e)
        {
            if (domainName.Text.Length > 0 && ipAddress.Text.Length > 0)
            {
                Domain newDomain = new Domain(domainName.Text, ipAddress.Text);
                domainList.Add(newDomain);
                dataGrid.Items.Refresh();
                domainName.Text = "";
                ipAddress.Text = "";
            }
            else
            {
                MessageBox.Show("A mezők kitöltése kötelező!", "Hiba", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}