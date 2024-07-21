using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Service.OpenTelemetry
{
    public class ActivitySourceProvider
    {
        public static ActivitySource ActivitySource => new ActivitySource("Mvc.API.Activity.Source");
    }
}