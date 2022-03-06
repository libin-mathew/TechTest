using NUnit.Framework;
using Interview.RepoCore;
using Interview.Model;

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

        }
    }
}
