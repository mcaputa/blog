using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using maciejcaputablog.InputModels;
using maciejcaputablog.Services;
using maciejcaputablog.StorageModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace maciejcaputablog.Controllers
{
    [Authorize]
    public class TemporaryFaqController : Controller
    {
        private readonly IFaqService _faqService;
        private readonly IMapper _mapper;

        public TemporaryFaqController(IFaqService faqService, IMapper mapper)
        {
            _faqService = faqService;
            _mapper = mapper;
        }
        // GET: TemporaryFAQ
        [AllowAnonymous]
        public ActionResult Read()
        {
            var faq = _faqService.GetAllFaqs();
            return View(faq);
        }

        // GET: TemporaryFAQ/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TemporaryFAQ/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FaqInputModel model)
        {
            try
            {
                var faqDomainModel = _mapper.Map<FaqInputModel, FaqDomainModel>(model);
                _faqService.AddFaq(faqDomainModel);

                return RedirectToAction(nameof(Read));
            }
            catch
            {
                return View();
            }
        }

        // GET: TemporaryFAQ/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TemporaryFAQ/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Read));
            }
            catch
            {
                return View();
            }
        }

        // POST: TemporaryFAQ/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Read));
            }
            catch
            {
                return View();
            }
        }
    }
}