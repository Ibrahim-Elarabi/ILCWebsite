﻿using ILC.BL.Models.Admin.HomeSection.AboutUs;
using ILC.BL.Models.Admin.HomeSection.Agent;
using ILC.BL.Models.Admin.HomeSection.Blog;
using ILC.BL.Models.Admin.HomeSection.Product;
using ILC.BL.Models.Admin.HomeSection.Service;
using ILC.BL.Models.Admin.HomeSection.Slider;
using ILC.Domain.DBEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILC.BL.Models.WebSite.Home
{
    public class HomePageVM
    {
        public SliderHomeVM Silder { get; set; }
        public AboutUsHomeVM AboutUS { get; set; }
        public List<ServiceHomeVM> Services { get; set; } = new List<ServiceHomeVM>();
        public List<ProductHomeVM> Products { get; set; } = new List<ProductHomeVM>();
        public List<AgentHomeVM> Agents { get; set; } = new List<AgentHomeVM>();
        public List<BlogHomeVM> Blogs { get; set; } = new List<BlogHomeVM>();
    }
}
