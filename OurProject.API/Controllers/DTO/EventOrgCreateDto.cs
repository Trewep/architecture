using System;
using OurProject.API.Models;

namespace OurProject.API.Controllers
{
    public class CreateUser
    {
        public Guid? Id { get; set; }
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

    public class CreateEvent
    {
        public string eventName { get; set; }
        public string eventDate { get; set; }
        public string eventDescription { get; set; }
        public int eventMinAge { get; set; }
        public int eventMaxAge { get; set; }
        public bool eventEnroll { get; set; }
        public string eventEnrollDate { get; set; }
        public int eventCounter { get; set; }
        public string eventPersonList { get; set; }
        public Event ToEvent() => new Event
        {
            Id = this.Id,
            eventName = this.eventName,
            eventDate = this.eventDate,
            eventDescription = this.eventDescription,
            eventMinAge = this.eventMinAge,
            eventMaxAge = this.eventMaxAge,
            eventEnroll = this.eventEnroll,
            eventEnrollDate = this.eventEnrollDate,
            eventCounter = this.eventCounter,
            eventPersonList = this.eventPersonList,
        };
    }
}