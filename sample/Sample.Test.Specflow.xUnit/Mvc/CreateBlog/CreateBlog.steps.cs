﻿using Xunit;

namespace GeekLearning.Test.Integration.Sample.Test.Mvc.CreateBlog
{
    using GeekLearning.Testavior.Environment;
    using GeekLearning.Testavior.Sample.Data;
    using Microsoft.Extensions.DependencyInjection;
    using System.Linq;
    using System.Net.Http;
    using TechTalk.SpecFlow;

    [Binding]
    public class CreateBlogSteps
    {
        [When(@"I create a new blog : '(.*)'")]
        public void WhenICreateANewBlog(string blogUrl)
        {
            ScenarioContext.Current.Get<ITestEnvironment>("TestEnvironment")
                                   .Client
                                   .PostAsJsonAntiForgeryAsync("blogs/create", new Blog { Url = blogUrl }).Wait();
        }

        [Then(@"the blog '(.*)' must be created")]
        public void ThenTheBlogMustBeCreated(string blogUrl)
        {
            using (var serviceScope = ScenarioContext.Current.Get<ITestEnvironment>("TestEnvironment").ServiceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                Assert.NotNull(serviceScope.ServiceProvider
                                             .GetService<BloggingContext>()
                                             .Blogs
                                             .FirstOrDefault(b => b.Url == blogUrl));
            }
        }
    }
}
