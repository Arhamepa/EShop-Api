﻿using Common.Domain;

namespace Shop.Domain.ProductAgg;

public class ProductSpecification : BaseEntity
{
    public ProductSpecification(string key, string value)
    {
        Key = key;
        Value = value;
    }

    public long ProductId { get; internal set; }
    public string Key { get; private set; }
    public string Value { get; private set; }

}