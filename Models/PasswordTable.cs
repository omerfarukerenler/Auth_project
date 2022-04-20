using System;
using System.Collections.Generic;

#nullable disable

namespace Auth_project.Models
{
    public partial class PasswordTable
    {
        public int Id { get; set; }
        public string SiteName { get; set; }
        public string KullaniciAdi { get; set; }
        public string Sifre { get; set; }
    }
}
