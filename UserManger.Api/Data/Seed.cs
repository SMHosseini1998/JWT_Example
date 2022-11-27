using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using UserManger.Api.Model;

namespace UserManger.Api.Data
{
    public static class Seed
    {
        public static  void SeedUsers(this ModelBuilder modelBuilder)
        {

            var roles = new List<Role>
            {
                new Role{Id = "603d125d-f84a-46e1-bfb7-48a199a51c39", Name = "Admin"},
                new Role{Id ="5d726248-fc7c-49b3-af66-921d8e2a7280", Name = "Owner"},
                new Role{Id = "9d9b95d7-9347-42da-ab97-a1cbb6f50081", Name = "Guest"}
            };


            foreach (var role in roles)
            {
                modelBuilder.Entity<Role>().HasData(role);
            }


           
            var hasher = new PasswordHasher<IdentityUser>();
            modelBuilder.Entity<User>().HasData(
                    new User
                    {
                        Id = "769c4fd7-ce76-4bbc-a7db-c803efd02ba9", // primary key
                        Locked = false,
                        FirstName = "مهدی حسینی ",
                        LastName = "مدیر سایت",
                        PhotoUrl = "default.jpg",
                        SecurityStamp = Guid.NewGuid().ToString(),
                        UserName = "Admin",
                        NormalizedUserName = "Admin",
                        PasswordHash = hasher.HashPassword(null, "User@123")
                    }
                );
            modelBuilder.Entity<User>().HasData(
                    new User
                    {
                        Id = "378fd964-0b06-4f77-93ff-95ed2368e5b3", // primary key
                        Locked = false,
                        FirstName = "ناصر احمدی ",
                        LastName = "مشتری",
                        PhotoUrl = "default.jpg",
                        SecurityStamp = Guid.NewGuid().ToString(),
                        UserName = "Guest",
                        NormalizedUserName = "Guest",
                        PasswordHash = hasher.HashPassword(null, "User@123")
                    }
                );
            modelBuilder.Entity<UserRole>().HasData(
                    new UserRole
                    {
                        RoleId = "603d125d-f84a-46e1-bfb7-48a199a51c39",
                        UserId = "769c4fd7-ce76-4bbc-a7db-c803efd02ba9"
                    }
                );
            modelBuilder.Entity<UserRole>().HasData(
                    new UserRole
                    {
                        RoleId = "9d9b95d7-9347-42da-ab97-a1cbb6f50081",
                        UserId = "378fd964-0b06-4f77-93ff-95ed2368e5b3"
                    }
                );


        }
    }
}

