using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestTask.Domain.UserAggregate;
using TestTask.ViewModels;

namespace TestTask.Mappers
{
    public static class DomainToUI
    {
        internal static UserIndexViewModel Map(User user)
        {
            return new UserIndexViewModel
            {
                Id = user.Id,
                Name = user.Name
            };
        }

        internal static void Map(UserCreateEditViewModel userViewModel, User user)
        {
            userViewModel.Id = user.Id;
            userViewModel.Name = user.Name;
            userViewModel.Email = user.Email;
            userViewModel.FilePath = user.FilePath != null ? user.FilePath : string.Empty;
            userViewModel.SkypeLogin = user.SkypeLogin != null ? user.SkypeLogin : string.Empty;
            userViewModel.Note = user.Note != null ? user.Note : string.Empty;
        }
    }
}