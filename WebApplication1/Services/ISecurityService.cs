using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Model;

namespace WebApplication1.Services
{
  public interface ISecurityService
    {
        (bool, string , int) ValidateUser(LoginRequest loginDetails);

    }
}
