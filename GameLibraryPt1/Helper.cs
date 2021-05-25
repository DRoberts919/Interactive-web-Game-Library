using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace GameLibraryPt1
{
    public static class Helper
    {

        public static bool IsAdmin(this ClaimsPrincipal user)
        {

            return user.Identity.IsAuthenticated && user.IsInRole("Admin");

        }


    }
}
