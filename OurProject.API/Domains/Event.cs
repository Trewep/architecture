//System
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

//Namespace
namespace OurProject.API.Domains
{
    public class Event
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
    }
}