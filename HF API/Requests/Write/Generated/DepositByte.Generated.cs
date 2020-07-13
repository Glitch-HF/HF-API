//////////////////////////////////////////////
/// This class is automatically generated. ///
/// Do not attempt to modify as it will be ///
/// overwritten on the next build attempt. ///
//////////////////////////////////////////////

#region Auto-Generated Code


using System;
using System.Collections.Generic;

namespace HF_API.Requests.Write
{
    internal partial class DepositByte : RequestWrite
    {
        protected override string RequestId => "bytes";

        protected override Dictionary<string, object> RequestParameters { get; }

        public DepositByte(decimal amount)
        {
            RequestParameters = new Dictionary<string, object>();
            RequestParameters.Add("_deposit", amount.ToString());
            if (amount < 100)
            {
                throw new ArgumentException("_deposit cannot be less than 100", nameof(amount));
            }
        }
    }
}

#endregion
