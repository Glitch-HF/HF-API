//////////////////////////////////////////////
/// This class is automatically generated. ///
/// Do not attempt to modify as it will be ///
/// overwritten on the next build attempt. ///
//////////////////////////////////////////////

#region Auto-Generated Code



using System.Collections.Generic;

namespace HF_API.Requests.Write
{
    internal partial class CreatePost : RequestWrite
    {
        protected override string RequestId => "posts";

        protected override Dictionary<string, object> RequestParameters { get; }

        public CreatePost(int threadId, string message)
        {
            RequestParameters = new Dictionary<string, object>();
            RequestParameters.Add("_tid", threadId);
            RequestParameters.Add("_message", message);
        }
    }
}

#endregion
