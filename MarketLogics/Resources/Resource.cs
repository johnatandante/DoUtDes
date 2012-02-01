using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.IO;

namespace MarketLogics.Resources
{
    public class Resource
    {

        public Resource() { }

        public decimal Id = 0M;
        public DateTimeOffset DateCreation;
        public string FilePath;

    }
}
