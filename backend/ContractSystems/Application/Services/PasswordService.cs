using Application.DTOS;
using Application.Interfaces;
using Application.Models;
using Domain.Data;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{
    public class PasswordService(ApplicationDbContext context) : IPasswordService
    {
        public async Task<bool> CreatePasswordAsync(PasswordDTO password, CancellationToken cancellationToken = default)
        {
            var type = await context.PasswordTypes
                .FirstOrDefaultAsync(c => c.Id == password.PasswordTypeId, cancellationToken);
            if(type?.Name.ToLower() == "email" && !ValidationService.CheckCorrectEmail(password.Name))
                throw new ArgumentException("Некорректный email!");
            if(!ValidationService.CheckVoidField(password))
                throw new ArgumentException("Заполните все поля");
            if(!ValidationService.CheckPasswordLength(password.Value))
                throw new ArgumentException("Пароль должен содержать минимум 8 символов!");
            
            var passwordModel = new Password()
            {
                Name = password.Name,
                Value = password.Value,
                CreateDate = DateTime.UtcNow,
                PasswordTypeId = password.PasswordTypeId
            };
            context.Passwords.Add(passwordModel);
            await context.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task<List<PasswordModel>> GetAllPasswordsAsync(CancellationToken cancellationToken = default) =>
            await context.Passwords
                .AsNoTracking()
                .Select(p => new PasswordModel()
                {
                    Id = p.Id,
                    Name = p.Name,
                    Value = p.Value,
                    CreateDate = p.CreateDate.ToString("dd.mm.yyyy hh:MM"),
                    PasswordTypeId = p.PasswordTypeId
                })
                .ToListAsync(cancellationToken);

        public async Task<List<PasswordType>> GetAllPasswordTypes(CancellationToken cancellationToken = default) =>
            await context.PasswordTypes
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }
}