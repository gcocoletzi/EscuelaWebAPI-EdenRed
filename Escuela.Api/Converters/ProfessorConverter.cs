using ApiModel = Escuela.Api.Models;
using DataModel = DataAccess.Model;

namespace Escuela.Api.Converters
{
    public class ProfessorConverter
    {
        public static ApiModel.Professor EntityToApiModel(DataModel.Professor dataProfessor)
        {
            var apiModelProfessor = new ApiModel.Professor();

            //Address conversion
            apiModelProfessor.Address.City = dataProfessor.Person.Address.City;
            apiModelProfessor.Address.State = dataProfessor.Person.Address.State;
            apiModelProfessor.Address.StreetAndNumber = dataProfessor.Person.Address.StreetAndNumber;
            apiModelProfessor.Address.ZipCode = dataProfessor.Person.Address.ZipCode;

            //Person conversion
            apiModelProfessor.Birthday = dataProfessor.Person.Birthday;
            apiModelProfessor.FirstName = dataProfessor.Person.FirstName;
            apiModelProfessor.LastName = dataProfessor.Person.LastName;
            apiModelProfessor.MiddleName = dataProfessor.Person.MiddleName;
            apiModelProfessor.Phone = dataProfessor.Person.Phone;

            //License
            apiModelProfessor.ProfessionalLicense = dataProfessor.ProfessionalLicense;

            return apiModelProfessor;
        }

        public static DataModel.Professor ApiToEntityModel(ApiModel.Professor apiProfessor)
        {
            var address = new DataModel.Address();
            var dataProfessor = new DataModel.Professor();
            var dataPerson = new DataModel.Person();

            //address
            address.City = apiProfessor.Address.City;
            address.State = apiProfessor.Address.State;
            address.StreetAndNumber = apiProfessor.Address.StreetAndNumber;
            address.ZipCode = apiProfessor.Address.ZipCode;

            //person entity
            dataPerson.Birthday = apiProfessor.Birthday;
            dataPerson.FirstName = apiProfessor.FirstName;
            dataPerson.LastName = apiProfessor.LastName;
            dataPerson.MiddleName = apiProfessor.MiddleName;
            dataPerson.Phone = apiProfessor.Phone;

            //Major
            dataProfessor.ProfessionalLicense = apiProfessor.ProfessionalLicense;

            dataPerson.Address = address;
            dataProfessor.Person = dataPerson;

            return dataProfessor;

        }
    }
}