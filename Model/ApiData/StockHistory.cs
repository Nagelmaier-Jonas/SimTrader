using Newtonsoft.Json;

namespace Model.ApiData;

public class StockHistory{
    [JsonProperty("history")] public List<Stock> Stocks{ get; set; }
}