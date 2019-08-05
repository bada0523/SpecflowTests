using OpenQA.Selenium.Support.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecflowPages.Utils
{
    class ListenerMainClass
    {
        EventFiringWebDriver eventHandler = new EventFiringWebDriver(Driver.driver);
        EventCapture eCapture = new EventCapture();
    }
}
