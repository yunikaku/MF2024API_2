using MF2024API_2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;

namespace MF2024API_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SlakController : ControllerBase
    {

        private readonly Mf2024api2Context _context;

        public SlakController(Mf2024api2Context context)
        {
            _context = context;
        }

        private const string key = "payload";
        private HttpClient httpClient = new HttpClient();
        //private readonly string _slackApiToken = "xoxb-7023587625620-7073647628962-vAWqhEsQsVvcBRAqDcx4bpfl";
        //グループ送信
        //引数:departmentslakcode,送信内容テキスト


        [HttpPost("Slakpost")]

        public async Task<bool> Slakpost(string GroupSlakId, string text)
        {
            
            var slakAPI = new SlakAPI()
            {
                text = text,
                username = "予約システム"
            };
            var jsonpayload = JsonConvert.SerializeObject(slakAPI);
            var urlpayload = new Dictionary<string, string>
            {
                {key, jsonpayload}
            };
            var urlparameter = new FormUrlEncodedContent(urlpayload);
            var response = await httpClient.PostAsync(GroupSlakId, urlparameter);
            return (response.StatusCode == HttpStatusCode.OK);
        }


        //個人送信
        [HttpPost("SlakpostDM")]

        public async Task<bool> SlakpostDM(string SlakURL, string text)
        {
            
            var slakAPI = new SlakAPI()
            {
                text = text,
                username = "予約システム"
            };
            var jsonpayload = JsonConvert.SerializeObject(slakAPI);
            var urlpayload = new Dictionary<string, string>
            {
                {key, jsonpayload}
            };
            var urlparameter = new FormUrlEncodedContent(urlpayload);
            var response = await httpClient.PostAsync(SlakURL, urlparameter);
            return (response.StatusCode == HttpStatusCode.OK);
        }

    }
}
