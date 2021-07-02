/*
    This class uses the AutoMapper to help remove some boilerplate whenver a user edits an Activity.
    Using this, we will not have to initialize every single field.
    AutoMapper dependency will handle all of that for us.
*/

using AutoMapper;
using Domain;

namespace Application.Core
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            // We are mapping an Activity to another Activity
            // because when we are editing, we will be returning the same Activity regardless.
            CreateMap<Activity, Activity>();
        }
    }
}