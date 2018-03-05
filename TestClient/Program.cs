namespace TestClient
{
    using Data;
    using System;
    using System.Collections.Generic;
    using ExecutableProj;
    using System.Net.Http;

    class Program
    {
        #region Constants for the REST Service

        private static int SERVICE_PORT = 31983;
        private static string SERVICE_URL = "http://localhost:{0}/";

        private static string GENERAL_ACTION = "Api/Values";
        private static string ID_SPECIFIC_ACTION = "Api/Values/{0}";

        #endregion

        /// <summary>
        /// Entry point into the application
        /// </summary>
        /// <param name="args">Not used</param>
        static void Main(string[] args)
        {
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("       Test Client - Demo of a REST (WebApi) service");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine();

            //DifferentReadOptions();

            //SpecificReads();

            //DoCrudOperations();

            GetAndPrintAllData();

            Console.ReadLine();
        }

        private static void DifferentReadOptions()
        {
            Console.WriteLine("############################################################");
            Console.WriteLine("  Test 1: Demonstrates how to read data in different ways");
            Console.WriteLine("############################################################");
            Console.WriteLine();

            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri(String.Format(SERVICE_URL, SERVICE_PORT));
            HttpResponseMessage response = client.GetAsync(GENERAL_ACTION).Result;

            if (response.IsSuccessStatusCode)
            {
                {
                    // read the response as text
                    string result = response.Content.ReadAsStringAsync().Result;

                    Console.WriteLine("Response: " + result);
                }

                {
                    // in order to make this work, this project needs a reference to System.Net.Http.Formatting
                    IEnumerable<MyData> result = response.Content.ReadAsAsync<IEnumerable<MyData>>().Result;

                    Console.WriteLine("Getting a strongly typed response instead.. -> contents:");
                    foreach (MyData aRecord in result)
                    {

                        Console.WriteLine("   " + aRecord);
                    }
                }
            }
            else
            {
                Console.WriteLine("ERROR: {0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }

            Console.WriteLine();
        }

        private static void SpecificReads()
        {
            Console.WriteLine("############################################################");
            Console.WriteLine("     Test 2: Demonstrates how to get specific data");
            Console.WriteLine("############################################################");
            Console.WriteLine();

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(String.Format(SERVICE_URL, SERVICE_PORT));

            int id = 1;

            HttpResponseMessage response = client.GetAsync(string.Format(ID_SPECIFIC_ACTION, id)).Result;

            if (response.IsSuccessStatusCode)
            {
                MyData result = response.Content.ReadAsAsync<MyData>().Result;

                Console.WriteLine("Item with id {0}: {1}", id, result);
            }
            else
            {
                Console.WriteLine("ERROR: {0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }

            id = 3;

            response = client.GetAsync(string.Format(ID_SPECIFIC_ACTION, id)).Result;

            if (response.IsSuccessStatusCode)
            {
                MyData result = response.Content.ReadAsAsync<MyData>().Result;

                Console.WriteLine("Item with id {0}: {1}", id, result);
            }
            else
            {
                Console.WriteLine("ERROR: {0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }

            Console.WriteLine();
        }

        private static void DoCrudOperations()
        {
            Console.WriteLine("############################################################");
            Console.WriteLine("     Test 3: Demonstrates CRUD operations");
            Console.WriteLine("############################################################");
            Console.WriteLine();

            Console.WriteLine("Original State:");
            GetAndPrintAllData();

            Console.WriteLine("Adding a new item..");
            MyData newItem = new MyData(77,2, "This is a new item..");
            CreateItem(newItem);

            GetAndPrintAllData();

            Console.WriteLine("Updating the item..");
            newItem.Text = "This is an updated text";
            UpdateItem(newItem);

            GetAndPrintAllData();

            Console.WriteLine("Deleting the item..");
            DeleteItem(newItem.Id);

            GetAndPrintAllData();
        }

        private static void GetAndPrintAllData()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(String.Format(SERVICE_URL, SERVICE_PORT));

            HttpResponseMessage response = client.GetAsync(GENERAL_ACTION).Result;
            OperationsOnDatabase odb = new OperationsOnDatabase();
            List<MyData> list2 = new List<MyData>();

            if (response.IsSuccessStatusCode)
            {
                // in order to make this work, this project needs a reference to System.Net.Http.Formatting
                IEnumerable<MyData> result = response.Content.ReadAsAsync<IEnumerable<MyData>>().Result;

                Console.WriteLine("   Data:");
                foreach (MyData aRecord in result)
                {
                    //odb.AddErrorLogsFromRest(aRecord.Id, aRecord.AppId,aRecord.Text );
                    list2.Add(aRecord);
                    Console.WriteLine("     " + aRecord);
                }
                foreach (MyData aRecord in list2)
                {
                    odb.AddErrorLogsFromRest(aRecord.Id, aRecord.AppId, aRecord.Text);
                    Console.WriteLine("    " + aRecord);
                }

                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("ERROR: {0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }

        private static void CreateItem(MyData newItem)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(String.Format(SERVICE_URL, SERVICE_PORT));

            client.PostAsJsonAsync(GENERAL_ACTION, newItem).Wait();
        }

        private static void UpdateItem(MyData existingItem)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(String.Format(SERVICE_URL, SERVICE_PORT));

            client.PutAsJsonAsync(string.Format(ID_SPECIFIC_ACTION, existingItem.Id), existingItem).Wait();
        }

        private static void DeleteItem(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(String.Format(SERVICE_URL, SERVICE_PORT));

            client.DeleteAsync(string.Format(ID_SPECIFIC_ACTION, id)).Wait();
        }
    }
}