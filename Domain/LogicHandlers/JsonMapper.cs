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
    //TODO: Fix Methode
    public StockMeta? MapToStockMeta(string json){
        Console.WriteLine(json);
        StockMeta? stock = JsonSerializer.Deserialize<StockMeta>(json.Substring(1,json.Length - 2));
        return stock;
    }
    //TODO: Fix Methode
    public StockHistory? MapToStockHistory(string json){
        StockHistory history = new StockHistory();
        json = json.Substring(1, json.Length - 2);
        Regex regex = new Regex(@"\{.*?\}");
        MatchCollection matches = regex.Matches(json);
        for (int i = 0; i < matches.Count; i++){
            Stock s = MapToStock(matches[i].ToString());
            history.Stocks.Add(s);
        }
        return history;
    }
}