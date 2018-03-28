using AutoMapper;
using BusinessLibrary.MapperProfiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TerrariumGame.WcfServiceApp
{
    public static class MappingProfile
    {
        public static MapperConfiguration InitializeAutoMapper()
        {
            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ApplicationProfile());
                cfg.AddProfile(new BLProfile());
            });
            return config;
        }
    }
}