using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestTask.Domain.UserAggregate;
using TestTask.ViewModels;

namespace TestTask.Mappers
{
    public static class UIToDomain
    {
        internal static User Map(UserCreateEditViewModel user)
        {
            return new User
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                FilePath = user.FilePath,
                SkypeLogin = user.SkypeLogin,
                Note = user.Note
            };
        }
    }
}