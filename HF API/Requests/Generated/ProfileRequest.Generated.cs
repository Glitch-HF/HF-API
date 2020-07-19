//////////////////////////////////////////////
/// This class is automatically generated. ///
/// Do not attempt to modify as it will be ///
/// overwritten on the next build attempt. ///
//////////////////////////////////////////////

#region Auto-Generated Code

using HF_API.Enums;
using HF_API.Results;
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
        public virtual void AddResultParameters()
        {
            Parameters.Add("uid", true);
            Parameters.Add("username", true);
            Parameters.Add("postnum", true);
            Parameters.Add("avatar", true);
            Parameters.Add("avatardimensions", true);
            Parameters.Add("avatartype", true);
            Parameters.Add("usergroup", true);
            Parameters.Add("displaygroup", true);
            Parameters.Add("additionalgroups", true);
            Parameters.Add("awards", true);
            Parameters.Add("threadnum", true);
            Parameters.Add("lastvisit", true);
            Parameters.Add("usertitle", true);
            Parameters.Add("website", true);
            Parameters.Add("timeonline", true);
            Parameters.Add("reputation", true);
            Parameters.Add("referrals", true);
            Parameters.Add("bytes", true);
            Parameters.Add("vault", true);
        }

    }
}

#endregion
