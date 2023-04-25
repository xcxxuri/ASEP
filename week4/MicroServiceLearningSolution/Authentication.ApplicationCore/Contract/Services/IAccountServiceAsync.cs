using System;
using Authentication.ApplicationCore.Models;

namespace Authentication.ApplicationCore.Contract.Services
{
    public interface IAccountServiceAsync
    {
        Task<IEnumerable<AccountResponseModel>> GetAllAccountAsync();
        Task<AccountResponseModel> GetAccountByIdAsync(int id);
        Task<int> AddAccountAsync(AccountRequestModel account);
        Task<int> UpdateAccountAsync(AccountRequestModel account);
        Task<int> DeleteAccountAsync(int id);
    }
}

