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

        public MainWindow()
        {
            List<Domain> domainList = new List<Domain>();
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
    }
}