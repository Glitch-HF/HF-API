//////////////////////////////////////////////
/// This class is automatically generated. ///
/// Do not attempt to modify as it will be ///
/// overwritten on the next build attempt. ///
//////////////////////////////////////////////

#region Auto-Generated Code

using HF_API.Requests.Enums;
using System.Collections.Generic;

namespace HF_API.Requests.Write
{
    internal partial class CreateContract : RequestWrite
    {
        protected override string RequestId => "contracts";

        protected override Dictionary<string, object> RequestParameters { get; }

        public CreateContract(int userId, ContractPosition position, string terms, string yourProduct = null, ContractCurrency yourCurrency = default, string yourAmount = null, string theirProduct = null, ContractCurrency theirCurrency = default, string theirAmount = null, int threadId = 0, int middlemanId = 0, int timeoutDays = 0, ContractPublicState isPublic = default, string paymentAddress = null)
        {
            RequestParameters = new Dictionary<string, object>();
            RequestParameters.Add("_action", "new");
            RequestParameters.Add("_uid", userId);
            RequestParameters.Add("_position", position.ToString());
            RequestParameters.Add("_terms", terms);
            if (!string.IsNullOrEmpty(yourProduct))
            {
                RequestParameters.Add("_yourproduct", yourProduct);
            }
            if (yourCurrency != default)
            {
                RequestParameters.Add("_yourcurrency", yourCurrency.ToString());
            }
            if (!string.IsNullOrEmpty(yourAmount))
            {
                RequestParameters.Add("_youramount", yourAmount);
            }
            if (!string.IsNullOrEmpty(theirProduct))
            {
                RequestParameters.Add("_theirproduct", theirProduct);
            }
            if (theirCurrency != default)
            {
                RequestParameters.Add("_theircurrency", theirCurrency.ToString());
            }
            if (!string.IsNullOrEmpty(theirAmount))
            {
                RequestParameters.Add("_theiramount", theirAmount);
            }
            if (threadId > 0)
            {
                RequestParameters.Add("_tid", threadId);
            }
            if (middlemanId > 0)
            {
                RequestParameters.Add("_muid", middlemanId);
            }
            if (timeoutDays > 0)
            {
                RequestParameters.Add("_timeout", timeoutDays);
            }
            if (isPublic != default)
            {
                RequestParameters.Add("_public", isPublic.ToString());
            }
            if (!string.IsNullOrEmpty(paymentAddress))
            {
                RequestParameters.Add("_address", paymentAddress);
            }
        }
    }
}

#endregion
