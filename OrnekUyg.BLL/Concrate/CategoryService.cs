using OrnekUyg.BLL.Abstract;
using OrnekUyg.DAL.Abstract;
using OrnekUyg.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrnekUyg.BLL.Concrate
{
    public class CategoryService: ICategoryService
    {
        ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public void Delete(Category entity)
        {
            _categoryRepository.Delete(entity);
        }

        public void DeleteById(int id)
        {
            Category cat = _categoryRepository.Get(a => a.CategoryID == id);
            _categoryRepository.Delete(cat);
        }

        public Category Get(int entityID)
        {
            return _categoryRepository.Get(a => a.CategoryID == entityID);
        }

        public ICollection<Category> GetAll()
        {
            return _categoryRepository.GetAll();
        }

        public void Insert(Category entity)
        {
            _categoryRepository.Add(entity);
        }

        public void Update(Category entity)
        {
            _categoryRepository.Update(entity);
        }
    }
}
