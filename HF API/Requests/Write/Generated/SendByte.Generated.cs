//////////////////////////////////////////////
/// This class is automatically generated. ///
/// Do not attempt to modify as it will be ///
/// overwritten on the next build attempt. ///
//////////////////////////////////////////////

#region Auto-Generated Code

using System.Collections.Generic;
using System;

namespace HF_API.Requests.Write
{
    internal partial class SendByte : RequestWrite
    {
        protected override string RequestId => "bytes";

        protected override Dictionary<string, object> RequestParameters { get; }

        public SendByte(decimal amount)
        {
            RequestParameters = new Dictionary<string, object>();
            RequestParameters.Add("_withdraw", amount.ToString());
            if (amount < 100)
            {
                throw new ArgumentException("_withdraw cannot be less than 100", nameof(amount));
            }
        }
    }
}

#endregion
