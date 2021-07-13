using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Controllers
{
    public interface IGenericController<TEntity, TId>
    {
        Task<IActionResult> Get(long id);

        Task<IActionResult> GetAll();

        Task<IActionResult> Create(TEntity entidadeDto);

        Task<IActionResult> Create(IEnumerable<TEntity> entidadeDto);

        Task<IActionResult> Delete(TId id);

        Task<IActionResult> Delete(IEnumerable<TEntity> entidadeDto);

        Task<IActionResult> Delete(TEntity entidadeDto);

        Task<IActionResult> Update(IEnumerable<TEntity> entidadeDto);

        Task<IActionResult> Update(TEntity entidadeDto);
    }
}