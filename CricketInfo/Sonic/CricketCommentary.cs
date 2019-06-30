using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace Cricbuzz
{
    public class CricketCommentary
    {
        public static List<Commentary> GetCommentary(string mid)
        {
            var v = GetCommentry(mid);
            var commLine = v["comm_lines"] as ArrayList;
            List<Commentary> commList = new List<Commentary>();

            foreach(Dictionary<string,object> c in commLine)
            {
                try
                {
                    string cline = c["comm"].ToString();
                    string tStamp = c["timestamp"].ToString();
                    commList.Add(new Commentary(tStamp,cline));
                }
                catch
                {
                    //todo
                }
            }
            return commList;
        }
        private static Dictionary<string,object> GetCommentry(string mid)
        {
            string url = "http://mapps.cricbuzz.com/cbzios/match/" + mid + "/commentary";

            WebRequest request = WebRequest.Create(url);
            using(var res=request.GetResponse())
            {
                string result = new StreamReader(res.GetResponseStream()).ReadToEnd();
                JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
                var pData=javaScriptSerializer.Deserialize<Dictionary<string, object>>(result);
                return pData;
            }
        }

        public class Commentary
        {
            public string Timestamp { get; }
            public string CommentaryLines { get; }

            public Commentary(string ts,string comm)
            {
                Timestamp = ts;
                CommentaryLines = comm;
            }

        }
    }
}
