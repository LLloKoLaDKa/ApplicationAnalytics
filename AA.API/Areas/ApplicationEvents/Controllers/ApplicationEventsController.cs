using AA.Domain.Applications.Events;
using AA.Services.Applications.Events;
using Microsoft.AspNetCore.Mvc;
using System;

namespace AA.API.Areas.ApplicationEvents.Controllers
{
    public class ApplicationEventsController : Controller
    {
        private readonly ApplicationEventsService _applicationsService;

        public ApplicationEventsController()
        {
            _applicationsService = new("Server=postgres;Username=aa_admin;Database=analytics;Port=5432;Password=95nJJara@x~Bs");
        }

        [HttpPost("Events/Save")]
        public void SaveApplicationEvent([FromBody] ApplicationEventBlank applicationEvent)
        {
            _applicationsService.SaveEvent(applicationEvent);
        }
    }
}
