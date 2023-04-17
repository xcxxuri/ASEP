using System;
using MVCLearning.Entity;

namespace MVCLearning.UserRepo
{
    public interface IUserRepository
    {
        List<User> GetAllUsers();
    }

    public class UserRepository : IUserRepository
    {
        public List<User> GetAllUsers()
        {
            return new List<User>()
            {
                new User()
                {
                    Id = 1,
                    FirstName = "John",
                    LastName = "Doe",
                    DateOfBirth = new DateTime(1990, 1, 1),
                    UserName = "jdoe"
                },
                new User()
                {
                    Id = 2,
                    FirstName = "alex",
                    LastName = "Samdre",
                    DateOfBirth = new DateTime(1998, 2, 2),
                    UserName = "asMax"
                },
                new User()
                {
                    Id = 2,
                    FirstName = "Max",
                    LastName = "Well",
                    DateOfBirth = new DateTime(1977, 3, 3),
                    UserName = "HitMan"
                },

            };
        }
    }
    // we can create a new repository to replace the old one while do not change the code in the controller, and when we need to change the repository, we just need to change the service in the program.cs
    public class NewUserRepository : IUserRepository
    {
        public List<User> GetAllUsers()
        {
            return new List<User>()
            {
                new User()
                {
                    Id = 1,
                    FirstName = "John",
                    LastName = "Doe",
                    DateOfBirth = new DateTime(1990, 1, 1),
                    UserName = "jdoe"
                },
                new User()
                {
                    Id = 2,
                    FirstName = "alex",
                    LastName = "Samdre",
                    DateOfBirth = new DateTime(1998, 2, 2),
                    UserName = "asMax"
                },
                new User()
                {
                    Id = 2,
                    FirstName = "Max",
                    LastName = "Well",
                    DateOfBirth = new DateTime(1977, 3, 3),
                    UserName = "HitMan"
                },

            };
        }
    }
}

