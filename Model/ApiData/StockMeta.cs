namespace Model.ApiData;

public class StockMeta{
    public string ticker { get; set; }
    public string name { get; set; }
    public string description { get; set; }
    public DateTime startDate { get; set; }
    public DateTime endDate { get; set; }
    public string exchangeCode { get; set; }
    
    public override string ToString(){
        return $"ticker: {ticker}, name: {name}, exchangeCode: {exchangeCode}, startDate: {startDate}, endDate: {endDate}, description: {description}";
    }
}