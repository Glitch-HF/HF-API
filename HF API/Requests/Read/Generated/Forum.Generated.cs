//////////////////////////////////////////////
/// This class is automatically generated. ///
/// Do not attempt to modify as it will be ///
/// overwritten on the next build attempt. ///
//////////////////////////////////////////////

#region Auto-Generated Code

using System.Collections.Generic;

namespace HF_API.Requests.Read
{
    internal partial class Forum : RequestRead
    {
        protected override string RequestId => "forums";

        protected override Dictionary<string, object> RequestParameters { get; }

        public Forum(int _fid = 0)
        {
            RequestParameters = new Dictionary<string, object>();
            if (_fid > 0)
            {
                RequestParameters.Add("_fid", _fid);
            }
        }
    }
}

#endregion
