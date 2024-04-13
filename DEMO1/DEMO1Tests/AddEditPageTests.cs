using Microsoft.VisualStudio.TestTools.UnitTesting;
using DEMO1.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEMO1.Pages.Tests
{
    [TestClass()]
    public class AddEditPageTests
    {
        [TestMethod()]
        public void AddEditPageTest()
        {

            var prod = App.db.Product.FirstOrDefault(x => x.Title == "Собака1");
            prod.DateEdit = DateTime.Now;
            App.db.SaveChanges();



            Assert.IsTrue(prod.DateEdit != null);
        }
    }
}