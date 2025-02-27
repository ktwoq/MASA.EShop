﻿namespace MASA.EShop.Contracts.Catalog.Model;

public class CatalogData
{
    public string SortType { get; set; } = "Featured";

    public string Search { get; set; } = "";

    public int Count { get; set; }

    public IEnumerable<CatalogItem> Items { get; set; } = Enumerable.Empty<CatalogItem>();

    public int PageIndex { get; set; }

    public int PageSize { get; set; } = 1;

    public int PageCount => (int)Math.Ceiling(Count / (decimal)PageSize);
}

