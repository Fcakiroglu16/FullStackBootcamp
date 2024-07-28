using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Repository.Data
{
    public class BaseUserEntity<T> : BaseEntity<T>
    {
        public Guid UserId { get; set; }
    }
}