using RestSharp;

namespace PicartoWrapperAPI.Helpers
{
    public class PicartoHelper
    {
        public const string picartoApiUrl = "https://api.picarto.tv/v1/";

        public static void AddPaging(IRestRequest request, PagingInfo pagingInfo)
        {
            if (pagingInfo == null) return;
            request.AddParameter("limit", pagingInfo.PageSize);
            request.AddParameter("offset", pagingInfo.Skip);
        }
    }
}
