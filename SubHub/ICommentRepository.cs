using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SubHub.Models;

namespace SubHub
{
    public interface ICommentRepository
    {
        IQueryable<Comment> GetComment();
    }
}
