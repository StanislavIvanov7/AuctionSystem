﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionSystem.Core.Models.User
{
    public class AllUsersViewModel
    {
        public string Id { get; set; } = string.Empty;

        
        public string FirstName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;


        public string LastName { get; set; } = string.Empty;

 
    }
}
