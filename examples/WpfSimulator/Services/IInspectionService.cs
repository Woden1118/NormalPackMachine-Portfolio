using System.Threading;
using System.Threading.Tasks;
using WpfSimulator.Models;

namespace WpfSimulator.Services
{
    public interface IInspectionService
    {
        Task<InspectionSnapshot> InspectAsync(CancellationToken cancellationToken);
    }
}
