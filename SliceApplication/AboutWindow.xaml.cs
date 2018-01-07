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
using SliceApplication.Properties;
using System.Deployment;
using System.Reflection;

namespace SliceApplication
{
    /// <summary>
    /// Interaction logic for AboutWindow.xaml
    /// </summary>


         

    public partial class AboutWindow : Window
    {

        string version;

        public string Version
        {
            get { return Version; }
            set { value = version; }
        }

        public AboutWindow()
        {
            
            InitializeComponent();
            Version = "V" + Assembly.GetExecutingAssembly().GetName().Version.ToString();

        }


    }
}
