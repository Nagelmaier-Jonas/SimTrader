using Newtonsoft.Json;

namespace Model.ApiData;

public class Stock{
    
    [JsonProperty("date")] public DateTime date { get; set; }
    [JsonProperty("close")] public double close { get; set; }
    [JsonProperty("high")] public double high { get; set; }
    [JsonProperty("low")] public double low { get; set; }
    [JsonProperty("open")] public double open { get; set; }
    [JsonProperty("volume")] public int volume { get; set; }
    [JsonProperty("adjClose")] public double adjClose { get; set; }
    [JsonProperty("adjOpen")] public double adjOpen { get; set; }
    [JsonProperty("adjHigh")] public double adjHigh { get; set; }
    [JsonProperty("adjLow")] public double adjLow { get; set; }
    [JsonProperty("adjVolume")] public int adjVolume { get; set; }
    [JsonProperty("divCash")] public double divCash { get; set; }
    [JsonProperty("splitFactor")] public double splitFactor { get; set; }

    public override string ToString(){
        return $"adjClose: {adjClose}, adjHigh: {adjHigh}, adjLow: {adjLow}, adjOpen: {adjOpen}, adjVolume: {adjVolume}, close: {close}, date: {date}, divCash: {divCash}, high: {high}, low: {low}, open: {open}, splitFactor: {splitFactor}, volume: {volume}";
    }
}