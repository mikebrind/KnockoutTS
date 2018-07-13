using System;
using System.Collections.Generic;

namespace KnockoutTS.Models
{
    public class WebMail
    {
        public List<Folder> Folders { get; set; } = new List<Folder>();
    }
    public class Mail
    {
        public int Id { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public DateTime Date { get; set; }
        public string Subject { get; set; }
        public string Folder { get; set; }
        public string MessageContent { get; set; }
    }

    public class Folder
    {
        public string Id { get; set; }
        public List<Mail> Mails { get; set; } = new List<Mail>();
    }
}