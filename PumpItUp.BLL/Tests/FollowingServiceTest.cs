using PumpItUp.DAL.Models;
using Xunit;

namespace PumpItUp.BLL.Tests
{
    public class FollowingServiceTest
    {
        [Fact]
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

            Assert.Equal(userOneId, following.FollowerId);
            Assert.Equal(userFollowedById, following.FollowingId);
            Assert.Equal(createdAt, following.CreatedAt);
            Assert.Equal(createdAt, following.UpdatedAt);
        }
    }
}