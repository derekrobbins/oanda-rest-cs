namespace Rabun.Oanda.Rest.Models
{
public class TransactionOrderCancel: Transaction {
    public int OrderId { get; set; }
    public OandaTypes.Reason Reason { get; set; }
}
}