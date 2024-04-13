using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DEMO1.Classes
{
    public class UnitTest
    {
        public static void UnitTest1()
        {
            var prod = App.db.Product.FirstOrDefault();
            DateTime editDate = (DateTime)prod.DateEdit;
            if(editDate == DateTime.Now)
            {
                MessageBox.Show("Incorrect data of product");
            }
        }
    }
}
