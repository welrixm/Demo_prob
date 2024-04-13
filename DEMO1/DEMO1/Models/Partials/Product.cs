using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DEMO1.Pages;
namespace DEMO1.Models
{
    public partial class Product
    {

        public string ImgProd
        {
            get
            {
                return @"/Resources/Products/" + ImagePath;
            }
        }

    }
}
