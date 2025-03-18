using System;
using PumpItUp.DAL.Models;
using Xunit;

namespace PumpItUp.Tests
{
    public class FollowingTests
    {
        [Fact]
        public void Following_Creation_Should_Set_Correct_Values()
        {
            var userOneId = 1L;
            var userFollowedById = 2L;
            var createdAt = DateTime.UtcNow;

            var following = new Following
            {
                follower = userOneId,
                following = userFollowedById,
                CreatedAt = createdAt,
                UpdatedAt = createdAt
            };

            Assert.Equal(userOneId, following.follower);
            Assert.Equal(userFollowedById, following.following);
            Assert.Equal(createdAt, following.CreatedAt);
            Assert.Equal(createdAt, following.UpdatedAt);
        }
    }
}
