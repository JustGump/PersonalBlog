using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PersonalBlog.DataAccess.Entities;
using PersonalBlog.Domain.DataTransferObjects;
using PersonalBlog.Web.AutoMapper;

namespace PersonalBlog.Web.Test
{
    [TestClass()]
    public class AutoMapperConfigurationTest
    {
        [TestMethod()]
        public void Initialization_ProjectingDataToDTO_ShouldReturnTrue()
        {
            Article article = new Article(){Title = "Andrew"};
         //   Mapper.Initialize(AutoMapperConfiguration.Initialize());

            var a = Mapper.Map<Article, ArticleDTO>(article);

            Assert.AreEqual("Andrew",a.Title);

        }

        [TestMethod()]
        public void Initialization_ProjectingListOfDataToDTO_ShouldReturnTrue()
        { 
            List<Article> articles = new List<Article>()
            {
              new  Article() { Title = "Andrew" },
              
            }; 
            //Mapper.Initialize(AutoMapperConfiguration.Initialize());

            var a = Mapper.Map<IEnumerable<Article>, IEnumerable<ArticleDTO>>(articles);
            var result = a.Select(dto => dto.Title).FirstOrDefault();

            Assert.AreEqual("Andrew",result );

        }
    }
}
