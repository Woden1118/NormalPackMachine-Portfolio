using System;
using System.Threading;
using System.Threading.Tasks;
using WpfSimulator.Models;

namespace WpfSimulator.Services
{
    // Educational simulation. This class never opens device connections.
    public sealed class SimulatedInspectionService : IInspectionService
    {
        private readonly Random _random = new Random();
        private int _cycle;

        public async Task<InspectionSnapshot> InspectAsync(CancellationToken cancellationToken)
        {
            await Task.Delay(900, cancellationToken).ConfigureAwait(false);
            cancellationToken.ThrowIfCancellationRequested();
            var offset = Math.Round(_random.NextDouble() * 1.5, 3);
            return new InspectionSnapshot
            {
                Timestamp = DateTime.Now,
                Station = (++_cycle % 2 == 0) ? "模拟工位 B" : "模拟工位 A",
                SimulatedOffsetMm = offset,
                IsOk = offset <= 1.0 // Teaching threshold only. NOT a production tolerance.
            };
        }
    }
}
