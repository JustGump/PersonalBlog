﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonalBlog.Domain.DataTransferObjects;

namespace PersonalBlog.Domain.Interfaces
{
    public interface IBlogService : IDisposable
    {
        void Create(BlogDTO blogDTO);
        IEnumerable<BlogDTO> GetAll();
    }
}
