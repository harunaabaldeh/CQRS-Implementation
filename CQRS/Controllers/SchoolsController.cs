using CQRS.Features.Schools.Commands;
using CQRS.Features.Schools.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRS.Controllers
{
    public class SchoolsController : Controller
    {
        private readonly IMediator _mediator;
        public SchoolsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _mediator.Send(new GetAllSchoolsQuery()));
        }

        
        public async Task<IActionResult> Details(int id)
        {
            return View(await _mediator.Send(new GetSchoolByIdQuery() { Id = id }));
        }

        
        // Get Create
        public IActionResult Create()
        {
            return View();
        }
        // Post Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateSchoolCommand command)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _mediator.Send(command);
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Unable to save changes.");
            }
            return View(command);
        }

        // Get Edit
        public async Task<IActionResult> Edit(int id)
        {
            return View(await _mediator.Send(new GetSchoolByIdQuery() { Id = id }));
        }

        // Post Edit 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, UpdateSchoolCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            try
            {
                if (ModelState.IsValid)
                {
                    await _mediator.Send(command);
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Unable to save changes.");
            }
            return View(command);
        }

        // Get Delete
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _mediator.Send(new DeleteSchoolCommand() { Id = id });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Unable to delete. ");
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
