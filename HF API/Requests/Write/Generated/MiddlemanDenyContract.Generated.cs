//////////////////////////////////////////////
/// This class is automatically generated. ///
/// Do not attempt to modify as it will be ///
/// overwritten on the next build attempt. ///
//////////////////////////////////////////////

#region Auto-Generated Code

using System.Collections.Generic;

namespace HF_API.Requests.Write
{
    internal partial class MiddlemanDenyContract : RequestWrite
    {
        protected override string RequestId => "contracts";

        protected override Dictionary<string, object> RequestParameters { get; }

        public MiddlemanDenyContract(int contractId)
        {
            RequestParameters = new Dictionary<string, object>();
            RequestParameters.Add("_action", "middleman_deny");
            RequestParameters.Add("_cid", contractId);
        }
    }
}

#endregion
