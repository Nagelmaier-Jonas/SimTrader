using Newtonsoft.Json;

namespace Model.ApiData;

public class StockMeta{
    [JsonProperty("ticker")] public string ticker { get; set; }
    [JsonProperty("name")] public string name { get; set; }
    [JsonProperty("description")] public string description { get; set; }
    [JsonProperty("startDate")] public DateTime startDate { get; set; }
    [JsonProperty("endDate")] public DateTime endDate { get; set; }
    [JsonProperty("exchangeCode")] public string exchangeCode { get; set; }

    public override string ToString(){
        return $"ticker: {ticker}, name: {name}, exchangeCode: {exchangeCode}, startDate: {startDate}, endDate: {endDate}, description: {description}";
    }
}