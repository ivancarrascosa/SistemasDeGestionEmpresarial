using Domain.Entities;
using Domain.Interfaces;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Domain.UseCases
{
    internal class DefaultUseCase : IUseCase
    {
        private readonly IRepository _repository;

        public DefaultUseCase(IRepository repository)
        {
            _repository = repository;
        }
        public Persona[] getListaPersonas()
        {
            return _repository.getListaPersonas();
        }
    }
}
