using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommunityWebSite.Models;

namespace CommunityWebSite.Models
{
    public class Reply
    {
        public int ReplyID { get; set; }
        public string Body { get; set; }
        public DateTime DateCreated { get; set; }

    }
}
