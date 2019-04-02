using SeafClient.Types;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;

namespace SeafClient.Requests.Files
{
    /// <summary>
    /// Return a download link for the given file
    /// </summary>
    public class CreateShareLinkRequest : SessionRequest<SeafShareLink>
    {
        public string LibraryId { get; set; }

        public string Path { get; set; }
        public string Password { get; set; }
        public int ExpireDays { get; set; }

        public override string CommandUri =>
            $"api/v2.1/share-links/";

        public override HttpAccessMethod HttpAccessMethod => HttpAccessMethod.Post;

        public CreateShareLinkRequest(string authToken, string libraryId, string path, string password = null, int expireDays = 0)
            : base(authToken)
        {
            LibraryId = libraryId;
            Path = path;
            Password = password;
            ExpireDays = expireDays;

            if (!Path.StartsWith("/"))
                Path = "/" + Path;
        }
        public override IEnumerable<KeyValuePair<string, string>> GetBodyParameters()
        {
            foreach (var p in base.GetBodyParameters())
                yield return p;

            yield return new KeyValuePair<string, string>("repo_id", LibraryId);
            yield return new KeyValuePair<string, string>("path", Path);

            if (!string.IsNullOrEmpty(Password))
                yield return new KeyValuePair<string, string>("password", Password);
            if (ExpireDays > 0)
                yield return new KeyValuePair<string, string>("expire_days", ExpireDays.ToString());
        }

        public override SeafError GetSeafError(HttpResponseMessage msg)
        {
            switch (msg.StatusCode)
            {
                case HttpStatusCode.NotFound:
                    return new SeafError(msg.StatusCode, SeafErrorCode.FileNotFound);
                case HttpStatusCode.BadRequest:
                    return new SeafError(msg.StatusCode, SeafErrorCode.PathDoesNotExist);
                default:
                    return base.GetSeafError(msg);
            }
        }
    }
}
