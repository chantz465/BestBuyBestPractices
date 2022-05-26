using System;
using System.Collections.Generic;
namespace IntroSQL
{
    public interface IProductRepository
    {
        public IEnumerable<Product> GetAllProducts(); //Stubbed out method
    }
}