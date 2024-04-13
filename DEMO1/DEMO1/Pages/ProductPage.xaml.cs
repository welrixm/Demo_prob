using DEMO1.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

namespace DEMO1.Pages
{
    /// <summary>
    /// Логика взаимодействия для ProductPage.xaml
    /// </summary>
    public partial class ProductPage : Page
    {
        public ProductPage()
        {
            InitializeComponent();
            SortCb.Items.Add("All");
            SortCb.Items.Add("A-Z");
            SortCb.Items.Add("Z-A");
            GeneralCount.Text = App.db.Product.Count().ToString();
            Update();
        }
        int numberPage = 1;
        int count = 3;


        public void Update()
        {
            var list = App.db.Product.ToList();


            if (SortCb.SelectedIndex == 1)
            {
                list = list.OrderBy(x => x.Title).ToList();
            }
            if (SortCb.SelectedIndex == 2)
            {
                list = list.OrderByDescending(x => x.Title).ToList();
            }
            IEnumerable<Product> skipList = list;
            skipList = skipList.Skip(numberPage * count).Take(count).ToList();
            ProductLV.ItemsSource = skipList.Take(3);
            FoundCount.Text = skipList.Count().ToString() + "из";

        }

        private void SortCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Update();
        }

        private void EditCL(object sender, RoutedEventArgs e)
        {
            var selProd = (sender as Button).DataContext as Product;
            NavigationService.Navigate(new AddEditPage(selProd));
        }

        private void AddCL(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddEditPage(new Product()));
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Update();
        }

        private void LeftBtnCL(object sender, RoutedEventArgs e)
        {
            numberPage--;
            if (ProductLV.Items.Count < 0)
            {
                numberPage = 0;
            }
            Update();
        }

        private void RightBtnCL(object sender, RoutedEventArgs e)
        {
            numberPage++;
            if (ProductLV.Items.Count < 3)
            {
                numberPage--;
            }
            Update();
        }

        //private void Refresh()
        //{
        //    List<Product> products = App.db.Product.ToList();

        //    if(SortCb.SelectedItem != null)
        //    {
        //        switch((SortCb.SelectedItem as ComboBoxItem).Tag)
        //        {

        //            case "2":
        //                {
        //                    products = products.OrderBy(x => x.Title).ToList();
        //                }
        //                break;
        //        }
        //    }

        //    ProductLV.ItemsSource = products;
        //}
    }
}
