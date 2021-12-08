using BatchApp.Models;
using AutoMapper;

namespace BatchApp.Mapper
{
    public class BatchMappings:Profile
    { 
        public BatchMappings()
        {
            CreateMap<BatchModel, BatchModel>().ReverseMap();

            CreateMap<ACL, ACL>().ReverseMap();   

            CreateMap<Atribute,Atribute>().ReverseMap();
        }
    }
}
