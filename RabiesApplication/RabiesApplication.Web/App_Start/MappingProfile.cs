﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using RabiesApplication.Models;
using RabiesApplication.Web.ViewModels;

namespace RabiesApplication.Web.App_Start
{
    class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Bite, BiteFormViewModel>();
            CreateMap<BiteFormViewModel, Bite>();

            CreateMap<HumanVictim, HumanVictimFormViewModel>();
            CreateMap<HumanVictimFormViewModel, HumanVictim>();

            CreateMap<Animal, AnimalFormViewModel>().ForMember(s => s.Species, s => s.Ignore()).ForMember(b => b.Breed,b => b.Ignore())
                .ForMember(o => o.AnimalOwner,o => o.Ignore())
                .ForMember(v => v.Vet, v => v.Ignore());
            CreateMap<AnimalFormViewModel, Animal>();

            CreateMap<AnimalOwner, AnimalOwnerFormViewModel>();
            CreateMap<AnimalOwnerFormViewModel, AnimalOwner>();

            CreateMap<Vet, VetFormViewModel>();
            CreateMap<VetFormViewModel, Vet>();

            //CreateMap<AnimalFormViewModel,Animal>();
            //CreateMap<Animal,AnimalFormViewModel>();
        }
    }
}
