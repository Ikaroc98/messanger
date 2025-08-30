using messanger.Repositories;
using messanger.Models;

namespace messanger.Services
{
    public class AccountInfoService
    {
        private readonly AccountInfoRepository repository;
        public AccountInfoService(AccountInfoRepository _repository)
        {
            repository = _repository;
        }
        public async Task<Boolean> CrateAccountInfoAsync(int id, string Name, string Surname, DateTime Birth)
        {
            return await repository.CrateAccountInfoAsync(new AccountInfo { Accountid = id, Name = Name, Surname = Surname, Birth = DateOnly.FromDateTime(Birth)});
        }
    }
}
