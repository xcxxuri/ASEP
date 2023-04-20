using System;
using ApplicationCore.Contract.Repositories;
using ApplicationCore.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
	public class EmployeeTypeRepository : BaseRepository<EmployeeType> , IEmployeeTypeRepository
	{
		public EmployeeTypeRepository(RecurtingDbContext dbContext) : base(dbContext)
		{
		}

        public async Task<EmployeeType> GetEmployeeTypeByTypeName(string typeName)
        {
            return await _ReDbContext.EmployeeTypes.Where(x => x.TypeName == typeName.ToLower()).FirstOrDefaultAsync();
        }
    }
}

