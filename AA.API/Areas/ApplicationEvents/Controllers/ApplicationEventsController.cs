using AA.Domain.Applications.Events;
using AA.Services.Applications;
using AA.Services.Applications.Events;
using Microsoft.AspNetCore.Mvc;

namespace AA.API.Areas.ApplicationEvents.Controllers
{
    public class ApplicationEventsController : Controller
    {
        private readonly ApplicationEventsService _applicationsService;

        public ApplicationEventsController()
        {
            _applicationsService = new();
        }

        [HttpPost("Events/Save")]
        public void SaveApplicationEvent([FromBody] ApplicationEventBlank applicationEvent)
        {
            _applicationsService.SaveEvent(applicationEvent);
        }
    }
}
