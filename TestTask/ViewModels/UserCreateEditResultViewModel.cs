using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestTask.ViewModels
{
    public class UserCreateEditResultViewModel
    {
        public int Id { get; set; }

        public string Message { get; set; }

        public bool HasSaved { get; set; }
    }
}
