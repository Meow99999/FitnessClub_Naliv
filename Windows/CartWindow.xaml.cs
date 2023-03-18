using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
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

using _3ISP919_Naliv_LoginReg.DB;
using _3ISP919_Naliv_LoginReg.Windows;

namespace _3ISP919_Naliv_LoginReg
{
    public partial class CartWindow : Window
    {
        public CartWindow()
        {
            InitializeComponent();

            lvCartService.ItemsSource = ClassHelper.Cart.serviceCart.ToList();
        }

        private void BtnDeleteroduct_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button == null)
            {
                return;
            }

            var service = button.DataContext as DB.Service;
            ClassHelper.Cart.serviceCart.Remove(service);

            lvCartService.ItemsSource = ClassHelper.Cart.serviceCart.ToList();
        }
    }
}