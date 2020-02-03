using Newtonsoft.Json.Linq;
using Soneta.Types;
using System;

namespace SonetaRekrutacja.GitHubInteractivity
{
    public class CommitEvent
    {

        public string Sha { get; set; }
        public string Author { get; set; }
        public Date Date { get; set; }

        public static CommitEvent FromJson(JObject jsonObject)
        {
            var result = new CommitEvent();
            result.Sha = jsonObject.GetValue("sha").ToString();
            result.Author = jsonObject.GetValue("author").ToObject<JObject>().GetValue("login").ToString();
            var dateString = jsonObject.GetValue("commit").ToObject<JObject>().GetValue("committer").ToObject<JObject>().GetValue("date").ToString();
            result.Date = new Date(DateTime.Parse(dateString));
            return result;
        }
    }
}
