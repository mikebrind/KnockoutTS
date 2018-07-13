using KnockoutTS.Models;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using System.IO;
using System.Linq;

namespace KnockoutTS.Services
{
    public interface IMailService
    {
        Folder GetMailByFolder(string folder);
        Mail GetMail(int id);
    }


    public class MailService : IMailService
    {
        IHostingEnvironment _env;
        WebMail webMail;

        public MailService(IHostingEnvironment env)
        {
            _env = env;
            webMail = LoadMail();
        }

        public Folder GetMailByFolder(string folder)
        {
            return webMail.Folders.First(f => f.Id == folder);
        }

        public Mail GetMail(int id)
        {
            var mailItems = webMail.Folders.SelectMany(f => f.Mails);
            return mailItems.Single(m => m.Id == id);
        }

        private WebMail LoadMail()
        {
            var data = File.ReadAllText(Path.Combine(_env.ContentRootPath, "Data", "webmail.json"));
            return JsonConvert.DeserializeObject<WebMail>(data);
        }
    }
}