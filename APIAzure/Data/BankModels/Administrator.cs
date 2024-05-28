using System;
using System.Collections.Generic;

namespace APIAzure.Data.BankModels
{
    public partial class Administrator
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Pwd { get; set; } = null!;
        public string AdminType { get; set; } = null!;
        public DateTime RegDate { get; set; }
    }
}
