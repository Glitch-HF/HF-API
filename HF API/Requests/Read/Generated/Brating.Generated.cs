//////////////////////////////////////////////
/// This class is automatically generated. ///
/// Do not attempt to modify as it will be ///
/// overwritten on the next build attempt. ///
//////////////////////////////////////////////

#region Auto-Generated Code

using System.Collections.Generic;

namespace HF_API.Requests.Read
{
    internal partial class Brating : RequestRead
    {
        protected override string RequestId => "bratings";

        protected override Dictionary<string, object> RequestParameters { get; }

        public Brating(int _crid = 0, int _cid = 0, int _uid = 0, int _from = 0, int _to = 0, int _page = 0, int _perpage = 0)
        {
            RequestParameters = new Dictionary<string, object>();
            if (_crid > 0)
            {
                RequestParameters.Add("_crid", _crid);
            }
            if (_cid > 0)
            {
                RequestParameters.Add("_cid", _cid);
            }
            if (_uid > 0)
            {
                RequestParameters.Add("_uid", _uid);
            }
            if (_from > 0)
            {
                RequestParameters.Add("_from", _from);
            }
            if (_to > 0)
            {
                RequestParameters.Add("_to", _to);
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
