using ILC.BL.Common.Mapping;
using ILC.BL.Models.Admin.Common;
using ILC.Domain.DBEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILC.BL.Models.Admin.HomeSection.Inquirys
{
    public class InquiryVM
    {
        public InquiryVM(Inquiry model)
        {
            Id = model.Id;
            Name = model.Name;
            LastName = model.LastName;
            Country = model.Country;
            City = model.City;
            Email = model.Email;
            CountryCode = model.CountryCode;
            Phone = model.Phone;
            Subject = model.Subject;
            Message = model.Message;
            CreationDate = model.CreationDate;
            ProductId = model.ProductId;
            IsSeen = model.IsSeen; 
        }
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? LastName { get; set; } 
        public string? Country { get; set; }  
        public string? City { get; set; }
        public string? Email { get; set; }
        public string? CountryCode { get; set; }
        public string? Phone { get; set; }
        public string? Subject { get; set; }
        public string? Message { get; set; }
        public DateTimeOffset? CreationDate { get; set; }
        public int? ProductId { get; set; }
        public bool IsSeen { get; set; }
    }
} 