
using Soneta.Business.UI;
using SonetaRekrutacja.GitHubInteractivity;
using System.Collections.Generic;
using System.Linq;

namespace SonetaRekrutacja
{
    public partial class GitCommits
    {
        public MessageBoxInformation Download()
        {
            return new MessageBoxInformation("Pobieranie danych z repozytorium", "Czy chcesz pobrać dane z repozytorium git?")
            {
                YesHandler = () => {
                    var commits = DownloadFromGit();
                    GenerateAverageCommitsReport(commits);
                    GenerateDailyCommitsReport(commits);
                    Context.Session.InvokeChanged();
                    return null;
                }
            };
        }

        private IEnumerable<CommitEvent> DownloadFromGit()
        {
            var client = new GitHubClient();
            return client.GetAllCommitEvents();
        }

    }
}
