namespace MF2024API_2.Models
{
    public class SlakAPI
    {
        public string username { get; set; }

        public string text { get; set; } 
    }

    public class SlakAPI_getchannelid
    {
        public string method { get; set; }
        public string payload { get; set; }
        public string ccontentType { get; set; }
    }
    public class SlakAPI_payload 
    {
        public string token { get; set; }
        public string users { get; set; }
    }
}
