using AusTest.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace AusTest.Domain.Interfaces
{
    public interface IRequirementsRepository
    {
        IList<Requirement> ListAll();
        IList<Requirement> ListByUser(int userId);
        Requirement Insert(Requirement data);
        Requirement Update(Requirement data);
        void Delete(int reqId, int userId);
        Requirement GetById(int reqId, int userId);
    }
}
