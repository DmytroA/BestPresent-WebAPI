﻿using AutoMapper.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BestPresent.WebAPI.Models
{
    [MapsFrom(typeof(Country))]
    public class CountriesModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public byte[] ImageData { get; set; }
        public string ImagePath { get; set; }
    }
}