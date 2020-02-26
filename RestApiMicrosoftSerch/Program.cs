using System;
using RestSharp;
using System.Collections.Generic;

namespace RestApiMicrosoftSerch
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Result> error = new List<Result>();
            string searchString = "LINQ";

            var data = GetSearchList();

            foreach (var item in data)
            {
                var search = SearchString(searchString, item);

                if (search == false)
                {
                    error.Add(item);
                }
            }

            if (error.Count > 0)
            {
                foreach (var item in error)
                {
                    string writeString = item.Title + "\n";
                    foreach (var description in item.Descriptions)
                    {
                        writeString = writeString + description.Content + "\n";
                    }

                    Console.WriteLine("\n" + writeString + "\nне найдено " + "'" + searchString + "'" + "\n");
                }
            }
            else
            {
                Console.WriteLine("Ошибок не найдено!");
            }
        }

        private static List<Result> GetSearchList()
        {
            List<Result> result = new List<Result>();
            var client = new RestClient("https://docs.microsoft.com/api/");

            for (int i = 0; i < 50; i += 25)
            {
                var request = new RestRequest("search?search=linq&locale=ru-ru&top=25&skip=" + i, DataFormat.Json);
                var modelData = client.Get<Model>(request).Data;

                result.AddRange(modelData.Results);
            }

            return result;
        }

        public static bool SearchString(string searchString, Result item)
        {
            bool result = false;

            if (item.Title.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0)
            {
                result = true;
            }

            foreach (var description in item.Descriptions)
            {
                if (description.Content.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    result = true;
                }
            }

            return result;
        }
    }
}

