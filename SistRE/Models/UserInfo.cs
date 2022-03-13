using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistRE.Models
{
    public class UserInfo
    {
        public string userName { get; set; }
        public string profile { get; set; }
        public int idProfile { get; set; }

        public UserInfo(string userName, string profile, int idProfile)
        {
            this.userName = userName;
            this.profile = profile;
            this.idProfile = idProfile;
        }
    }
}