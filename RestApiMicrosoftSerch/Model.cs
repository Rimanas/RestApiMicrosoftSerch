using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace RestApiMicrosoftSerch
{
    public class Model
    {
        [JsonProperty("results")]
        public List<Result> Results { get; set; }
    }

    public class Result
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("descriptions")]
        public List<Description> Descriptions { get; set; }
    }

    public class Description
    {
        [JsonProperty("content")]
        public string Content { get; set; }

    }
}