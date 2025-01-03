using Charcillaries.Data.DatabaseSpecific;
using Charcillaries.Data.Linq;

namespace Charcillaries.Core.Features;

public abstract class BaseRepository
{
    protected readonly DataAccessAdapter _adapter;
    protected readonly LinqMetaData _meta;

    protected BaseRepository(DataAccessAdapter adapter)
    {
        _adapter = adapter;
        _meta = new LinqMetaData(_adapter);
    }
}