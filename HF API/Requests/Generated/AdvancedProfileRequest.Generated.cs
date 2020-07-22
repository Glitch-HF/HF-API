//////////////////////////////////////////////
/// This class is automatically generated. ///
/// Do not attempt to modify as it will be ///
/// overwritten on the next build attempt. ///
//////////////////////////////////////////////

#region Auto-Generated Code

using HF_API.Enums;
using HF_API.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace HF_API.Requests
{
    internal partial class AdvancedProfileRequest : ProfileRequest
    {
        /// <summary>
        /// Reads the advanced profile information from the current token session.
        /// Requires <see cref="APIPermission.ADV" />
        /// <summary>
        /// <param name="client">The client to use to process this request.</param>
        public static new AdvancedProfileResult Read(HttpClient client)
        {
            var request = new AdvancedProfileRequest();
            request.Type = RequestType.Read;
            request.AddResultParameters();
            return request.ProcessRequest<AdvancedProfileResult>(client);
        }

        /// <summary>
        /// Adds the result parameters to the list.
        /// <summary>
        internal override Dictionary<string, object> AddResultParameters()
        {
            var newParams = new List<KeyValuePair<string, object>>();
            newParams.AddRange(base.AddResultParameters());
            newParams.Add(AddResultParameter<DateTime>("lastactive", true));
            newParams.Add(AddResultParameter<int>("unreadpms", true));
            newParams.Add(AddResultParameter<bool>("invisible", true));
            newParams.Add(AddResultParameter<int>("totalpms", true));
            newParams.Add(AddResultParameter<decimal>("warningpoints", true));
            return newParams.ToDictionary(_ => _.Key, _ => _.Value);
        }

    }
}

#endregion
