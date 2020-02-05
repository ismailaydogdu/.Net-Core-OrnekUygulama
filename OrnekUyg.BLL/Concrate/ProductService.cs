using OrnekUyg.BLL.Abstract;
using OrnekUyg.DAL.Abstract;
using OrnekUyg.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OrnekUyg.BLL.Concrate
{
    public class ProductService : IProductService
    {
        IProductRepository _productRepository;

        public ProductService(IProductRepository product)
        {
            _productRepository = product;
        }
        public void Delete(Product entity)
        {
            _productRepository.Delete(entity);
        }

        public void DeleteById(int id)
        {
            Product prod = _productRepository.Get(a => a.ProductID == id);
            _productRepository.Delete(prod);
        }

        public Product Get(int entityID)
        {
            return _productRepository.Get(a => a.ProductID == entityID);
        }

        public ICollection<Product> GetAll()
        {
            return _productRepository.GetAll();
        }

        public ICollection<Product> GetByCategoryID(int categoryID)
        {
            return _productRepository.GetAll(x => x.CategoryID == categoryID);
        }

        public List<Product> GetProductsByCategory(int categoryID)
        {
            return _productRepository.GetAll(a => a.CategoryID == categoryID).ToList();
        }

        public void Insert(Product entity)
        {
            _productRepository.Add(entity);
        }

        public void Update(Product entity)
        {
            _productRepository.Update(entity);
        }
    }
}
