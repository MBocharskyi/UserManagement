using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Data.MsSql.Entities;
using TestTask.Domain.UserAggregate;

namespace TestTask.Data.MsSql.Mappers
{
    public static class DomainToDal
    {
        internal static void Map(UserEntity userEntity, User user)
        {
            userEntity.Id = user.Id;
            userEntity.Name = user.Name;
            userEntity.Email = user.Email;
            userEntity.FilePath = user.FilePath;
            userEntity.SkypeLogin = user.SkypeLogin;
            userEntity.Note = user.Note;
        }
    }
}
