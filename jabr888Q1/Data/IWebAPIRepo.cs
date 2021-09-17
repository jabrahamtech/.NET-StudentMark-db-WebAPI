using jabr888Q1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace jabr888Q1.Data
{
    public interface IWebAPIRepo
    {
        IEnumerable<Marks> GetMarks();
        Marks GetMarkById(int id);
        Marks AddMark(Marks Mark);
        public bool ValidLogin(int id, string password);
        public bool ValidLogin2(int id, string password);

        Marks addmark(Marks mark);
    }
}
