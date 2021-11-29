//System
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

//Namespace
namespace OurProject.API.Domains
{
    public class User
    {
        public int Id { get; set; }
        public string personName { get; set; }
        public string personBirth { get; set; }
        public string personMail { get; set; }
    }
}