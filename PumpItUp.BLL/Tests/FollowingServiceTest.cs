using PumpItUp.DAL.Models;
using NUnit.Framework;

namespace PumpItUp.BLL.Tests
{
    public class FollowingServiceTest
    {
        [Test]
        public void Following_Creation_Should_Set_Correct_Values()
        {
            const long userOneId = 1L;
            const long userFollowedById = 2L;
            var createdAt = DateTime.UtcNow;

            var following = new Following
            {
                FollowerId = userOneId,
                FollowingId = userFollowedById,
                CreatedAt = createdAt,
                UpdatedAt = createdAt
            };

            Assert.That(following.FollowerId, Is.EqualTo(userOneId));
            Assert.That(following.FollowingId, Is.EqualTo(userFollowedById));
            Assert.That(following.CreatedAt, Is.EqualTo(createdAt));
            Assert.That(following.UpdatedAt, Is.EqualTo(createdAt));
        }
    }
}