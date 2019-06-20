using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Quiz.Client.Models;

namespace Quiz.Client.Controllers
{
    public class QuizQuestionsController : Controller
    {
        private readonly QuizClientContext _context;

        public QuizQuestionsController(QuizClientContext context)
        {
            _context = context;
        }

        // GET: QuizQuestions
        public async Task<IActionResult> Index()
        {
            return View(await _context.QuizQuestions.ToListAsync());
        }

        // GET: QuizQuestions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quizQuestions = await _context.QuizQuestions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (quizQuestions == null)
            {
                return NotFound();
            }

            return View(quizQuestions);
        }

        // GET: QuizQuestions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: QuizQuestions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Question,CorrectAnswer,AnswerOne,AnswerTwo,AnswerThree")] QuizQuestions quizQuestions)
        {
            if (ModelState.IsValid)
            {
                _context.Add(quizQuestions);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(quizQuestions);
        }

        // GET: QuizQuestions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quizQuestions = await _context.QuizQuestions.FindAsync(id);
            if (quizQuestions == null)
            {
                return NotFound();
            }
            return View(quizQuestions);
        }

        // POST: QuizQuestions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Question,CorrectAnswer,AnswerOne,AnswerTwo,AnswerThree")] QuizQuestions quizQuestions)
        {
            if (id != quizQuestions.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(quizQuestions);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QuizQuestionsExists(quizQuestions.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(quizQuestions);
        }

        // GET: QuizQuestions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quizQuestions = await _context.QuizQuestions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (quizQuestions == null)
            {
                return NotFound();
            }

            return View(quizQuestions);
        }

        // POST: QuizQuestions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var quizQuestions = await _context.QuizQuestions.FindAsync(id);
            _context.QuizQuestions.Remove(quizQuestions);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QuizQuestionsExists(int id)
        {
            return _context.QuizQuestions.Any(e => e.Id == id);
        }
    }
}
