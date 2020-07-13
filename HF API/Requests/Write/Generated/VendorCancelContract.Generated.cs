//////////////////////////////////////////////
/// This class is automatically generated. ///
/// Do not attempt to modify as it will be ///
/// overwritten on the next build attempt. ///
//////////////////////////////////////////////

#region Auto-Generated Code



using System.Collections.Generic;

namespace HF_API.Requests.Write
{
    internal partial class VendorCancelContract : RequestWrite
    {
        protected override string RequestId => "contracts";

        protected override Dictionary<string, object> RequestParameters { get; }

        public VendorCancelContract(int contractId)
        {
            RequestParameters = new Dictionary<string, object>();
            RequestParameters.Add("_action", "vendor_cancel");
            RequestParameters.Add("_cid", contractId);
        }
    }
}

#endregion
