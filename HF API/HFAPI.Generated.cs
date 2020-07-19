//////////////////////////////////////////////
/// This class is automatically generated. ///
/// Do not attempt to modify as it will be ///
/// overwritten on the next build attempt. ///
//////////////////////////////////////////////

#region Auto-Generated Code

using HF_API.Enums;
using HF_API.Requests;
using HF_API.Results;

namespace HF_API
{
    public partial class HFAPI
    {
        /// <summary>
        /// Reads the basic profile information from the current token session.
        /// Requires <see cref="APIPermission.BASIC" />
        /// <summary>
        public ProfileResult ProfileRead()
        {
            return ProfileRequest.Read(Client);
        }

        /// <summary>
        /// Reads the advanced profile information from the current token session.
        /// Requires <see cref="APIPermission.ADV" />
        /// <summary>
        public AdvancedProfileResult AdvancedProfileRead()
        {
            return AdvancedProfileRequest.Read(Client);
        }

        /// <summary>
        /// Gets the forum from the specified forum id.
        /// Requires <see cref="APIPermission.POSTS" />
        /// <summary>
        /// <param name="forumId">The forum id.</param>
        public ForumResult ForumGet(int forumId)
        {
            return ForumRequest.Get(Client, forumId);
        }

        /// <summary>
        /// Gets the thread from the specified thread id.
        /// Requires <see cref="APIPermission.POSTS" />
        /// <summary>
        /// <param name="threadId">The thread id.</param>
        public ThreadResult ThreadGet(int threadId)
        {
            return ThreadRequest.Get(Client, threadId);
        }

        /// <summary>
        /// Searches all the threads made by the specified user.
        /// Requires <see cref="APIPermission.POSTS" />
        /// <summary>
        /// <param name="userId">The user id.</param>
        /// <param name="page">The page number.</param>
        /// <param name="perPage">The number of results per page.</param>
        public ThreadResult[] ThreadSearchByUserId(int userId, int page, int perPage)
        {
            return ThreadRequest.SearchByUserId(Client, userId, page, perPage);
        }

        /// <summary>
        /// Creates a new thread in the specified forum with the current token user as the author.
        /// Requires <see cref="APIPermission.POSTSWRITE" />
        /// <summary>
        /// <param name="forumId">The forum id.</param>
        /// <param name="subject">The subject of the thread.</param>
        /// <param name="message">The message to post.</param>
        public ThreadResult ThreadCreate(int forumId, string subject, string message)
        {
            return ThreadRequest.Create(Client, forumId, subject, message);
        }

    }
}

#endregion
