//////////////////////////////////////////////
/// This class is automatically generated. ///
/// Do not attempt to modify as it will be ///
/// overwritten on the next build attempt. ///
//////////////////////////////////////////////

#region Auto-Generated Code

using HF_API.Enums;
using HF_API.Results;
using System;
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
        protected override void AddResultParameters()
        {
            base.AddResultParameters();
            AddResultParameter<DateTime>("lastactive", true);
            AddResultParameter<int>("unreadpms", true);
            AddResultParameter<bool>("invisible", true);
            AddResultParameter<int>("totalpms", true);
            AddResultParameter<decimal>("warningpoints", true);
        }

    }
}

#endregion
