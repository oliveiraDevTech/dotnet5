using Application.Cadastro.Mappers;
using AutoMapper;
using System.Collections.Generic;

namespace Application.AutoMapper
{
    public static class AutoMapperConfig
    {
        public static IEnumerable<Profile> GetAssemblyProfiles()
        {
            return new Profile[]
            {
                new CadastroDomainToDtoMapping()
            };
        }
    }
}