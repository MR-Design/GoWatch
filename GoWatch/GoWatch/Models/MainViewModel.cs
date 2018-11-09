using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoWatch.Models
{
    public class MainViewModel
    {
        public Event events { get; set; }
        public List <Event> AllEvents { get; set; }

        public Fan fans { get; set; }
        public List<Fan> AllFans { get; set; }

        public FriendRequest friendRequests { get; set; }
        public List<FriendRequest> AllFriendRequests { get; set; }

        public GuestList guestLists { get; set; }
        public List<GuestList> AllGuestList { get; set; }

    }
}
