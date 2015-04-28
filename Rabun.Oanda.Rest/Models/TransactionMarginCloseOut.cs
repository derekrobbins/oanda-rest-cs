namespace Rabun.Oanda.Rest.Models
{
public class TransactionMarginCloseOut: TransactionSimple {
    public int TradeId;
    public float Pl;
    public int Interest;
    public float AccountBalance;
}
}