using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using maciejcaputablog.StorageModels;
using maciejcaputablog.ViewModels;

namespace maciejcaputablog.Services
{
    public interface IFaqService
    {
        FaqViewModel GetAllFaqs();
        void AddFaq(FaqDomainModel faqDomainModel);
    }
}
