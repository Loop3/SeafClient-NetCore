using Newtonsoft.Json;
using System;

namespace SeafClient.Types
{
    public class SeafShareLink
    {
        public string Username { get; set; }

        [JsonProperty("view_cnt")]
        public int ViewCnt { get; set; }
        public DateTime Ctime { get; set; }
        public string Token { get; set; }

        [JsonProperty("repo_id")]
        public string RepoId { get; set; }
        public string Link { get; set; }

        [JsonProperty("expire_date")]
        public object ExpireDate { get; set; }
        public string Path { get; set; }

        [JsonProperty("is_expired")]
        public bool IsExpired { get; set; }
    }
}
