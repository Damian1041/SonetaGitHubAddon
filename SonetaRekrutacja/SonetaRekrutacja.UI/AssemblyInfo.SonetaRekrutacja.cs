using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Soneta.Business.Licence;
using Soneta.Business.UI;
using SonetaRekrutacja;

[assembly: FolderView("Git Commits",
    Priority = 10,
    Description = "Rozwiązanie pobierające dane z git ( rekrutacja soneta )",
    BrickColor = FolderViewAttribute.BlueBrick,
    Contexts = new object[] { LicencjeModułu.All },
    ObjectType = typeof(GitCommits),
    ObjectPage = "GitCommits.List.pageform.xml",
    ReadOnlySession = false,
    ConfigSession = false
)]




