using Microsoft.AspNetCore.Mvc;

namespace TheKrystalShip.KGSM.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class InstancesController : ControllerBase
{
    private readonly ILogger<InstancesController> _logger;
    private readonly KgsmInterop _interop;

    public InstancesController(ILogger<InstancesController> logger, KgsmInterop kgsmInterop)
    {
        _logger = logger;
        _interop = kgsmInterop;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult Get()
    {
        var result = _interop.GetInstances();

        if (result.ExitCode == 0)
            return Ok(result.Stdout ?? result.Stderr);

        return StatusCode(StatusCodes.Status500InternalServerError);
    }

    [HttpGet("{instance}/logs")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult Logs(string instance)
    {
        KgsmResult result = _interop.GetLogs(instance);

        if (result.ExitCode == 0)
            return Ok(result.Stdout ?? result.Stderr);

        return StatusCode(StatusCodes.Status500InternalServerError);
    }

    [HttpGet("{instance}/status")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult Status(string instance)
    {
        KgsmResult result = _interop.Status(instance);

        if (result.ExitCode == 0)
            return Ok(result.Stdout ?? result.Stderr);

        return StatusCode(StatusCodes.Status500InternalServerError);
    }

    [HttpGet("{instance}/info")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult Info(string instance)
    {
        KgsmResult result = _interop.Info(instance);

        if (result.ExitCode == 0)
            return Ok(result.Stdout ?? result.Stderr);

        return StatusCode(StatusCodes.Status500InternalServerError);
    }

    [HttpGet("{instance}/is-active")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult IsActive(string instance)
    {
        KgsmResult result = _interop.IsActive(instance);

        if (result.ExitCode == 0)
            return Ok(result.Stdout ?? result.Stderr);

        return StatusCode(StatusCodes.Status500InternalServerError);
    }

    [HttpPost("{instance}/start")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult Start(string instance)
    {
        KgsmResult result = _interop.Start(instance);

        if (result.ExitCode == 0)
            return Ok(result.Stdout ?? result.Stderr);

        return StatusCode(StatusCodes.Status500InternalServerError);
    }

    [HttpPost("{instance}/stop")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult Stop(string instance)
    {
        KgsmResult result = _interop.Stop(instance);

        if (result.ExitCode == 0)
            return Ok(result.Stdout ?? result.Stderr);

        return StatusCode(StatusCodes.Status500InternalServerError);
    }

    [HttpPost("{instance}/restart")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult Restart(string instance)
    {
        KgsmResult result = _interop.Restart(instance);

        if (result.ExitCode == 0)
            return Ok(result.Stdout ?? result.Stderr);

        return StatusCode(StatusCodes.Status500InternalServerError);
    }

    [HttpGet("{instance}/version")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult Version(string instance)
    {
        KgsmResult result = _interop.AdHoc($"-i {instance} --version");

        if (result.ExitCode == 0)
            return Ok(result.Stdout ?? result.Stderr);

        return StatusCode(StatusCodes.Status500InternalServerError);
    }

    [HttpGet("{instance}/check-update")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult CheckUpdate(string instance)
    {
        KgsmResult result = _interop.AdHoc($"-i {instance} --check-update");

        if (result.ExitCode == 0)
            return Ok(result.Stdout ?? result.Stderr);

        return StatusCode(StatusCodes.Status500InternalServerError);
    }

    [HttpPost("{instance}/update")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult Update(string instance)
    {
        KgsmResult result = _interop.AdHoc($"-i {instance} --update");

        if (result.ExitCode == 0)
            return Ok(result.Stdout ?? result.Stderr);

        return StatusCode(StatusCodes.Status500InternalServerError);
    }

    [HttpPost("{instance}/create-backup")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult CreateBackup(string instance)
    {
        KgsmResult result = _interop.AdHoc($"-i {instance} --create-backup");

        if (result.ExitCode == 0)
            return Ok(result.Stdout ?? result.Stderr);

        return StatusCode(StatusCodes.Status500InternalServerError);
    }

    [HttpPost("{instance}/restore-backup/{backup}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult RestoreBackup(string instance, string backup)
    {
        KgsmResult result = _interop.AdHoc($"-i {instance} --restore-backup {backup}");

        if (result.ExitCode == 0)
            return Ok(result.Stdout ?? result.Stderr);

        return StatusCode(StatusCodes.Status500InternalServerError);
    }
}

