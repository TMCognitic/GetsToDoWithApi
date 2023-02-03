using GetsToDoWithApi.Models.Entities;

namespace GetsToDoWithApi.Models.Repositories
{
    public interface IToDoRepository
    {
        IEnumerable<ToDo>? Get();
    }
}
