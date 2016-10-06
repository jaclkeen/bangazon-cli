using Bangazon.Orders;

namespace Bangazon.Payments
{
  public class CreditCard: Payment 
  {

    public string bankName { get; set; }
    public string accountNumber { get; set; }

    public CreditCard(Order order): base(order)
    {

    }
    public override string process()
    {
      return $"You are using a {this.bankName} card, with the account number {this.accountNumber}\n{base.process()}";
      
    }
  }
}