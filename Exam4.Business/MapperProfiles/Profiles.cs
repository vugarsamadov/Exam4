using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Exam4.Business.Models;
using Exam4.Core.Entities;
using Microsoft.AspNetCore.Hosting;

namespace Exam4.Business.MapperProfiles
{
    public class Profiles : Profile
    {
        public Profiles(IWebHostEnvironment env)
        {

            CreateMap<Instructor, InstructorVM>()
                .ForMember(c => c.SpecializedArea,opt => opt.MapFrom(m=>m.SpecializedArea.Name));

            CreateMap<CreateInstructorVM, Instructor>()
                .ForMember(c=>c.ProfileImageUrl,opt=>opt.Ignore())
                .AfterMap(async (src,dest)=>
                {
                    if (src.ProfileImage != null)
                        dest.ProfileImageUrl = await src.ProfileImage.SaveAndRetrievePathAsync(env);
                });

            CreateMap<UpdateInstructorVM, Instructor>()
                .ForMember(c => c.ProfileImageUrl, opt => opt.Ignore())
                .AfterMap(async (src, dest) =>
                {
                    if (src.ProfileImage != null)
                        dest.ProfileImageUrl = await src.ProfileImage.SaveAndRetrievePathAsync(env);
                });

            CreateMap<InstructorVM, UpdateInstructorVM>();

        }
    }
}
