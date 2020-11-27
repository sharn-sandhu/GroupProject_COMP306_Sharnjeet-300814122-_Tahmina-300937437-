using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace COMP306_Tahmina_Sharnjeet_Project
{
    class ConsumeApi
    {
        static HttpClient client = new HttpClient();

         static void main(string[] args)
        {
            RunAsync().GetAwaiter().GetResult();
        }

        static async Task RunAsync()
        {
            client.BaseAddress = new Uri("https://tahmmed-eval-test.apigee.net/travelapiproxy");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("apikey", "ionqRPG3OrQJrW2L03EXNGnKiAnX5QMf");
            try
            {

                string json;
                HttpResponseMessage response;

               // client.DefaultRequestHeaders.Add("apikey", "ionqRPG3OrQJrW2L03EXNGnKiAnX5QMf");
                //get all items
                response = await client.GetAsync("/api/TravelPackage");

                if (response.IsSuccessStatusCode)
                {
                    json = await response.Content.ReadAsStringAsync();

                    IEnumerable<Travel> Travels = JsonConvert.DeserializeObject<IEnumerable<Travel>>(json);

                    foreach (Travel item in Travels)
                    {
                        Console.WriteLine(item);
                    }


                }
                else
                    Console.WriteLine("Internal Error");

                // get the specified item

                int id = 4;

                Travel travel;
                response = await client.GetAsync("/api/TravelPackage/");

                if (response.IsSuccessStatusCode)
                {
                    travel = await response.Content.ReadAsAsync<Travel>();

                    Console.WriteLine("The return Travels details:\n" + travel);
                }
                else
                    Console.WriteLine("Internal Server Error");

                // Add a new item

                Travel items = new Travel { id = 5, destination = "India", budget = 4563 };
             
                json = JsonConvert.SerializeObject(items);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                response = await client.PostAsync("api/TravelPackage", content);


                Console.WriteLine($"status from POST {response.StatusCode}");
                response.EnsureSuccessStatusCode();
                Console.WriteLine($"added resource at {response.Headers.Location}");
                json = await response.Content.ReadAsStringAsync();

                Console.WriteLine("The package has been inserted" + json);

                // update the existing item

                Travel tavels = new Travel
                {
                    id = 4,
                    destination = "Vancouver",
                    budget = 7826

                };
                json = JsonConvert.SerializeObject(tavels);
                //StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                response = await client.PutAsync("api/TravelPackage/4", content);

                Console.WriteLine($"status from PUT {response.StatusCode}");
                response.EnsureSuccessStatusCode();

                // delete the specified item
                response = await client.DeleteAsync("api/TravelPackage/4");

                Console.WriteLine($"status from PUT {response.StatusCode}");
                response.EnsureSuccessStatusCode();


            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadLine();
        }
    }
}
