using System.Collections.Generic;
using ApplicationCore.Models.DomainModels;
using ApplicationCore.Models.StorageModels;

namespace ApplicationCore.Interfaces.Repositories
{
    public interface IFaqRepository
    {
        List<FaqStorageModels> GetAllFaq();

        void CreateQuestion(FaqStorageModels faqDomainModel);
    }
}
