﻿using System;
using System.Collections.Generic;

namespace APIAzure.Data.BankModels
{
    public partial class Client
    {
        public Client()
        {
            Accounts = new HashSet<Account>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public DateTime? RegDate { get; set; }

        public virtual ICollection<Account> Accounts { get; set; }
    }
}
