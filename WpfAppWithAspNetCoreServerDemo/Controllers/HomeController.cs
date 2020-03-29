using Microsoft.AspNetCore.Mvc;
using WpfAppWithAspNetCoreServerDemo.ViewModels;

namespace WpfAppWithAspNetCoreServerDemo.Controllers {
    public class HomeController : Controller {
        private readonly MainWindowViewModel viewModel;

        public HomeController(MainWindowViewModel viewModel) {
            this.viewModel = viewModel;
        }

        [Route("/")]
        [HttpGet]
        public IActionResult Index() {
            return Ok("It works!");
        }

        [Route("/setText")]
        [HttpGet]
        public IActionResult SetText([FromQuery] string text) {
            this.viewModel.Text = text;
            return Ok();
        }
    }
}
