/*using System;
using OurProject.API.Models;

namespace OurProject.API.Controllers
{
    public class controllerDTO
    {
        public string personName { get; set; }
        public string personMail { get; set; }
        public string personBirth { get; set; }

        public string eventName { get; set; }
        public string eventDate { get; set; }
        public string eventDescription { get; set; }
        public int eventMinAge { get; set; }
        public int eventMaxAge { get; set; }
        public bool eventEnroll { get; set; }
        public string eventEnrollDate { get; set; }
        public int eventCounter { get; set; }
        public string eventPersonList { get; set; }

        public class Person ToPerson() => new Person
        {
            personName = this.personName,
            personMail = this.personMail,
            personBirth = this.personBirth
        };

        public class Event ToEvent() => new Event
        {
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
}*/