﻿namespace MASA.EShop.Contracts.Catalog.Model;

public record CatalogItem
{
    public int Id { get; init; }
    public string Name { get; init; } = default!;
    public string Description { get; init; } = default!;
    public decimal Price { get; init; }
    public string PictureFileName { get; init; } = default!;
    public string Brand { get; set; } = default!;
    public string Type { get; set; } = default!;
    public int AvailableStock { get; set; }
    public bool Favorite { get; set; }

    public string GetPictureUrl() => $"./img/{PictureFileName}";
}

