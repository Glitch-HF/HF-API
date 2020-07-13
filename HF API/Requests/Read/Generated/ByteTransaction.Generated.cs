//////////////////////////////////////////////
/// This class is automatically generated. ///
/// Do not attempt to modify as it will be ///
/// overwritten on the next build attempt. ///
//////////////////////////////////////////////

#region Auto-Generated Code

using System.Collections.Generic;

namespace HF_API.Requests.Read
{
    internal partial class ByteTransaction : RequestRead
    {
        protected override string RequestId => "bytes";

        protected override Dictionary<string, object> RequestParameters { get; }

        public ByteTransaction(int _id = 0, int _uid = 0, int _from = 0, int _to = 0, int _page = 0, int _perpage = 0)
        {
            RequestParameters = new Dictionary<string, object>();
            if (_id > 0)
            {
                RequestParameters.Add("_id", _id);
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
