using jabr888Q1.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace jabr888Q1.Data
{
    public class DBWebAPIRepo : IWebAPIRepo
    {
        private readonly WebAPIDBContext _dbContext;
        public DBWebAPIRepo(WebAPIDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Marks> GetMarks()
        {
            IEnumerable<Marks>  Marks = _dbContext.Marks.ToList<Marks>();
            return Marks;
        }
        public Marks GetMarkById(int id)
        {
            Marks Mark = _dbContext.Marks.FirstOrDefault(e => e.Id == id);
            return Mark;
        }

        public Marks AddMark(Marks Mark)
        {
            EntityEntry<Marks> e = _dbContext.Marks.Add(Mark);
            Marks c = e.Entity;
            _dbContext.SaveChanges();
            return c;
        }

        public bool ValidLogin(int id, string password)
        {
            Staff c = _dbContext.Staff.FirstOrDefault(e => e.Id == id && e.Password == password);
            if (c == null)
                return false;
            else
                return true;
        }
        public bool ValidLogin2(int id, string password)
        {
            Staff c = _dbContext.Staff.FirstOrDefault(e => e.Id == id && e.Password == password);
            Students s = _dbContext.Students.FirstOrDefault(e => e.Id == id && e.Password == password);
            if (c == null && s == null)
                return false;
            else
                return true;
        }

        public Marks addmark(Marks mark)
        {
            Marks Mark = _dbContext.Marks.FirstOrDefault(e => e.Id == mark.Id);
            if(Mark == null)
            {
                EntityEntry<Marks> e = _dbContext.Marks.Add(mark);
                Marks m = e.Entity;
                _dbContext.SaveChanges();
                return m;
            }
            Mark.A1 = mark.A1;
            Mark.A2 = mark.A2;
            _dbContext.SaveChanges();
            return Mark;
        }
    }
}
