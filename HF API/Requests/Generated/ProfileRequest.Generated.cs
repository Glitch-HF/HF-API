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
using System.Drawing;
using System.Linq;
using System.Net.Http;

namespace HF_API.Requests
{
    internal partial class ProfileRequest : APIRequest
    {
        /// <inheritdoc />
        protected override RequestAsk Ask => RequestAsk.Me;

        /// <summary>
        /// Reads the basic profile information from the current token session.
        /// Requires <see cref="APIPermission.BASIC" />
        /// <summary>
        /// <param name="client">The client to use to process this request.</param>
        public static ProfileResult Read(HttpClient client)
        {
            var request = new ProfileRequest();
            request.Type = RequestType.Read;
            request.AddResultParameters();
            return request.ProcessRequest<ProfileResult>(client);
        }

        /// <summary>
        /// Adds the result parameters to the list.
        /// <summary>
        internal override Dictionary<string, object> AddResultParameters()
        {
            var newParams = new List<KeyValuePair<string, object>>();
            newParams.Add(AddResultParameter<int>("uid", true));
            newParams.Add(AddResultParameter<string>("username", true));
            newParams.Add(AddResultParameter<int>("postnum", true));
            newParams.Add(AddResultParameter<string>("avatar", true));
            newParams.Add(AddResultParameter<Size>("avatardimensions", true));
            newParams.Add(AddResultParameter<string>("avatartype", true));
            newParams.Add(AddResultParameter<int>("usergroup", true));
            newParams.Add(AddResultParameter<int>("displaygroup", true));
            newParams.Add(AddResultParameter<int[]>("additionalgroups", true));
            newParams.Add(AddResultParameter<int>("awards", true));
            newParams.Add(AddResultParameter<int>("threadnum", true));
            newParams.Add(AddResultParameter<DateTime>("lastvisit", true));
            newParams.Add(AddResultParameter<string>("usertitle", true));
            newParams.Add(AddResultParameter<string>("website", true));
            newParams.Add(AddResultParameter<TimeSpan>("timeonline", true));
            newParams.Add(AddResultParameter<int>("reputation", true));
            newParams.Add(AddResultParameter<int>("referrals", true));
            newParams.Add(AddResultParameter<decimal>("bytes", true));
            newParams.Add(AddResultParameter<decimal>("vault", true));
            return newParams.ToDictionary(_ => _.Key, _ => _.Value);
        }

    }
}

#endregion
