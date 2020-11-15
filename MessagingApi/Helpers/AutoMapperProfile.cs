using AutoMapper;
using MessagingApi.Entities;
using MessagingApi.Models;

namespace MessagingApi.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserModel>();
            CreateMap<RegisterModel, User>();
            CreateMap<UpdateModel, User>();
            CreateMap<TokenModel, Token>();
            CreateMap<MessageSaveModel, Message>();
        }
    }
}
