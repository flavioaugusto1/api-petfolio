﻿using Microsoft.AspNetCore.Mvc;
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
    public IActionResult Register([FromBody] RequestPetJson request)
    {
        var useCase = new RegisterPetUseCase();
        var response = useCase.Execute(request);

        return Created(string.Empty, response);
    }

    [HttpPut("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult Update(int id, [FromBody] RequestPetJson request)
    {
        var useCase = new UpdatePetUseCase();
        useCase.Execute(id, request);

        return NoContent();
    }
}