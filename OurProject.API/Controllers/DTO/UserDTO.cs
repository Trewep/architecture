//OurProject
using OurProject.API.Domains;

//System
using System;

//Namespace
namespace OurProject.API.Controllers
{
    public class CreateUser
    {
        public int Id { get; set; }
        public string personName { get; set; }
        public string personMail { get; set; }
        public string personBirth { get; set; }
        public User ToUser() => new User
        {
            Id = this.Id,
            personName = this.personName,
            personMail = this.personMail,
            personBirth = this.personBirth
        };
    }

    public class ReadUser
    {
        public int Id { get; set; }
        public string personName { get; set; }
        public string personMail { get; set; }
        public string personBirth { get; set; }

        public static ReadUser FromModel(User User) => new ReadUser
        {
            Id = User.Id,
            personName = User.personName,
            personMail = User.personMail,
            personBirth = User.personBirth,
        };
    }
}