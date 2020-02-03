using Soneta.Business;
using SonetaRekrutacja.GitHubInteractivity;
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

        public IEnumerable<DailyCommitsViewModel> DailyCommits { get; private set; }

        public void GenerateDailyCommitsReport(IEnumerable<CommitEvent> commitEvents)
        {
            DailyCommits = commitEvents.GroupBy(c => new { c.Date, c.Author }).Select(g => new DailyCommitsViewModel()
            {
                Author = g.Key.Author,
                Data = g.Key.Date,
                CommitsCount = g.Count()
            });
        }
    }
}
