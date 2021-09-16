using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Currency.Data
{
    public class Currency
    {
        public string Country
        {
            get;
            set;
        }
        public string Code
        {
            get;
            set;
        }

        public double Rate
        {
            get;
            set;
        }

        public double Amount
        {
            get;
            set;
        }


    }
}
