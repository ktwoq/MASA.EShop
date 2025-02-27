﻿namespace MASA.EShop.Services.Ordering.Entities;

public class Order
{
    public Guid Id { get; set; }
    public int OrderNumber { get; set; }
    public DateTime OrderDate { get; set; }
    public string OrderStatus { get; set; } = default!;
    public string? Description { get; set; }
    public Address Address { get; set; } = default!;
    public string BuyerId { get; set; } = default!;
    public string BuyerName { get; set; } = default!;
    public List<OrderItem> OrderItems { get; set; } = new();

    public decimal GetTotal()
    {
        var result = OrderItems.Sum(o => o.Units * o.UnitPrice);

        return result < 0 ? 0 : result;
    }

    public static Order FromActorState(Guid orderId, Actors.Order order)
    {
        return new Order
        {
            Id = orderId,
            OrderDate = order.OrderDate,
            OrderStatus = order.OrderStatus.Name,
            Description = order.Description ?? "",
            BuyerId = order.UserId,
            BuyerName = order.UserName,
            Address = new Address
            {
                Street = order.Address.Street,
                City = order.Address.City,
                ZipCode = order.Address.ZipCode,
                State = order.Address.State,
                Country = order.Address.Country
            },
            OrderItems = order.OrderItems
                .Select(OrderItem.FromActorState)
                .ToList()
        };
    }
}

