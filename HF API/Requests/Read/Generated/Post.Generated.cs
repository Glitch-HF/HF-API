//////////////////////////////////////////////
/// This class is automatically generated. ///
/// Do not attempt to modify as it will be ///
/// overwritten on the next build attempt. ///
//////////////////////////////////////////////

#region Auto-Generated Code



using System.Collections.Generic;

namespace HF_API.Requests.Read
{
    internal partial class Post : RequestRead
    {
        protected override string RequestId => "posts";

        protected override Dictionary<string, object> RequestParameters { get; }

        public Post(int _pid = 0, int _tid = 0, int _uid = 0, int _page = 0, int _perpage = 0)
        {
            RequestParameters = new Dictionary<string, object>();
            if (_pid > 0)
            {
                RequestParameters.Add("_pid", _pid);
            }
            if (_tid > 0)
            {
                RequestParameters.Add("_tid", _tid);
            }
            if (_uid > 0)
            {
                RequestParameters.Add("_uid", _uid);
            }
            if (_page > 0)
            {
                RequestParameters.Add("_page", _page);
            }
            if (_perpage > 0)
            {
                RequestParameters.Add("_perpage", _perpage);
            }
        }
    }
}

#endregion