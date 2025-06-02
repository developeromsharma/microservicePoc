using AuthService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthService.Domain.Interfaces
{
    public interface IAuthCheckService
    {
        Task<EligibilityResult> IsEligibleAsync(int userId, int assetId);
    }
}
