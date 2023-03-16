using AM = AutoMapper;
using Model = prod.Models;
using prod.ViewModel;

namespace prod.Profile;

public class MappingProfile : AM.Profile
{
    public MappingProfile()
    {
        CreateMap<Model.Product, ProductViewModel>()
            .ForMember(x => x.Id, opt => opt.MapFrom(src => src.id))
            .ForMember(x => x.productName, opt => opt.MapFrom(src => src.productName));
            // continue .ForMember
        
        CreateMap<ProductViewModel, Model.Product>()
            .ForMember(x => x.id, opt => opt.MapFrom(src => src.Id))
            .ForMember(x => x.productName, opt => opt.MapFrom(src => src.productName));

        CreateMap<Model.Product, ProductRequestViewModel>()
            .ForMember(x => x.productName, opt => opt.MapFrom(src => src.productName));
        
        CreateMap<ProductRequestViewModel, Model.Product>()
            .ForMember(x => x.productName, opt => opt.MapFrom(src => src.productName));
    }
}