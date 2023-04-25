using System;
using Authentication.ApplicationCore.Contract.Repositories;
using Authentication.ApplicationCore.Contract.Services;
using Authentication.ApplicationCore.Entities;
using Authentication.ApplicationCore.Models;
using Authentication.Infrastructure.Helper;

namespace Authentication.Infrastructure.Service
{
    public class AccountServiceAsync : IAccountServiceAsync
    {
        private readonly IAccountRepositoryAsync _accountRepositoryAsync;
        public AccountServiceAsync(IAccountRepositoryAsync accountRepositoryAsync)
        {
            _accountRepositoryAsync = accountRepositoryAsync;
        }

        public async Task<IEnumerable<AccountResponseModel>> GetAllAccountAsync()
        {
            var accounts = await _accountRepositoryAsync.GetAllAsync();
            var response = accounts.Select(x => x.ToAccountResponseModel());
            return response;

        }

        public async Task<AccountResponseModel> GetAccountByIdAsync(int id)
        {
            var account = await _accountRepositoryAsync.GetByIdAsync(id);
            var response = account.ToAccountResponseModel();
            return response;
        }

        public async Task<int> AddAccountAsync(AccountRequestModel model)
        {
            var existingAccount = await _accountRepositoryAsync.GetByIdAsync(model.Id);
            if (existingAccount != null)
            {
                throw new Exception("Id is already used");
            }
            Account account = new Account();
            if (model != null)
            {
                account = model.ToAccount(false);
            }
            return await _accountRepositoryAsync.InsertAsync(account);

        }

        public async Task<int> UpdateAccountAsync(AccountRequestModel model)
        {
            var existingAccount = await _accountRepositoryAsync.GetByIdAsync(model.Id);
            if (existingAccount == null)
            {
                throw new Exception("Account does not exist");
            }
            if (model != null)
            {
                Account account = model.ToAccount(true);
                return await _accountRepositoryAsync.UpdateAsync(account);
            }
            return 0;
        }

        public async Task<int> DeleteAccountAsync(int id)
        {
            var existingAccount = await _accountRepositoryAsync.GetByIdAsync(id);
            if (existingAccount == null)
            {
                throw new Exception("Account does not exist");
            }
            return await _accountRepositoryAsync.DeleteAsync(id);
        }

    }
}

