//////////////////////////////////////////////
/// This class is automatically generated. ///
/// Do not attempt to modify as it will be ///
/// overwritten on the next build attempt. ///
//////////////////////////////////////////////

#region Auto-Generated Code

using System.Collections.Generic;

namespace HF_API.Requests.Read
{
    internal partial class User : RequestRead
    {
        protected override string RequestId => "users";

        protected override Dictionary<string, object> RequestParameters { get; }

        public User(int _uid = 0)
        {
            RequestParameters = new Dictionary<string, object>();
            if (_uid > 0)
            {
                RequestParameters.Add("_uid", _uid);
            }
        }
    }
}

#endregion
