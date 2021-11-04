using System;

namespace accounts.Model
{
    public class UserWithoutPassword
    {
        public Guid Id { get; set; }
        
        public string Firstname { get; set; }

        public string Middlename { get; set; }
        
        public string Lastname { get; set; }
        
        public string Phone { get; set; }
        
        public string Email { get; set; }

        public DateTimeOffset CreatedAt { get; set; }
        
        public DateTimeOffset ModifiedAt { get; set; }
        
        public string Username { get; set; }
    }
}