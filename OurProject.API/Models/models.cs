using System;
using System.ComponentModel.DataAnnotations;

namespace OurProject.API.Models
{
    public class Event
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
    }

    public class User
    {
        public int Id { get; set; }
        public string personName { get; set; }
        public string personBirth { get; set; }
        public string personMail { get; set; }
    }

}