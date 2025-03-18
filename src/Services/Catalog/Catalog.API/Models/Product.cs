﻿namespace Catalog.API.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public List<string> Category { get; set; } = new List<string>();
        public string ImageFile { get; set; }


    }
 }
