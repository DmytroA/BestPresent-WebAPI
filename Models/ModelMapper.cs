using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper.Attributes;

namespace BestPresent.WebAPI.Models
{
    public static class ModelMapper
    {
        public static void Init()
        {
            typeof(ModelMapper).Assembly.MapTypes();
        }
    }
}