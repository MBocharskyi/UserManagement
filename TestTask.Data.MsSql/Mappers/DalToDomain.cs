using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Data.MsSql.Entities;
using TestTask.Domain.UserAggregate;

namespace TestTask.Data.MsSql.Mappers
{
    public static class DalToDomain
    {
        internal static User Map(UserEntity userEntity)
        {
            return new User
            {
                Id = userEntity.Id,
                Name = userEntity.Name,
                Email = userEntity.Email,
                FilePath = userEntity.FilePath,
                SkypeLogin = userEntity.SkypeLogin,
                Note = userEntity.Note,
            };
        }
    }
}
