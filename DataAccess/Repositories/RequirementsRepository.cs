using AusTest.Domain.Interfaces;
using AusTest.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AusTest.DataAccess.Repositories
{
    public class RequirementsRepository : IRequirementsRepository
    {
        private readonly AusTestDbContext _context;

        public RequirementsRepository(AusTestDbContext context) => _context = context;

        public void Delete(int reqId, int userId)
        {
            var deletedRequirement = _context.Requirements.Where(r => r.Id == reqId && r.UserId == userId).SingleOrDefault();
            if (null != deletedRequirement)
            {
                _context.Requirements.Remove(deletedRequirement);
                _context.SaveChanges();
            }
        }

        public Requirement GetById(int reqId, int userId)
        {
            return _context.Requirements.Where(r => r.Id == reqId && r.UserId == userId).SingleOrDefault();
        }

        public Requirement Insert(Requirement data)
        {
            _context.Requirements.Add(data);
            _context.SaveChanges();
            return data;
        }

        public IList<Requirement> ListAll()
        {
            return _context.Requirements.OrderBy(r => r.Name).ToList();
        }

        public IList<Requirement> ListByUser(int userId)
        {
            return _context.Requirements.Where(r => r.UserId == userId).OrderBy(r => r.Name).ToList();
        }

        public Requirement Update(Requirement data)
        {
            var origRequirement = _context.Requirements.Where(r => r.Id == data.Id && r.UserId == data.UserId).SingleOrDefault();
            if (null != origRequirement)
            {
                _context.Entry<Requirement>(origRequirement).CurrentValues.SetValues(data);
                _context.SaveChanges();
            }
            return origRequirement;
        }
    }
}
