using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task.Models;

namespace Task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]


    public class TasksControllers : ControllerBase
    {
        private static List<ModelTask> modelTasks =
                new List<ModelTask>();

        [HttpGet]
        public ActionResult <List<ModelTask>> SearchTasks()
        {
            return Ok(modelTasks);
        }

        [HttpPost]
        public ActionResult<List<ModelTask>>
            AddTask(ModelTask novo)
        {
            if (novo.Id == 0 && modelTasks.Count > 0)
                novo.Id = modelTasks[modelTasks.Count - 1].Id + 1;

            modelTasks.Add(novo);
            return Ok(modelTasks);
        }

        [HttpDelete("{id}")]
        public ActionResult<List<ModelTask>>
            DeleteTask(int id)
        {
            var personagem = modelTasks.Find(x => x.Id == id);

            if (personagem is null)
                return NotFound("Task não enconctrada!");

            modelTasks.Remove(personagem);

            return Ok("Task excluída com sucesso");
        }


    }
}
