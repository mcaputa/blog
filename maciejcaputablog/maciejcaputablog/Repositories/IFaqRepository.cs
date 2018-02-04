using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using maciejcaputablog.StorageModels;

namespace maciejcaputablog.Repositories
{
    public interface IFaqRepository
    {
        List<FaqDomainModel> GetAllFaq();
        void CreateQuestion(FaqDomainModel faqDomainModel);
    }
}
