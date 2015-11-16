using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using StudentInformation.Models;

namespace StudentInformation.Controllers
{
    public class BaseController : BaseController<User,StudentContext,string>
    {
    }
}
