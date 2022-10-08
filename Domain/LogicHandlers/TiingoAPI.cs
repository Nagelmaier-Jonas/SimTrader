using System.Net.Http.Headers;
using Model.ApiData;

namespace Domain.LogicHandlers;

public sealed class TiingoAPI{
    private TiingoAPI(){
    }

    private static TiingoAPI _instance;

    private static HttpClient _client = new (){
        DefaultRequestHeaders ={Accept ={new MediaTypeWithQualityHeaderValue("application/json")}}
    };
    
    private const string _token = "b5bbfb49331a2b27ffe3919b6456efceda0cf361";

    public static TiingoAPI GetInstance(){
        if (_instance == null){
            _instance = new TiingoAPI();
        }
        return _instance;
    }
    public string GetLatestStockData(string symbol){
        var url = $"https://api.tiingo.com/tiingo/daily/{symbol}/prices?token={_token}";
        var response = _client.GetAsync(url).Result;
        var json = response.Content.ReadAsStringAsync().Result;
        return json;
    }
    
    public string GetMetaStockData(string symbol){
        var url = $"https://api.tiingo.com/tiingo/daily/{symbol}?token={_token}";
        var response = _client.GetAsync(url).Result;
        var json = response.Content.ReadAsStringAsync().Result;
        return json;
    }
    
    public string GetStockHistoryData(string symbol, DateTime startTime, DateTime endTime){
        var url = $"https://api.tiingo.com/tiingo/daily/{symbol}/prices?startDate={startTime.Date.ToString("yyyy-MM-dd")}&endDate={endTime.Date.ToString("yyyy-MM-dd")}&token={_token}";
        var response = _client.GetAsync(url).Result;
        var json = response.Content.ReadAsStringAsync().Result;
        return json;
    }
    
}