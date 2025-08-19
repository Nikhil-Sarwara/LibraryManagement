using AutoMapper;
using LibraryManagement.Application.DTOs;
using LibraryManagement.Application.DTOs.LibraryManagement.Application.DTOs;
using LibraryManagement.Domain.Entities;
using LibraryManagement.Domain.Enums;
using System.Text.Json;

namespace LibraryManagement.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Book mappings
            CreateMap<Book, BookDto>()
                .ForMember(dest => dest.Authors, opt => opt.MapFrom(src =>
                    src.Authors.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList()))
                .ForMember(dest => dest.Genres, opt => opt.MapFrom(src =>
                    src.Genres.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList()))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()));

            CreateMap<CreateBookRequest, Book>()
                .ForMember(dest => dest.AvailableCopies, opt => opt.MapFrom(src => src.TotalCopies))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => BookStatus.Available));

            CreateMap<UpdateBookRequest, Book>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            // User mappings
            CreateMap<User, UserDto>()
                .ForMember(dest => dest.PreferredGenres, opt => opt.MapFrom(src =>
                    string.IsNullOrEmpty(src.PreferredGenres) ? new List<string>() :
                    src.PreferredGenres.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList()))
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role.ToString()));

            CreateMap<CreateUserRequest, User>()
                .ForMember(dest => dest.PreferredGenres, opt => opt.MapFrom(src =>
                    string.Join(",", src.PreferredGenres)))
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src =>
                    Enum.Parse<UserRole>(src.Role, true)));

            CreateMap<UpdateUserRequest, User>()
                .ForMember(dest => dest.PreferredGenres, opt => opt.MapFrom(src =>
                    src.PreferredGenres != null ? string.Join(",", src.PreferredGenres) : null))
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
