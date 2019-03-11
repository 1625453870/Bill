using Bill.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Bill.Api.Controllers
{
    public class BaseApiController : ApiController
    {
        protected readonly int userId;
    }
}
