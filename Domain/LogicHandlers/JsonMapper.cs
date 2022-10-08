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
    
    /// <summary>
        /// Get JSON data from API.
        /// </summary>
        /// <typeparam name="TResult">Type of result wanted.</typeparam>
        /// <typeparam name="TItem">Type of item getting.</typeparam>
        /// <param name="requestPath">Requested path to use.</param>
        /// <returns>The results.</returns>
        private async Task<TResult> GetJsonAsync<TResult, TItem>(string requestPath)
            where TResult : TiingoResponse, new()
            where TItem : class
        {
            return await this.GetResponseAsync<TResult>(requestPath, responseStream =>
            {
                using MemoryStream stream = new MemoryStream();
                using StreamReader textStream = new StreamReader(stream, System.Text.Encoding.ASCII);
                responseStream.CopyTo(stream);
                stream.Position = 0;
                string jsonText = textStream.ReadToEnd();
                stream.Position = 0;

                // Convert stream to an object.
                try
                {
                    if (typeof(TResult) == typeof(TiingoList<TItem>))
                    {
                        // Get an array.
                        DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(TItem[]));
                        TItem[] serializedObj = (TItem[])serializer.ReadObject(stream);

                        TiingoList<TItem> result = new TiingoList<TItem>
                        {
                            ApiErrorMessage = null,
                            ApiRawJson = jsonText,
                            ApiSuccessful = true,
                            Items = serializedObj,
                        };

                        return result as TResult;
                    }
                    else
                    {
                        // Get an Item.
                        DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(TResult));
                        TResult serializedObj = (TResult)serializer.ReadObject(stream);

                        serializedObj.ApiErrorMessage = null;
                        serializedObj.ApiRawJson = jsonText;
                        serializedObj.ApiSuccessful = true;
                        return serializedObj;
                    }
                }
                catch (Exception e)
                {
                    return new TResult
                    {
                        ApiErrorMessage = e.Message,
                        ApiRawJson = jsonText,
                        ApiSuccessful = false,
                    };
                }
            });
        }
}