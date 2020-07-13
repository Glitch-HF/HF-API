//////////////////////////////////////////////
/// This class is automatically generated. ///
/// Do not attempt to modify as it will be ///
/// overwritten on the next build attempt. ///
//////////////////////////////////////////////

#region Auto-Generated Code



using System.Collections.Generic;

namespace HF_API.Requests.Write
{
    internal partial class CompleteContract : RequestWrite
    {
        protected override string RequestId => "contracts";

        protected override Dictionary<string, object> RequestParameters { get; }

        public CompleteContract(int contractId, string txn = null)
        {
            RequestParameters = new Dictionary<string, object>();
            RequestParameters.Add("_action", "complete");
            RequestParameters.Add("_cid", contractId);
            if (!string.IsNullOrEmpty(txn))
            {
                RequestParameters.Add("_txn", txn);
            }
        }
    }
}

#endregion
