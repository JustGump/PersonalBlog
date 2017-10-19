﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonalBlog.Web.Models
{
    public class ArticleViewModel
    {
        public int ArticleId { get; set; }
        public string BlogTitle { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime Date { get; set; }
        public int UserProfileId { get; set; }
        public string UserProfile { get; set; }
        public List<string> Tags { get; set; }
    }
}