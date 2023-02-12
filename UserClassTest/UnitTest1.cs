namespace UserClassTest
{
    public class Tests
    {
        private UserRepository _userRepository;

        [SetUp]
        public void SetUp()
        {
            _userRepository = new UserRepository();
        }

        [Test]
        public void AddUser_AddsUserToRepository()
        {
            var user = new User("John", 30);

            _userRepository.AddUser(user);

            var users = _userRepository._users;

            Assert.That(users.Count, Is.EqualTo(1));
            Assert.That(users.First().Name, Is.EqualTo("John"));
            Assert.That(users.First().Age, Is.EqualTo(30));
        }

        [Test]
        public void RemoveUser_RemovesUserFromRepository()
        {
            var user = new User("John", 30);
            _userRepository.AddUser(user);

            _userRepository.RemoveUser(user);

            var users = _userRepository._users;

            Assert.That(users.Count, Is.EqualTo(0));
        }

        [Test]
        public void UpdateUser_UpdatesUserInRepository()
        {
            var user = new User("John", 30);
            _userRepository.AddUser(user);

            _userRepository.UpdateUser(user, "Jane", 40);

            var users = _userRepository._users;

            Assert.That(users.Count, Is.EqualTo(1));
            Assert.That(users.First().Name, Is.EqualTo("Jane"));
            Assert.That(users.First().Age, Is.EqualTo(40));
        }
    }
}