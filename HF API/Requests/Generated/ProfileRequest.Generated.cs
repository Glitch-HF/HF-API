//////////////////////////////////////////////
/// This class is automatically generated. ///
/// Do not attempt to modify as it will be ///
/// overwritten on the next build attempt. ///
//////////////////////////////////////////////

#region Auto-Generated Code

using HF_API.Enums;
using HF_API.Results;
using System;
using System.Drawing;
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
        protected override void AddResultParameters()
        {
            AddResultParameter<int>("uid", true);
            AddResultParameter<string>("username", true);
            AddResultParameter<int>("postnum", true);
            AddResultParameter<string>("avatar", true);
            AddResultParameter<Size>("avatardimensions", true);
            AddResultParameter<string>("avatartype", true);
            AddResultParameter<int>("usergroup", true);
            AddResultParameter<int>("displaygroup", true);
            AddResultParameter<int[]>("additionalgroups", true);
            AddResultParameter<int>("awards", true);
            AddResultParameter<int>("threadnum", true);
            AddResultParameter<DateTime>("lastvisit", true);
            AddResultParameter<string>("usertitle", true);
            AddResultParameter<string>("website", true);
            AddResultParameter<TimeSpan>("timeonline", true);
            AddResultParameter<int>("reputation", true);
            AddResultParameter<int>("referrals", true);
            AddResultParameter<decimal>("bytes", true);
            AddResultParameter<decimal>("vault", true);
        }

    }
}

#endregion
