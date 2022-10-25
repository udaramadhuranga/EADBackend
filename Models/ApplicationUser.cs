using AspNetCore.Identity.MongoDbCore.Models;
using MongoDbGenericRepository.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EADBackend.Models
{
    [CollectionName("Appusers")]
    public class ApplicationUser : MongoIdentityUser<Guid>
    {
    }
}
