using AutoMapper;
using BusinessLibrary.MapperProfiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerrariumGame.WcfService.Host.Profiles
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
