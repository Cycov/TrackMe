using System.Net.Http;

namespace TrackMeApp
{
    class Globals
    {
        public static readonly HttpClient Client = new HttpClient();
        public static int UserId = -1;
    }
}
