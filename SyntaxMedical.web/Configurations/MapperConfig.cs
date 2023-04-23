using AutoMapper;
using SyntaxMedical.web.Data;
using SyntaxMedical.web.Models;

namespace SyntaxMedical.web.Configurations
{
    public class MapperConfig:Profile
    {
        public MapperConfig()
        {
            CreateMap<Condition, ConditionVM> ().ReverseMap();
        }
    }
}
