namespace Model.ApiData;

public class Stock{
    
    public DateTime date { get; set; }
    public double close { get; set; }
    public double high { get; set; }
    public double low { get; set; }
    public double open { get; set; }
    public int volume { get; set; }
    public double adjClose { get; set; }
    public double adjHigh { get; set; }
    public double adjLow { get; set; }
    public double adjOpen { get; set; }
    public int adjVolume { get; set; }
    public double divCash { get; set; }
    public double splitFactor { get; set; }
    
    public override string ToString(){
        return $"adjClose: {adjClose}, adjHigh: {adjHigh}, adjLow: {adjLow}, adjOpen: {adjOpen}, adjVolume: {adjVolume}, close: {close}, date: {date}, divCash: {divCash}, high: {high}, low: {low}, open: {open}, splitFactor: {splitFactor}, volume: {volume}";
    }
}