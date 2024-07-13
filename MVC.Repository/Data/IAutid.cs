using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Repository
{
    internal interface IAuditByDate
    {
        DateTime Created { get; set; }
        DateTime Updated { get; set; }
    }

    interface IAuditByUser
    {
        string CreatedByUser { get; set; }

        string UpdatedByUser { get; set; }
    }
}