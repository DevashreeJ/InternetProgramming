using ErrorLoggerModel;
using ExecutableProj;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RestLibrary
{
    public static class RestInteractions
    {
       
            private static int SERVICE_PORT = 53180;
            private static string SERVICE_URL = "http://localhost/RestApplication";
             private static string GET_ACTION = "Api/RestApi";

        public static void GetAndPrintAllData()
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(String.Format(SERVICE_URL, SERVICE_PORT));

                HttpResponseMessage response = client.GetAsync(GET_ACTION).Result;
                OperationsOnDatabase odb = new OperationsOnDatabase();

                if (response.IsSuccessStatusCode)
                {
                    IEnumerable<ErrorClass> result = response.Content.ReadAsAsync<IEnumerable<ErrorClass>>().Result;
                    List<ErrorClass> templist = new List<ErrorClass>();
                    Console.WriteLine("   Data:");
                    foreach (ErrorClass value in result)
                    {
                       // Console.WriteLine("     " + value);
                        templist.Add(value);

                    }
                    foreach (var temp in templist)
                    {
                        //Console.WriteLine("templist     " + temp);
                        odb.AddErrorLogsFromRest(temp.Loglevel, temp.ApplicationId, temp.ErrorText);
                    }
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("ERROR: {0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                }
            }

            public static void CreateItem(ErrorClass newItem)
            {
            OperationsOnDatabase odb = new OperationsOnDatabase();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(String.Format(SERVICE_URL, SERVICE_PORT));
            odb.AddErrorLogsFromRest(newItem.Loglevel, newItem.ApplicationId, newItem.ErrorText);
            client.PostAsJsonAsync(GET_ACTION, newItem).Wait();
            }

        }
    }

