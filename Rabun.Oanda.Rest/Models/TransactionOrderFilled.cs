namespace Rabun.Oanda.Rest.Models
{
public class TransactionOrderFilled: TransactionDefault {
    public int Pl;
    public int Interest;
    public int OrderId;
    public TradeOpened TradeOpened;
}
}