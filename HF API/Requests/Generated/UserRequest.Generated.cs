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
    internal partial class UserRequest : APIRequest
    {
        /// <inheritdoc />
        protected override RequestAsk Ask => RequestAsk.Users;

        /// <summary>
        /// Gets the user from the specified user id.
        /// Requires <see cref="APIPermission.USERS" />
        /// <summary>
        /// <param name="client">The client to use to process this request.</param>
        /// <param name="userId">The user id.</param>
        public static UserResult Get(HttpClient client, int userId)
        {
            var request = new UserRequest();
            request.Type = RequestType.Read;
            request.Parameters.Add("_uid", userId);
            request.AddResultParameters();
            return request.ProcessRequest<UserResult>(client);
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
            newParams.Add(AddResultParameter<string>("usertitle", true));
            newParams.Add(AddResultParameter<string>("website", true));
            newParams.Add(AddResultParameter<TimeSpan>("timeonline", true));
            newParams.Add(AddResultParameter<int>("reputation", true));
            newParams.Add(AddResultParameter<int>("referrals", true));
            newParams.Add(AddResultParameter<decimal>("myps", true));
            return newParams.ToDictionary(_ => _.Key, _ => _.Value);
        }

    }
}

#endregion
