using System.Collections.Generic;

using Core.Models.StorageModels;

namespace Core.Interfaces.Repositories
{
    public interface IFaqRepository
    {
        List<FaqStorageModels> GetAllFaq();

        void CreateQuestion(FaqStorageModels faqDomainModel);
    }
}
