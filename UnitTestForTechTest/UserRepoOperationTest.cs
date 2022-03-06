using NUnit.Framework;
using Interview.RepoCore;
using Interview.Model;
using System.Collections.Generic;
using System.Linq;

namespace UnitTestForTechTest
{
    [TestFixture]
    public class UserRepoOperationTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TrySavingUserToRepo_01()
        {
            Repository<User> userRepository = new Repository<User>();

            User userAlex = new User { Id = 1, Gender = "Male", UserName = "Alex" };
            User userLaura = new User { Id = 2, Gender = "Female", UserName = "Laura" };

            userRepository.Save(userAlex);
            userRepository.Save(userLaura);

            var userList = userRepository.All();

            Assert.IsTrue(((IEnumerable<User>)userList).Contains(userLaura));
        }

        [Test]
        public void TryDeletingUserFromRepo_01()
        {
            Repository<User> userRepository = new Repository<User>();

            User userAlex = new User { Id = 1, Gender = "Male", UserName = "Alex" };
            User userLaura = new User { Id = 2, Gender = "Female", UserName = "Laura" };

            userRepository.Save(userAlex);
            userRepository.Save(userLaura);

            userRepository.Delete(userAlex.Id);

            var userList = userRepository.All();

            Assert.IsFalse(((IEnumerable<User>)userList).Contains(userAlex));
        }

        [Test]
        public void TryDeletingUserFromRepo_Negative_01()
        {
            Repository<User> userRepository = new Repository<User>();

            User userAlex = new User { Id = 1, Gender = "Male", UserName = "Alex" };
            User userLaura = new User { Id = 2, Gender = "Female", UserName = "Laura" };

            User userSam = new User { Id = 2, Gender = "Male", UserName = "Sam" }; // Not present in Repo

            userRepository.Save(userAlex);
            userRepository.Save(userLaura);

            userRepository.Delete(userSam.Id);

            var userList = userRepository.All();

            Assert.IsTrue(userList.Count() == 2);
        }

        [Test]
        public void TryFindingUserFromRepo_01()
        {
            Repository<User> userRepository = new Repository<User>();

            User userAlex = new User { Id = 1, Gender = "Male", UserName = "Alex" };
            User userLaura = new User { Id = 2, Gender = "Female", UserName = "Laura" };

            userRepository.Save(userAlex);
            userRepository.Save(userLaura);

            var findUser = userRepository.FindById(userAlex.Id);

            Assert.IsNotNull(findUser);
        }

        [Test]
        public void TryFindingUserFromRepo_NegativeTest_01()
        {
            Repository<User> userRepository = new Repository<User>();

            User userAlex = new User { Id = 1, Gender = "Male", UserName = "Alex" };
            User userLaura = new User { Id = 2, Gender = "Female", UserName = "Laura" };

            User userSam = new User { Id = 2, Gender = "Male", UserName = "Sam" }; // Not present in Repo

            userRepository.Save(userAlex);
            userRepository.Save(userLaura);

            var findUser = userRepository.FindById(userSam.Id);

            Assert.IsNull(findUser);
        }

        [Test]
        public void TryFetchingAllUsers()
        {
            User userAlex = new User { Id = 1, Gender = "Male", UserName = "Alex" };
            User userLaura = new User { Id = 2, Gender = "Female", UserName = "Laura" };
            User userSam = new User { Id = 2, Gender = "Male", UserName = "Sam" };

            Repository<User> userRepository = new Repository<User>();
            userRepository.Save(userAlex);
            userRepository.Save(userLaura);
            userRepository.Save(userSam);

            Assert.IsTrue(userRepository.All().Count() == 3);
        }
    }
}
