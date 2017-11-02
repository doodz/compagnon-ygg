using ModernHttpClient;
using System.Net.Http;
using System.Threading.Tasks;

namespace CompagnonYgg.Core.Services
{
    public class YggClient
    {

        private const string YggUrl = "https://yggtorrent.com/";

        private HttpClient _httpClient;

        public YggClient()
        {
            _httpClient = new HttpClient(new NativeMessageHandler());



        }

        public async Task<string> Home()
        {

            return await _httpClient.GetStringAsync(YggUrl);

        }
    }
}
