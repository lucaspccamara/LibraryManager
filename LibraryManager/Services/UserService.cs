using LibraryManager.Data;
using LibraryManager.Models;
using LibraryManager.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManager.Services
{
    public class UserService
    {
        private readonly LibraryManagerContext _context;

        public UserService(LibraryManagerContext context)
        {
            _context = context;
        }

        public List<User> FindAll()
        {
            return _context.User.OrderBy(obj => obj.Name).ToList();
        }

        public User FindById(int id)
        {
            return _context.User.FirstOrDefault(obj => obj.Id == id);
        }

        public void Insert(User obj)
        {
            obj.CreatedDate = DateTime.Now;
            obj.IndAtivo = ActiveStatus.Sim;

            _context.Add(obj);
            _context.SaveChanges();
        }

        public void Update(User obj)
        {
            var oldUser = _context.User.FirstOrDefault(obj => obj.Id == obj.Id);

            obj.EndPenalizedPeriod = oldUser.EndPenalizedPeriod;
            obj.Status = oldUser.Status;
            obj.CreatedDate = oldUser.CreatedDate;
            obj.UpdatedDate = DateTime.Now;
            obj.DeletedDate = oldUser.DeletedDate;

            _context.Update(obj);
            _context.SaveChanges();
        }

        public void Delete(User obj)
        {
            obj.IndAtivo = ActiveStatus.Não;
            obj.DeletedDate = DateTime.Now;

            _context.Update(obj);
            _context.SaveChanges();
        }
    }
}
