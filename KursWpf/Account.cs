﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KursWpf
{
    public class Account
    {
        public int Id { get; set; }
        public string Login { get; set; }
        private string PasswordHash { get; set; }
        private string Email { get; set; }

        public bool IsBanned { get; set; } = false;

        public Account() {
        }

        public Account(string login, string passwordHash) {
            Login = login;
            PasswordHash = passwordHash;
        }

        public virtual void Play()
        {
            
        }
    }
}
