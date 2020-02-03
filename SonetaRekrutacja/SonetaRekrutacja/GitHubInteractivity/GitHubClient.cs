using System;
using System.Collections.Generic;
using System.Net;
using System.IO;
using Newtonsoft.Json.Linq;
using System.Linq;

namespace SonetaRekrutacja.GitHubInteractivity
{
    public class GitHubClient
    {
        private const string _baseUrl = "https://api.github.com/repos/Damian1041/SonetaRekrutacja/";
        private const string _acceptType = "application/vnd.github.v3+json";
        private const string _agentName = "Soneta App";
        private const string _token = "181b9eb7f3c07937fba6107202a1df34b0a488f4";

        private string GetWebResponse(string uri)
        {
            var request = (HttpWebRequest)WebRequest.Create(uri);
            request.Accept = _acceptType;
            request.UserAgent = _agentName;
            request.Headers.Add(HttpRequestHeader.Authorization, string.Concat("token ", _token));

            ///TODO handle possible web request errors ( Not sure how to pass error to Enova UI )
            WebResponse webResponse = request.GetResponse();
            using (Stream webStream = webResponse.GetResponseStream() ?? Stream.Null)
            using (StreamReader responseReader = new StreamReader(webStream))
            {
                return responseReader.ReadToEnd();
            }
        }

        public IEnumerable<CommitEvent> GetAllCommitEvents()
        {
            var branchNames = GetBranchNames();
            var result = new List<CommitEvent>();
            foreach(var branch in branchNames)
            {
                GetCommits(branch, ref result);
            }
            return result;
        }

        private IEnumerable<string> GetBranchNames()
        {
            var jsonArrayResult = JArray.Parse(GetWebResponse(_baseUrl + "branches"));
            var result = new List<string>();
            foreach(JObject jResult in jsonArrayResult)
            {
                result.Add(jResult.GetValue("name").ToString());
            }
            return result;
        }

        private void GetCommits(string parameter, ref List<CommitEvent> output)
        {
            var jsonResult = JObject.Parse(GetWebResponse(_baseUrl + "commits/" + parameter));
            var commitEvent = CommitEvent.FromJson(jsonResult);
            
            if (!output.Select(c => c.Sha).Contains(commitEvent.Sha))
            {
                output.Add(commitEvent);
                var parents = jsonResult.GetValue("parents").ToObject<JArray>();
                if (parents.Count > 0)
                {
                    foreach (JObject parent in parents)
                    {
                        GetCommits(parent.GetValue("sha").ToString(), ref output);
                    }
                }
            }
        }

    }
}
