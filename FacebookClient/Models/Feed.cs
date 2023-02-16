using System;
using System.Collections.Generic;
using System.Text;

namespace FacebookAPIClient.Models
{
    public class Feed
    {
        public string Id { get; set; }

        public List<Post> Posts { get; set; }
    }
}
