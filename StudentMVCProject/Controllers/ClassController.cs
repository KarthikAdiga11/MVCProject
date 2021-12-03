using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DataAccessLayer;
using Entities;
using DataAccessLayer.Repository;

namespace APILayer.Controllers
{
    public class ClassController : BaseController<Class>
    {
        public ClassController(IBaseRepository<Class> repo) : base(repo)
        {

        }

    }
}
