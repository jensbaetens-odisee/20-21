using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quotes
{
    public interface ICoordinator
    {
        void ShowMainWindow();
        void ShowDialog(string message);
        void ShowQuoteWindow();
    }
}
