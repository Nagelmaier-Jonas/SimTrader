using Newtonsoft.Json;

namespace Model.ApiData;

public class Company{
    [JsonProperty("ticker")] public string ticker{ get; set; }
    [JsonProperty("assetType")] public string assetType{ get; set; }
    [JsonProperty("countryCode")] public string countryCode{ get; set; }
    [JsonProperty("isActive")] public bool isActive{ get; set; }
    [JsonProperty("name")] public string name{ get; set; }
    [JsonProperty("openFIGI")] public string openFIGI{ get; set; }
    [JsonProperty("permaTicker")] public string permaTicker{ get; set; }
    public override string ToString(){
        return $"ticker: {ticker}, assetType: {assetType}, countryCode: {countryCode}, isActive: {isActive}, name: {name}, openFIGI: {openFIGI}, permaTicker: {permaTicker}";
    }
}