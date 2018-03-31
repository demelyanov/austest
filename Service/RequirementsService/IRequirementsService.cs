using AusTest.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace AusTest.Service.RequirementsService
{
    public interface IRequirementsService
    {
        IList<RequirementDto> ListByUser(int userId);
        RequirementDto Save(RequirementDto data, int userId);
        RequirementDto GetById(int reqId, int userId);
        void Delete(int reqId, int userId);
    }
}
