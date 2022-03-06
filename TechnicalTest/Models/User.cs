using System;

namespace Interview.Model
{
    /// <summary>
    /// Represent User repository type object
    /// </summary>
    public class User : IStoreable
    {
        public IComparable Id { get; set; }
        public string UserName { get; set; }
        public string Gender { get; set; }

        public User()
        {

        }
    }
}
