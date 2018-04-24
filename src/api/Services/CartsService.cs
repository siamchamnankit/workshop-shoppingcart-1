using System;
using System.Collections.Generic;
using System.Linq;
using api.Models;

namespace api.Services
{
    public class CartsService
    {
        private readonly CartsContext _context;

        public CartsService(CartsContext context)
        {
            _context = context;
        }

        internal IEnumerable<CartsModel> list()
        {
             return _context.Carts.ToList();
        }
    }
}