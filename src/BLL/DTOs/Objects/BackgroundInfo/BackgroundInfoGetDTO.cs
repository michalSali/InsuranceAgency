using BLL.DTOs.People.Client;
using System;

namespace BLL.DTOs.Objects.BackgroundInfo
{
    /// <summary>
    /// DTO used to get background info
    /// </summary>
    public class BackgroundInfoGetDTO : DTOBase
    {
        public ClientGetDTO Client { get; set; }

        public string Text { get; set; }

        public DateTime Date { get; set; }
    }
}