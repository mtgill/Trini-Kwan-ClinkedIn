using System;

namespace ClinkedIn.Api.Models
{
    public class Enemy
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public DateTime ReleaseDate { get; set; }

    }
}