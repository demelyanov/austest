using AusTest.Domain.Interfaces;
using AusTest.Domain.Model;
using AusTest.Service.DTOs;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace AusTest.Service.RequirementsService
{
    public class RequirementsService : IRequirementsService
    {
        private readonly IRequirementsRepository _requirementsRepository;
        private readonly IMapper _mapper;

        public RequirementsService(IRequirementsRepository requirementsRepository, IMapper mapper)
        {
            _requirementsRepository = requirementsRepository;
            _mapper = mapper;
        }

        public void Delete(int reqId, int userId)
        {
            _requirementsRepository.Delete(reqId, userId);
        }

        public RequirementDto GetById(int reqId, int userId)
        {
            return _mapper.Map<RequirementDto>(_requirementsRepository.GetById(reqId, userId));
        }

        public IList<RequirementDto> ListByUser(int userId)
        {
            var list = _requirementsRepository.ListByUser(userId);
            return _mapper.Map<IList<RequirementDto>>(list);
        }

        public RequirementDto Save(RequirementDto data, int userId)
        {
            var requirementDb = _mapper.Map<Requirement>(data);
            requirementDb.UserId = userId;

            if (0 == data.Id)
                requirementDb = _requirementsRepository.Insert(requirementDb);
            else
                requirementDb = _requirementsRepository.Update(requirementDb);
            return _mapper.Map<RequirementDto>(requirementDb);
        }
    }
}
