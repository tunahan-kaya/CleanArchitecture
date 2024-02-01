using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

    public class BaseController:ControllerBase
    {
        private IMediator? _mediator;

    //eğer önceden set edilmişse onu döndür. null ise IOC ortamına bak ve injection yap.
    protected IMediator? Mediator =>
            _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
    }

