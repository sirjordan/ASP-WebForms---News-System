using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Web.Routing;

namespace News_System
{
    public class SessionHelper
    {
        public void LogInUser(HttpSessionState session, User user)
        {
            session["loggedUser"] = user;
        }

        public void LogOutUser(HttpSessionState session)
        {
            session["loggedUser"] = null;
        }

        public User GetLogedUser(HttpSessionState session)
        {
            return (User)session["loggedUser"];
        }
    }
}