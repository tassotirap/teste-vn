﻿namespace ViajaNet.WebAccess.Application.AutoMapper
{
    using global::AutoMapper;
    using System;
    using ViajaNet.WebAccess.Application.ViewModel;
    using ViajaNet.WebAccess.Domain.Events;

    public class ViewModelMappingProfile : Profile
    {
        public ViewModelMappingProfile()
        {
            CreateMap<WebAccessViewModel, WebAccessRegister>()
                .ConstructUsing(c => new WebAccessRegister(new Domain.Models.WebAccess
                {
                    Url = c.Url,
                    Data = DateTime.Now,
                    Location = c.Location,
                    IP = c.IP,
                    Browser = c.Browser
                }));
        }
    }
}
