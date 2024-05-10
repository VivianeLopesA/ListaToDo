using System.Collections.Immutable;
using ListaToDo.Models;
using Microsoft.AspNetCore.Mvc;

namespace ListaToDo.Controllers
{
    public class AtividadeController : Controller
    {
        public static List<Atividade> _atividades = new List<Atividade>
        {
            new Atividade { Id = 1 , atividadeTitulo = "Comprar Frutas" , descricaoAtividade = "Comprar Laranja e Melão" , categoriaAtividade = "To Do" , dataAtividadeCriada = DateOnly.FromDateTime(DateTime.Now) ,  dataLimiteAtividade =  new DateOnly(2024 ,05, 11)},
            new Atividade { Id = 2 , atividadeTitulo = "Dar banho no cachorro" , descricaoAtividade = "Lembrar de cortar as unhas" , categoriaAtividade = "To Do" , dataAtividadeCriada = DateOnly.FromDateTime(DateTime.Now) , dataLimiteAtividade = new DateOnly(2024,05, 13) },
            new Atividade { Id = 3 , atividadeTitulo = "Escrever TCC" , descricaoAtividade = "Corrigir ABNT" , categoriaAtividade = "Done", dataAtividadeCriada = DateOnly.FromDateTime(DateTime.Now) , dataLimiteAtividade = new DateOnly(2024, 05, 10)}
        };

        public static List<Atividade> _atividadeToDo = new List<Atividade>();

        public static List<Atividade> _atividadeDone = new List<Atividade>();




        public IActionResult Index()
        {
            return View(_atividades);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Atividade atividade)
        {
            if (ModelState.IsValid)
            {
                atividade.Id = _atividades.Count > 0 ? _atividades.Max(c => c.Id) + 1 : 1;
                atividade.dataAtividadeCriada = DateOnly.FromDateTime(DateTime.Now);
                _atividades.Add(atividade);
            }

            return RedirectToAction("Index");
        }


        public IActionResult Delete(int id)
        {
            var atividade = _atividades.FirstOrDefault(c => c.Id == id);
            if (atividade == null)
            {
                return NotFound();
            }

            _atividades.Remove(atividade);

            if (_atividadeToDo.Contains(atividade))
            {
                _atividadeToDo.Remove(atividade);

            }else if (_atividadeDone.Contains(atividade))
            {
                _atividadeDone.Remove(atividade);
            }

            return RedirectToAction("Index");

        }


        public IActionResult Detail(int id)
        {
            var atividade = _atividades.FirstOrDefault(c => c.Id == id);
            if (atividade == null)
            {
                return NotFound();
            }
            return View(atividade);
        }

        public IActionResult Edit(int id)
        {
            var atividade = _atividades.FirstOrDefault(c => c.Id == id);
            if (atividade == null)
            {
                return NotFound();
            }

            return View(atividade);
        }


        [HttpPost]
        public IActionResult Edit(Atividade atividade)
        {
            

            if (ModelState.IsValid)
            {
                var atividadeConfirmada = _atividades.FirstOrDefault(c => c.Id == atividade.Id);
                if (atividadeConfirmada != null)
                {
                    atividadeConfirmada.atividadeTitulo = atividade.atividadeTitulo;
                    atividadeConfirmada.descricaoAtividade = atividade.descricaoAtividade;
					atividadeConfirmada.categoriaAtividade = atividade.categoriaAtividade;
                    atividadeConfirmada.dataLimiteAtividade = atividade.dataLimiteAtividade;

                    if (atividade.categoriaAtividade.Contains("Done"))
                    {
                        atividadeConfirmada.dataLimiteAtividade = DateOnly.FromDateTime(DateTime.Now);
                    }
  
                    

                }

                return RedirectToAction("Index");
            }

            return View(atividade);
        }

        public IActionResult exibirToDo()
        {

            if (_atividades != null)
            {

                foreach (var atividade in _atividades)
                {

                    if (atividade.categoriaAtividade.Contains("To Do") && !_atividadeToDo.Contains(atividade))
                    {

                        _atividadeToDo.Add(atividade);

                    }
                }

            }
            return View(_atividadeToDo);
        }

        public IActionResult exibirDone()
        {

            if (_atividades != null)
            {

                foreach (var atividade in _atividades)
                {

                    if (atividade.categoriaAtividade.Contains("Done") && !_atividadeDone.Contains(atividade))
                    {

                        _atividadeDone.Add(atividade);

                    }
                }
                
            

            }
            
            return View(_atividadeDone);

            
        }

       

    }

    
}
