//////////////////////////////////////////////
/// This class is automatically generated. ///
/// Do not attempt to modify as it will be ///
/// overwritten on the next build attempt. ///
//////////////////////////////////////////////

#region Auto-Generated Code

using System.Collections.Generic;

namespace HF_API.Requests.Read
{
    internal partial class Contract : RequestRead
    {
        protected override string RequestId => "contracts";

        protected override Dictionary<string, object> RequestParameters { get; }

        public Contract(int _cid = 0, int _uid = 0, int _page = 0, int _perpage = 0)
        {
            RequestParameters = new Dictionary<string, object>();
            if (_cid > 0)
            {
                RequestParameters.Add("_cid", _cid);
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
