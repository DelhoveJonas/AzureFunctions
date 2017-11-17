using System.Linq;
using System.Net;
using System.Net.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;

namespace NMCT.Cloud1.MyFirstServices
{
    public static class HelloFunctions
    {
        [FunctionName("HelloFunctions")]
        public static HttpResponseMessage Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = "HttpTriggerCSharp/name/{name}")]HttpRequestMessage req, string name, TraceWriter log)
        {
            log.Info("C# HTTP trigger function processed a request.");

            // Fetching the name from the path parameter in the request URL
            return req.CreateResponse(HttpStatusCode.OK, "Hello " + name);
        }
        [FunctionName("SamenTellen2")]
        public static HttpResponseMessage SamenTellen2([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "HttpTriggerCSharp/rekenmachine/som/{getal1}/{getal2}")]HttpRequestMessage req, int getal1, int getal2, TraceWriter log)
        {
            log.Info("C# HTTP trigger function processed a request.");

            string nieuweWaarde = "" + (getal1 + getal2);
            // Fetching the name from the path parameter in the request URL
            return req.CreateResponse(HttpStatusCode.OK, "De optelling is als volgt " + nieuweWaarde);
        }
        [FunctionName("DelenDoor")]
        public static HttpResponseMessage DelenDoor([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "HttpTriggerCSharp/rekenmachine/delen/{eerste}/{tweede}")]HttpRequestMessage req, int eerste, int tweede, TraceWriter log)
        {
            log.Info("C# HTTP trigger function processed a request.");

            if (tweede == 0)
            {
                return req.CreateResponse(HttpStatusCode.NotAcceptable, "Delen door 0 mag niet! ");

            }
            else
            {
                string nieuweWaardes = "" + (eerste / tweede);
                // Fetching the name from the path parameter in the request URL
                return req.CreateResponse(HttpStatusCode.OK, "De deling is als volgt " + nieuweWaardes);

            }

        }
        [FunctionName("History")]
        public static HttpResponseMessage History([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "history")]HttpRequestMessage req, TraceWriter log)
        {
            log.Info("C# HTTP trigger function processed a request.");

            string from = string.Empty;
            string to = string.Empty;

            foreach(var param in req.GetQueryNameValuePairs())
            {
                if (param.Key.Equals("from"))
                {
                    from = param.Value;
                }
                if (param.Key.Equals("to"))
                {
                    to = param.Value;
                }
            }
            string value = $"From {from} To {to}";
            return req.CreateResponse(HttpStatusCode.OK, value);

        }

    }
}
