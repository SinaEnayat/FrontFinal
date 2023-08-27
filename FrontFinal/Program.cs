using System;
using System.Diagnostics;
using System.Net;
using System.Net.Http.Json;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.Xml;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

while (true)
{
    Console.WriteLine("1-Display a list of all books\n" +
                      "2-Display information about authors.\n" +
                      "3-Display information about borrowers.\n" +
                      "4-Borrow Book\n" +
                      "5-Return Book\n" +
                      "6-Search functionality for books by title or author's name.\n" +
                      "7-Search functionality for books by genre\n" +
                      "8-Exit Application!\n");

    using (HttpClient httpClient = new HttpClient())
    {
        httpClient.BaseAddress = new Uri("https://localhost:7026/");

        int userOption = Convert.ToInt32(Console.ReadLine());

        if (userOption == 1)
        {
            Console.Clear();
            HttpResponseMessage response = await httpClient.GetAsync("controller/GetAllBooks");

            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                JArray Jarrayobject = JArray.Parse(responseBody);
                string formattedJson = JsonConvert.SerializeObject(Jarrayobject, Newtonsoft.Json.Formatting.Indented);

                // Process the response body
                Console.WriteLine(formattedJson);
            }

            Console.WriteLine("Click any key to continue!");
            System.Console.ReadKey();
            Console.Clear();

        }
        else if (userOption == 2)
        {
            Console.Clear();
            HttpResponseMessage response = await httpClient.GetAsync("controller/getAllAuthors");

            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                JArray Jarrayobject = JArray.Parse(responseBody);
                string formattedJson = JsonConvert.SerializeObject(Jarrayobject, Newtonsoft.Json.Formatting.Indented);

                // Process the response body
                Console.WriteLine(formattedJson);
            }

            Console.WriteLine("Click any key to continue!");
            System.Console.ReadKey();
            Console.Clear();
        }
        else if (userOption == 3)
        {
            Console.Clear();
            HttpResponseMessage response = await httpClient.GetAsync("controller/getAllBorrower");

            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                JArray Jarrayobject = JArray.Parse(responseBody);
                string formattedJson = JsonConvert.SerializeObject(Jarrayobject, Newtonsoft.Json.Formatting.Indented);

                // Process the response body
                Console.WriteLine(formattedJson);
            }

            Console.WriteLine("Click any key to continue!");
            System.Console.ReadKey();
            Console.Clear();
        }
        else if (userOption == 4)
        {
            Console.Clear();

            Console.WriteLine("Enter BookId :");
            string BookId = Console.ReadLine();

            Console.WriteLine("Enter BorrowId :");
            string BorrowId = Console.ReadLine();
            var requestData = new { bookId = BookId, borrowerId = BorrowId };

            var content = new StringContent(JsonConvert.SerializeObject(requestData), Encoding.UTF8, "application/json");

            HttpResponseMessage response = await httpClient.PostAsync("controller/BorrowBook", content);

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Borrowed!");
            }
            else
            {
                Console.WriteLine("Fail!");
            }

            Console.WriteLine("Click any key to continue!");
            System.Console.ReadKey();
            Console.Clear();
        }
        else if (userOption == 5)
        {
            Console.Clear();

            Console.WriteLine("Enter BookId :");
            string BookId = Console.ReadLine();
            var requestData = new { bookId = BookId };

            var content = new StringContent(JsonConvert.SerializeObject(requestData), Encoding.UTF8, "application/json");

            HttpResponseMessage response = await httpClient.PutAsync("controller/ReturnBorrowedBook", content);

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Returned!");
            }
            else
            {
                Console.WriteLine("Fail!");
            }

            Console.WriteLine("Click any key to continue!");
            System.Console.ReadKey();
            Console.Clear();
        }
        else if (userOption == 7)
        {
            Console.Clear();

            Console.WriteLine("Enter Genre :");
            string Genre = Console.ReadLine();

            HttpResponseMessage response = await httpClient.GetAsync("controller/GetByGenre?GenreName=" + Genre);

            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                JArray Jarrayobject = JArray.Parse(responseBody);
                string formattedJson = JsonConvert.SerializeObject(Jarrayobject, Newtonsoft.Json.Formatting.Indented);

                // Process the response body
                Console.WriteLine(formattedJson);
            }
            else
            {
                Console.WriteLine("Fail!");
            }

            Console.WriteLine("Click any key to continue!");
            System.Console.ReadKey();
            Console.Clear();
        }
        else if (userOption == 6)
        {
            Console.Clear();

            Console.WriteLine("Enter author or title :");
            string Title = Console.ReadLine();

            HttpResponseMessage response = await httpClient.GetAsync("controller/GetBookByTitleOrAuthor?Title=" + Title);

            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                JArray Jarrayobject = JArray.Parse(responseBody);
                string formattedJson = JsonConvert.SerializeObject(Jarrayobject, Newtonsoft.Json.Formatting.Indented);

                // Process the response body
                Console.WriteLine(formattedJson);
            }
            else
            {
                Console.WriteLine("Fail!");
            }

            Console.WriteLine("Click any key to continue!");
            System.Console.ReadKey();
            Console.Clear();
        }
        else if (userOption == 8)
        {
            break;
        }
        else
        {
            Console.WriteLine("Somthing Went Wrong!...\n");
        }
    }

}