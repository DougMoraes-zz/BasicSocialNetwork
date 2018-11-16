using Data.Repositories.ProfileRepositories;
using DomainModel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainService
{

    class CountryStateService
    {
        private CountryStateRepository repository;

        public CountryStateService(CountryStateRepository _repository)
        {
            repository = _repository;
        }

        public void CreateCountry(Country country)
        {
            repository.CreateCountry(country);
        }

        public void CreateState(State state)
        {
            repository.CreateState(state);
        }

        public Country GetCountry(Guid? id)
        {
            return repository.GetCountry(id);
        }

        public State GetState(Guid? id)
        {
            return repository.GetState(id);
        }


        public void RemoveState(Guid id)
        {
            repository.DeleteCountry(id);
        }

        public void RemoveCountry(Guid id)
        {
            repository.DeleteState(id);
        }

        public void UpdateCountry(Country country)
        {
            repository.UpdateCountry(country);
        }

        public void UpdateState(State state)
        {
            repository.UpdateState(state);
        }
    }
}
