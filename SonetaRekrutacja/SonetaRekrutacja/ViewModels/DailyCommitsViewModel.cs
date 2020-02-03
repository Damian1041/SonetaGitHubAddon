using Soneta.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SonetaRekrutacja.ViewModels
{
    public class DailyCommitsViewModel
    {
        public Date Data { get; set; }
        public string Author { get; set; }
        public int CommitsCount { get; set; }
    }
}
