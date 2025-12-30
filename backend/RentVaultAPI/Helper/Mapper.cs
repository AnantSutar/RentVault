using AutoMapper;
using RentVaultAPI.DTOs.Responses;
using RentVaultAPI.Models;


namespace RentVaultAPI.Helper
{
    public class Mapper: Profile
    {
        public Mapper()
        {
            CreateMap<User, UserDTO>();
        }
    }
}
