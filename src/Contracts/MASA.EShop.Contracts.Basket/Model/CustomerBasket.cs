﻿using System.ComponentModel.DataAnnotations;

namespace MASA.EShop.Contracts.Basket.Model.BFF;

public class CustomerBasket
{
    public string BuyerId { get; set; } = default!;

    public List<BasketItem> Items { get; set; } = new List<BasketItem>();

    public CustomerBasket()
    {

    }

    public CustomerBasket(string customerId)
    {
        BuyerId = customerId;
    }
}

public class BasketItem : IValidatableObject
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public string ProductName { get; set; } = default!;
    public decimal UnitPrice { get; set; }
    public decimal OldUnitPrice { get; set; }
    public int Quantity { get; set; }
    public string PictureFileName { get; set; } = default!;

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        var results = new List<ValidationResult>();

        if (Quantity < 1)
        {
            results.Add(new ValidationResult("Invalid number of units", new[] { "Quantity" }));
        }

        return results;
    }
}
