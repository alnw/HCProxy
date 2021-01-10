using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Test
{
    [ExtendObjectType(Name = "Query")]
    public class BeerQueries
    {
        public async Task<IEnumerable<Beer>> GetPiecesAsync(CancellationToken cancellationToken)
        {
            await Task.Delay(100);
            return Array.Empty<Beer>();
        }
    }
}
