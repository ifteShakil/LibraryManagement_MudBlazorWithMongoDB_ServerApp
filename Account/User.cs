﻿using MongoDB.Bson;

namespace MudBlazorWebApp5.Account
{
    public class User
    {
        public ObjectId Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
