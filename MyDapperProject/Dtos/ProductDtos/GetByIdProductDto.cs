﻿namespace MyDapperProject.Dtos.ProductDtos
{
    public class GetByIdProductDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int ProductStock { get; set; }
        public decimal ProductPrice { get; set; }
        public string CategoryId { get; set; }
    }
}
