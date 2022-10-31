using Newtonsoft.Json.Linq;
using System.Net;

namespace HoleCounterV1
{
    public class Counter
    {
        public int Count(string input)
        {
            int count = 0;
            string table;

            if (!File.Exists("table.json"))
            {
                DownloadTable();
            }

            using (var stream = new StreamReader("table.json"))
            {
                table = stream.ReadToEnd();
            }

            var json = JObject.Parse("{ \"Data\":" + table + "}");

            var tableObj = json["Data"];

            for (int i = 0; i < input.Length; i++)
            {
                count += (int)tableObj[input[i].ToString()];
            }

            return count;
        }

        private void DownloadTable()
        {
            var web = new WebClient();
            web.DownloadFile("https://raw.githubusercontent.com/MrOkun/HoleCounter/main/HoleCounterV1/table.json", "table.json");
        }
    }
}