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
        public IEnumerable<AverageCommitsViewModel> AverageCommits { get; private set; }

        public void GenerateAverageCommitsReport(IEnumerable<CommitEvent> commitEvents)
        {
            AverageCommits = commitEvents.GroupBy(c => c.Author).Select(cc => new AverageCommitsViewModel()
            {
                Author = cc.Key,
                AverageCommits = cc.GroupBy(ccc => ccc.Date).Select(g => g.Count()).Average()
            });
        }

    }
}
