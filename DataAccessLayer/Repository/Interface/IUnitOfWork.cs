﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository.Interface
{
    public interface IUnitOfWork
    {
        Task SaveAsync();
        void Save();
    }
}
