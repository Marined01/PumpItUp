using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PumpItUp.DAL.DTOs
{
    public class FollowingRequest
    {
        public long Id { get; set; }
        public long FollowerId { get; set; }
        public long FollowingId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
