﻿using Domain.Entities;

namespace Domain.Interfaces
{
    public interface ICompanyRepository : IBaseRepository<Company>
    {
        public Task<Company> GetByIdDetailsAsync(int id);
    }
}
