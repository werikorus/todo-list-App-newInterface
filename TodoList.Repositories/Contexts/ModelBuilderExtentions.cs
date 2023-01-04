using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TodoList.Domain.Entities.Users;

namespace TodoList.Repositories.Contexts;

public static class ModelBuilderExtentions 
{
    public static void Seed(this ModelBuilder modelBuilder)
    {
      /*  var userBuilder = new UserBuilder();

        UserBuilder.Entity()
            .HasData(new List<User>
            {
                userBuilder
                    .WithId(Guid.NewGuid())
                    .WithName("Werik Santos")
                    .WithEmail("werik.msti@gmail.com")
                    .WithPassword("werikorus@12")
                    .WithDateCreate(new DateTime())
                    .WithDateUpdate(new DateTime())
                    .Build(),

                userBuilder
                    .WithId(Guid.NewGuid())
                    .WithName("Ester Carvalho")
                    .WithEmail("estervarvalhodealencar@gmail.com")
                    .WithPassword("violetta44")
                    .WithDateCreate(new DateTime())
                    .WithDateUpdate(new DateTime())
                    .Build(),

                userBuilder
                    .WithId(Guid.NewGuid())
                    .WithName("Isaac Carvalho Santos")
                    .WithEmail("isaaccarvalhosantos@gmail.com")
                    .WithPassword("isaacfilhodeabraao@123")
                    .WithDateCreate(new DateTime())
                    .WithDateUpdate(new DateTime())
                    .Build()

            });
            */
    }
}