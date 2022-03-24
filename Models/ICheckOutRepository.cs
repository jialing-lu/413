using System;
using System.Linq;

namespace _413.Models
{
    public interface ICheckOutRepository
    {
        public IQueryable<CheckOut> CheckOut { get; }

        public void SaveCheckOut(CheckOut checkout);

    }
}
