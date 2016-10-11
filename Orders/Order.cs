using System;
using System.Collections.Generic;

namespace Bangazon.Orders
{
  public class Order {
    private List<string> _products = new List<string>();

    public List<string> products
    {
      get {
        return _products;
      }
    }

    private Guid _orderNumber = Guid.NewGuid();
    
    public Guid orderNumber {
      get {
        return _orderNumber;
      }
    }
    public void addProduct(string product)
    {
      _products.Add(product);
    }

    public string listProducts()
    {
      string output = "";

      foreach (string product in _products)
      {
        output += $"\nYou ordered {product}";
      }

      return output;
    }

    public bool removeProduct(string product)
    {
      return _products.Remove(product);
    }

    public void removeProduct()
    {
      _products.Clear();
    }

  }
}