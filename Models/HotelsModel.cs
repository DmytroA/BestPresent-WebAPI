using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper.Attributes;

namespace BestPresent.WebAPI.Models
{
    [MapsFrom(typeof(Hotel))]
    public class HotelsModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte[] ImageData { get; set; }
    }
}