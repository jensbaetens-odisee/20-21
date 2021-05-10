using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    interface IPayable
    {
        void OpenPaymentScreen();
        bool PaymentSucceeded { get; }
        string PaymentSucceededMessage { get; }
        string PaymentFailedMessage { get; }
    }
}
