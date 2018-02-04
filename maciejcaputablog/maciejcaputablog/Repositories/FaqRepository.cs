using maciejcaputablog.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using maciejcaputablog.Models;
using maciejcaputablog.StorageModels;

namespace maciejcaputablog.Repositories
{
    public class FaqRepository : IFaqRepository
    {
        private readonly IApplicationDbContext _context;

        public FaqRepository(IApplicationDbContext context)
        {
            _context = context;
        }


        public List<FaqDomainModel> GetAllFaq()
        {
            var faqsStorageModels = _context.Faqs.Select(faq => new FaqDomainModel()
            {
                Description = faq.Description,
                Title = faq.Title
            }).ToList();

            return faqsStorageModels;
        }

        public void CreateQuestion(FaqDomainModel faqDomainModel)
        {
            var question = new Faq()
            {
                Description = faqDomainModel.Description,
                Title = faqDomainModel.Title,
                CreatedOn = DateTime.Today,
                ModifiedOn = DateTime.Today
            };
            _context.Faqs.Add(question);
            _context.SaveChanges();
        }
    }
}
