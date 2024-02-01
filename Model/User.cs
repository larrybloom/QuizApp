﻿using Microsoft.AspNetCore.Identity;

namespace quiz_app.Model
{
    public class User
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; }
    }
}
