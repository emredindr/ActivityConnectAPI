﻿namespace ActivityConnect.Entities.ViewModels.UserVM
{
    public class UserLoginOutput
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        //public DateTime BirthDate { get; set; }
        public string Token { get; set; }
    }
}

