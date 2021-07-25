using SocialService.Management.DTOs.PopularUserDto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SocialService.Management.Services.Interfaces
{
    public interface IPopularityService
    {
        Task<IReadOnlyCollection<PopularUserDto>> GetTopAsync(int count = 20);
    }
}
