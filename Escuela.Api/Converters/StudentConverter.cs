using Microsoft.OpenApi.Extensions;
using ApiModel = Escuela.Api.Models;
using DataModel = DataAccess.Model;

namespace Escuela.Api.Converters
{
    public class StudentConverter
    {
        public static ApiModel.Student EntityToApiModel (DataModel.Student dataStudent)
        {
            var apiModelStudent = new ApiModel.Student();

            //Address conversion
            apiModelStudent.Address.City = dataStudent.Person.Address.City;
            apiModelStudent.Address.State = dataStudent.Person.Address.State;
            apiModelStudent.Address.StreetAndNumber = dataStudent.Person.Address.StreetAndNumber;
            apiModelStudent.Address.ZipCode = dataStudent.Person.Address.ZipCode;

            //Person conversion
            apiModelStudent.Birthday = dataStudent.Person.Birthday;
            apiModelStudent.FirstName = dataStudent.Person.FirstName;
            apiModelStudent.LastName = dataStudent.Person.LastName;
            apiModelStudent.MiddleName = dataStudent.Person.MiddleName;
            apiModelStudent.Phone = dataStudent.Person.Phone;

            //Major
            apiModelStudent.MajorId = (ApiModel.Major)dataStudent.MajorId;
            apiModelStudent.MajorName = ((ApiModel.Major)dataStudent.MajorId).GetDisplayName();

            return apiModelStudent;
        }

        public static DataModel.Student ApiToEntityModel(ApiModel.Student apiStudent)
        {
            var address = new DataModel.Address();
            var dataStudent = new DataModel.Student();
            var dataPerson = new DataModel.Person();

            //address
            address.City = apiStudent.Address.City;
            address.State = apiStudent.Address.State;
            address.StreetAndNumber = apiStudent.Address.StreetAndNumber;
            address.ZipCode = apiStudent.Address.ZipCode;

            //person entity
            dataPerson.Birthday = apiStudent.Birthday;
            dataPerson.FirstName = apiStudent.FirstName;
            dataPerson.LastName = apiStudent.LastName;
            dataPerson.MiddleName = apiStudent.MiddleName;
            dataPerson.Phone = apiStudent.Phone;

            //Major
            dataStudent.MajorId = (long)apiStudent.MajorId;

            dataPerson.Address = address;
            dataStudent.Person = dataPerson;

            return dataStudent;

        }
    }
}
