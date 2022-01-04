//OurProject
using OurProject.API.Domains;
using OurProject.API.Ports;
using OurProject.API.Infra;

//System
using System;

//Namespace
namespace OurProject.API.Controllers
{
    public class CreateEvent
    {
        public int Id { get; set; }
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

    public class ReadEvent
    {
        public int Id { get; set; }
        public string eventName { get; set; }
        public string eventDate { get; set; }
        public string eventDescription { get; set; }
        public int eventMinAge { get; set; }
        public int eventMaxAge { get; set; }
        public bool eventEnroll { get; set; }
        public string eventEnrollDate { get; set; }
        public int eventCounter { get; set; }
        public string eventPersonList { get; set; }
        public static ReadEvent FromModel(Event event_) => new ReadEvent
        {
            Id = event_.Id,
            eventName = event_.eventName,
            eventDate = event_.eventDate,
            eventDescription = event_.eventDescription,
            eventMinAge = event_.eventMinAge,
            eventMaxAge = event_.eventMaxAge,
            eventEnroll = event_.eventEnroll,
            eventEnrollDate = event_.eventEnrollDate,
            eventCounter = event_.eventCounter,
            eventPersonList = event_.eventPersonList,
        };
    }
}