using Soneta.Business;
using SonetaRekrutacja.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SonetaRekrutacja
{
    public partial class GitCommits
    {
        [Context(Required = true)]
        public Context Context { get; set; }

        [Context(Required = true)]
        public Session Session { get; set; }

        public static bool IsVisible(Context context) => System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable();

    }
}
