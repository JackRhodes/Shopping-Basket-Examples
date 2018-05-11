using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RazorPageExample.DataAccess;
using RazorPageExample.Services;
using RazorPageExample.Tests.Helpers;

namespace RazorPageExample.Tests.Services
{
    [TestClass]
    public class ProductRepositoryTests
    {
        //Due to the setup of IdentityDbContext, it is currently not possible to MOQ a context and test the actual repository itself. 
        //Until a way is found, only the manager will be Unit Tested with a mock repository that we can assume will return the correct results
        //This fundamentally is against TDD.
    
    }
}
