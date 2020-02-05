using OrnekUyg.BLL.Abstract;
using OrnekUyg.DAL.Abstract;
using OrnekUyg.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrnekUyg.BLL.Concrate
{
    public class UserService : IUserService
    {
        IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public void Delete(User entity)
        {
            _userRepository.Delete(entity);
        }

        public void DeleteById(int id)
        {
            Delete(Get(id));
        }

        public User Get(int entityID)
        {
            return _userRepository.Get(x => x.UserID == entityID);
        }

        public ICollection<User> GetAll()
        {
            return _userRepository.GetAll();
        }

        public void Insert(User entity)
        {
            _userRepository.Add(entity);
        }

        public User Login(string username, string password)
        {
            User user = _userRepository.Get(x => x.UserName == username);
            if (user != null)
            {
                if (user.Password == password)
                {
                    return user;
                }
                else
                {
                    throw new Exception("Hatalı Parola");
                }

            }
            else
            {
                throw new Exception("Kullanıcı Bulunamadı");
            }
        }

        public void Update(User entity)
        {
            entity.UpdateDate = DateTime.Now;
            _userRepository.Update(entity);
        }
    }
}
