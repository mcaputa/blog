using System;
using System.Collections.Generic;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;
using System.Threading.Tasks;
using maciejcaputablog.Repositories;
using maciejcaputablog.StorageModels;
using maciejcaputablog.ViewModels;

namespace maciejcaputablog.Services
{
    public class FaqService : IFaqService
    {
        private readonly IFaqRepository _faqRepository;

        public FaqService(IFaqRepository faqRepository)
        {
            _faqRepository = faqRepository;
        }

        public FaqViewModel GetAllFaqs()
        {
            var faqsDomainModels = _faqRepository.GetAllFaq();

            var faqViewModel = new FaqViewModel()
            {
                AllFaqDomainModels = faqsDomainModels
            };

            return faqViewModel;
        }

        public void AddFaq(FaqDomainModel faqDomainModel)
        {
            _faqRepository.CreateQuestion(faqDomainModel);
        }
    }
}
