﻿using SkillNetworkMVC.Models.Users;

namespace SkillNetworkMVC.ViewModels.Account
{
    public class UserViewModel
    {
        public User User { get; set; }

        public UserViewModel(User user)
        {
            User = user;
        }
    }
}
