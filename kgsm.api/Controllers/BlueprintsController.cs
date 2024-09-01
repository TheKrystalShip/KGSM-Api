using Microsoft.AspNetCore.Mvc;

namespace TheKrystalShip.KGSM.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class BlueprintsController : ControllerBase
{
    private readonly ILogger<BlueprintsController> _logger;
    private readonly KgsmInterop _interop;

    public BlueprintsController(ILogger<BlueprintsController> logger, KgsmInterop kgsmInterop)
    {
        _logger = logger;
        _interop = kgsmInterop;
    }

    [HttpGet]
    public ActionResult Get()
    {
        KgsmResult result = _interop.GetBlueprints();

        if (result.ExitCode == 0)
            return Ok(result.Stdout ?? result.Stderr);

        return StatusCode(StatusCodes.Status500InternalServerError);
    }
}
