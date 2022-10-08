using Newtonsoft.Json;

namespace Model.ApiData;

public class SearchResult{
    [JsonProperty("result")] public List<Company> Companies{ get; set; }
}