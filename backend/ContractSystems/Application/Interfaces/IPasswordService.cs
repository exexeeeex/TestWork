using Application.DTOS;
using Application.Models;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IPasswordService
    {
        public Task<List<PasswordModel>> GetAllPasswordsAsync(CancellationToken cancellationToken = default);
        public Task<List<PasswordType>> GetAllPasswordTypes(CancellationToken cancellationToken = default);
        public Task<bool> CreatePasswordAsync(PasswordDTO password, CancellationToken cancellationToken = default);
    }
}