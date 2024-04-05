using Petfolio.Communication.Responses;

namespace Petfolio.Application.UseCases.Pet.GetById;

public class GetPetByIdUseCase
{
    public ResponsePetJson Execute(int id)
    {
        return new ResponsePetJson
        {
            Id = id,
            Name = "Aninha",
            Type = Communication.Enums.PetType.Cat,
            Birthday = new DateTime(year: 2019, month: 04, day: 20),
        };
    }
}
