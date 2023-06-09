﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBProject.Models
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAllProductsandPrices();
        Supplier GetProductById(int ProductID);
    }
}
