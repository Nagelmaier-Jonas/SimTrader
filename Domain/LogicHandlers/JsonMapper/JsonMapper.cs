using System.Text.Json;
using System.Text.RegularExpressions;
using Model;
using Model.ApiData;

namespace Domain.LogicHandlers;

public sealed class JsonMapper{
    private JsonMapper(){}

    private static JsonMapper _instance;
    
    public static JsonMapper GetInstance(){
        if (_instance == null){
            _instance = new JsonMapper();
        }
        return _instance;
    }

    public Stock? MapToStock(string json){
        Stock? stock = JsonSerializer.Deserialize<Stock>(json.Substring(1,json.Length - 2));
        return stock;
    }
    public StockMeta? MapToStockMeta(string json){
        StockMeta? stockMeta = JsonSerializer.Deserialize<StockMeta>(json);
        return stockMeta;
    }
    public StockHistory? MapToStockHistory(string json){
        json = json.Substring(1,json.Length - 2);
        json = json.Substring(1,json.Length - 2);
        string[] jsonSplit = Regex.Split(json, "},{");
        for (int i = 0; i < jsonSplit.Length; i++){
            jsonSplit[i] = "{" + jsonSplit[i] + "}";
        }
        List<Stock> stocks = new List<Stock>();
        foreach (string s in jsonSplit){
            stocks.Add(JsonSerializer.Deserialize<Stock>(s));
        }
        StockHistory stockHistory = new StockHistory{
            Stocks = stocks
        };
        return stockHistory;
    }
}