//////////////////////////////////////////////
/// This class is automatically generated. ///
/// Do not attempt to modify as it will be ///
/// overwritten on the next build attempt. ///
//////////////////////////////////////////////

#region Auto-Generated Code

using System.Collections.Generic;

namespace HF_API.Requests.Write
{
    internal partial class CreateThread : RequestWrite
    {
        protected override string RequestId => "threads";

        protected override Dictionary<string, object> RequestParameters { get; }

        public CreateThread(int forumId, string subject, string message)
        {
            RequestParameters = new Dictionary<string, object>();
            RequestParameters.Add("_fid", forumId);
            RequestParameters.Add("_subject", subject);
            RequestParameters.Add("_message", message);
        }
    }
}

#endregion
