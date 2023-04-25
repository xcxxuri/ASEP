using System;
using Interview.ApplicationCore.Contract.Repositories;
using Interview.ApplicationCore.Contract.Services;
using Interview.ApplicationCore.Entities;
using Interview.ApplicationCore.Models;
using Interview.Infrastructure.Helper;

namespace Interview.Infrastructure.Service
{
	public class RecruiterServiceAsync: IRecruiterServiceAsync
	{
        private readonly IRecruiterRepositoryAsync _recruiterRepositoryAsync;
        public RecruiterServiceAsync(IRecruiterRepositoryAsync recruiterRepositoryAsync)
        {
            _recruiterRepositoryAsync = recruiterRepositoryAsync;
        }

        public async Task<IEnumerable<RecruiterResponseModel>> GetAllRecruiterAsync()
        {
            var recruiter = await _recruiterRepositoryAsync.GetAllAsync();
            var response = recruiter.Select(x => x.ToRecruiterResponseModel());
            return response;
        }

        public async Task<RecruiterResponseModel> GetRecruiterByIdAsync(int id)
        {
            var recruiter = await _recruiterRepositoryAsync.GetByIdAsync(id);
            var response = recruiter.ToRecruiterResponseModel();
            return response;
        }


        public async Task<int> AddRecruiterAsync(RecruiterRequestModel model)
        {
            var existingRecruiter = await _recruiterRepositoryAsync.GetByIdAsync(model.Id);
            if (existingRecruiter != null)
            {
                throw new Exception("Id is already used");
            }
            Recruiter recruiter = new Recruiter();
            if (model != null)
            {
                recruiter = model.ToRecruiter(false);
            }
            return await _recruiterRepositoryAsync.InsertAsync(recruiter);
        }

        public async Task<int> UpdateRecruiterAsync(RecruiterRequestModel model)
        {
            var existingRecruiter = await _recruiterRepositoryAsync.GetByIdAsync(model.Id);
            if (existingRecruiter == null)
            {
                throw new Exception("Recruiter does not exist");
            }
            if (model != null)
            {
                Recruiter recruiter = model.ToRecruiter(true);
                return await _recruiterRepositoryAsync.UpdateAsync(recruiter);
            }
            else
            {
                throw new Exception("Recruiter does not exist");
            }
        }

        public async Task<int> DeleteRecruiterAsync(int id)
        {
            var existingRecruiter = await _recruiterRepositoryAsync.GetByIdAsync(id);
            if (existingRecruiter == null)
            {
                throw new Exception("Recruiter does not exist");
            }
            return await _recruiterRepositoryAsync.DeleteAsync(id);
        }
	}
}

