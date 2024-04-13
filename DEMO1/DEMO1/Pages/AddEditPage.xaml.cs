using Microsoft.Win32;
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

namespace DEMO1.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddEditPage.xaml
    /// </summary>
    public partial class AddEditPage : Page
    {
        Models.Product product;
        public AddEditPage(Models.Product _product)
        {
            InitializeComponent();
            product = _product;
            DataContext = product;
            TypeCb.ItemsSource = App.db.Type.ToList();
            TypeCb.DisplayMemberPath = "Title";
            ProviderCb.ItemsSource = App.db.Provider.ToList();
            ProviderCb.DisplayMemberPath = "Title";
        }

        private void SaveCL(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(product.Title))
                {
                    MessageBox.Show("Title is empty");
                    return;
                }
                else
                {
                    if (product.Id == 0)
                    {
                        App.db.Product.Add(product);
                    }
                    product.DateEdit = DateTime.Now;
                    App.db.SaveChanges();
                    MessageBox.Show("Save");
                    Classes.UnitTest.UnitTest1();
                    NavigationService.Navigate(new ProductPage());

                }
            }
            catch
            {
                MessageBox.Show("Error");

            }
        }

        private void BackCL(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void AddImageBtn(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.png;*.jpeg;*.jpg)|*.png;*.jpeg;*.jpg|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                string imagePath = openFileDialog.FileName;

                // Извлекаем имя файла из полного пути
                string fileName = System.IO.Path.GetFileName(imagePath);

                // Сохраняем имя файла в базу данных
                product.ImagePath = fileName; // предполагается, что product - это объект, который представляет ваш продукт

                BitmapImage bitmap = new BitmapImage(new Uri(imagePath));
                ImageProd.Source = bitmap;
            }
        }
    }
}
