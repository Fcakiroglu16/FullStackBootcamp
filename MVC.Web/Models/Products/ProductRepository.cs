﻿using System.Net.Sockets;
using MVC.Web.Models.ViewModels;

namespace MVC.Web.Models.Products
{
    public class ProductRepository : IProductRepository
    {
        private static List<Product> ProductList { get; set; } =
        [
            new()
            {
                CategoryId = 1, Description = "abc", IsPublisher = true, Name = "kalem", PublisherDurationId = 1,
                Id = 100,
                Price = 200, StockCount = 20, PictureUrl = "", PublishExpire = DateTime.Now.AddDays(20)
            }
        ];

        private static readonly List<SelectModel> PublishDurationList =
        [
            new("3 ay", "1"),
            new("6 ay", "2"),
            new("9 ay", "3")
        ];

        //crud methods
        public void Add(Product product)
        {
            ProductList.Add(product);
        }

        public void Update(Product product)
        {
            var productToUpdate = ProductList.FirstOrDefault(x => x.Id == product.Id);
            if (productToUpdate != null)
            {
                productToUpdate.Name = product.Name;
                productToUpdate.Price = product.Price;
                productToUpdate.Description = product.Description;
                productToUpdate.StockCount = product.StockCount;
                productToUpdate.CategoryId = product.CategoryId;
                productToUpdate.PictureUrl = product.PictureUrl;
                productToUpdate.IsPublisher = product.IsPublisher;
                productToUpdate.PublisherDurationId = product.PublisherDurationId;
                productToUpdate.PublishExpire = product.PublishExpire;
            }
        }

        public void Delete(int id)
        {
            var productToDelete = ProductList.FirstOrDefault(x => x.Id == id);
            if (productToDelete != null)
            {
                ProductList.Remove(productToDelete);
            }
        }

        public List<Product> GetAll()
        {
            return ProductList;
        }

        public Product? GetById(int id)
        {
            return ProductList.FirstOrDefault(x => x.Id == id);
        }

        public List<SelectModel> GetPublishDuration()
        {
            return PublishDurationList;
        }

        public string GetPublishDurationKey(string value)
        {
            return PublishDurationList.FirstOrDefault(x => x.Value == value)!.Text;
        }

        public bool HasProduct(string name)
        {
            return ProductList.Any(x => x.Name == name);
        }

        public bool HasProduct(Func<Product, bool> func)
        {
            return ProductList.Any(func);
        }
    }
}