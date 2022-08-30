using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Core.Common
{
    public interface IMapFrom<T>
    {
        public void Mapping(Profile profile)
            => profile.CreateMap(typeof(T), GetType());
    }

}
