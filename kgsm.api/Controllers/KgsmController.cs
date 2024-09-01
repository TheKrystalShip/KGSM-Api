using Microsoft.AspNetCore.Mvc;

namespace TheKrystalShip.KGSM.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class KgsmController : ControllerBase
{
    private readonly ILogger<KgsmController> _logger;
    private readonly KgsmInterop _interop;

    public KgsmController(ILogger<KgsmController> logger, KgsmInterop kgsmInterop)
    {
        _logger = logger;
        _interop = kgsmInterop;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult Get()
    {
        KgsmResult result = _interop.AdHoc("--version");

        if (result.ExitCode == 0)
            return Ok(result.Stdout ?? result.Stderr);

        return NotFound();
    }

    [HttpGet("ip")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult GetIp()
    {
        KgsmResult result = _interop.GetIp();

        if (result.ExitCode == 0)
            return Ok(result.Stdout ?? result.Stderr);

        return StatusCode(StatusCodes.Status500InternalServerError);
    }

    [HttpGet("install/{blueprint}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult Install(string blueprint)
    {
        KgsmResult result = _interop.AdHoc($"--install {blueprint}");

        if (result.ExitCode == 0)
        {
            string? installDirResponse = result.Stderr;
            if (installDirResponse is null)
                return StatusCode(StatusCodes.Status500InternalServerError);

            return Created();
        }

        return StatusCode(StatusCodes.Status500InternalServerError);
    }

    [HttpGet("uninstall/{instance}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult Uninstall(string instance)
    {
        KgsmResult result = _interop.AdHoc($"--uninstall {instance}");

        if (result.ExitCode == 0)
            return Ok();

        return StatusCode(StatusCodes.Status500InternalServerError);
    }
}
