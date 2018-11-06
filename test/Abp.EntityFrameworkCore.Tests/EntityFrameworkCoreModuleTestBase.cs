﻿using System;
using System.Threading.Tasks;
using Abp.EntityFrameworkCore.Tests.Domain;
using Abp.EntityFrameworkCore.Tests.Ef;
using Abp.TestBase;
using Abp.Timing;

namespace Abp.EntityFrameworkCore.Tests
{
    public abstract class EntityFrameworkCoreModuleTestBase : AbpIntegratedTestBase<EntityFrameworkCoreTestModule>
    {
        protected EntityFrameworkCoreModuleTestBase()
        {
            Clock.Provider = ClockProviders.Utc;
            CreateInitialData();
        }

        private void CreateInitialData()
        {
            UsingDbContext(
                context =>
                {
                    var blog1 = new Blog("test-blog-1", "http://testblog1.myblogs.com");

                    context.Blogs.Add(blog1);
                    context.SaveChanges();

                    var post1 = new Post { Blog = blog1, Title = "test-post-1-title", Body = "test-post-1-body" };
                    var post2 = new Post { Blog = blog1, Title = "test-post-2-title", Body = "test-post-2-body" };
                    var post3 = new Post { Blog = blog1, Title = "test-post-3-title", Body = "test-post-3-body-deleted", IsDeleted = true };
                    var post4 = new Post { Blog = blog1, Title = "test-post-4-title", Body = "test-post-4-body", TenantId = 42 };

                    context.Posts.AddRange(post1, post2, post3, post4);
                });

            using (var context = LocalIocManager.Resolve<SupportDbContext>())
            {
                context.Tickets.AddRange(
                    new Ticket { EmailAddress = "john@aspnetboilerplate.com", Message = "an active message", TenantId = 1 },
                    new Ticket { EmailAddress = "david@aspnetboilerplate.com", Message = "an inactive message", IsActive = false, TenantId = 1},
                    new Ticket { EmailAddress = "smith@aspnetboilerplate.com", Message = "an active message of tenant 42", TenantId = 42}
                );

                context.SaveChanges();
            }
        }

        public void UsingDbContext(Action<BloggingDbContext> action)
        {
            using (var context = LocalIocManager.Resolve<BloggingDbContext>())
            {
                action(context);
                context.SaveChanges();
            }
        }

        public T UsingDbContext<T>(Func<BloggingDbContext, T> func)
        {
            T result;

            using (var context = LocalIocManager.Resolve<BloggingDbContext>())
            {
                result = func(context);
                context.SaveChanges();
            }

            return result;
        }

        public async Task UsingDbContextAsync(Func<BloggingDbContext, Task> action)
        {
            using (var context = LocalIocManager.Resolve<BloggingDbContext>())
            {
                await action(context);
                await context.SaveChangesAsync(true);
            }
        }

        public async Task<T> UsingDbContextAsync<T>(Func<BloggingDbContext, Task<T>> func)
        {
            T result;

            using (var context = LocalIocManager.Resolve<BloggingDbContext>())
            {
                result = await func(context);
                context.SaveChanges();
            }

            return result;
        }
    }
}