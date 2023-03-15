using AM = AutoMapper;
using model = prod.Models;
using prod.ViewModel;

namespace prod.Profile;

public class MappingProfile : AM.Profile
{
    public MappingProfile()
    {
        CreateMap<model.Product, ProductViewModel>()
            .ForMember(x => x.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(x => x.productName, opt => opt.MapFrom(src => src.productName));
            // continue .ForMember
        
        CreateMap<ProductViewModel, model.Product>()
            .ForMember(x => x.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(x => x.productName, opt => opt.MapFrom(src => src.productName));
    }
}