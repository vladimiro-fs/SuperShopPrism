﻿namespace SuperShopPrism.Models
{
    using System;

    public class ProductResponse
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public float Price { get; set; }

        public object ImageId { get; set; }

        public object LastPurchase { get; set; }

        public object LastSale { get; set; }

        public bool IsAvailable { get; set; }

        public float Stock { get; set; }

        public UserResponse User { get; set; }

        public string ImageFullPath
        {
            get
            {
                if (ImageId is Guid id && id != Guid.Empty)
                {
                    return $"https://localhost:44345/products/{id}.jpg";
                }

                return "https://localhost:44345/images/noimage.png";
            }
        }
    }
}