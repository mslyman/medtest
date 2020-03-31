using Dto;
using DBModel;

public class AutoMapperConfig : AutoMapper.Profile
{
    public AutoMapperConfig()
    {
        CreateMap<User, UserDto>().ReverseMap();
    }
}