using AutoMapper;
using item_api.Models;
using item_api.DTOs;

namespace item_api.Mappings
{
    public class ItemProfile : Profile
    {
        public ItemProfile()
        {
            CreateMap<Item, ItemDto>();

            CreateMap<CreateItemDto, Item>();

            CreateMap<UpdateItemDto, Item>();
        }
    }
}
