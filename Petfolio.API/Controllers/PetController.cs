using Microsoft.AspNetCore.Mvc;
using Petfolio.Application.UseCases.Pet.GetAll;
using Petfolio.Application.UseCases.Pet.GetById;
using Petfolio.Application.UseCases.Pet.Register;
using Petfolio.Application.UseCases.Pet.Update;
using Petfolio.Communication.Requests;
using Petfolio.Communication.Responses;

namespace Petfolio.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class PetController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(ResponseRegisteredPetJson), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    public IActionResult Register([FromBody] RequestPetJson request)
    {
        var useCase = new RegisterPetUseCase();
        var response = useCase.Execute(request);

        return Created(string.Empty, response);
    }

    [HttpPut("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    public IActionResult Update(int id, [FromBody] RequestPetJson request)
    {
        var useCase = new UpdatePetUseCase();
        useCase.Execute(id, request);

        return NoContent();
    }

    [HttpGet]
    [ProducesResponseType(typeof(List<ResponseAllPetsJson>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult GetAllPets()
    {
        var useCase = new GetAllPetsUseCase();
        var response = useCase.Execute();

        if(response.Pets.Any())
        {
            return Ok(response);
        }

        return NoContent();
    }

    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(ResponsePetJson), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public IActionResult GetPet(int id)
    {
        var useCase = new GetPetByIdUseCase();
        var response = useCase.Execute(id);

        return Ok(response);
    }
}
