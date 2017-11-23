using RestSharp;

namespace PicartoWrapperAPI.Helpers
{
    public class PicartoHelper
    {
        public const string BaseURL = "v1";
        public const string picartoApiUrl = "https://api.picarto.tv/"+ BaseURL +"/";
        public const string APIversion = "1.2.3";
        public static void AddPaging(IRestRequest request, PagingInfo pagingInfo)
        {
            if (pagingInfo == null) return;
            request.AddParameter("limit", pagingInfo.PageSize);
            request.AddParameter("offset", pagingInfo.Skip);
        }
    }
}
