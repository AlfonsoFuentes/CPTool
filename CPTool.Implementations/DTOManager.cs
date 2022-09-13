using CPTool.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections;
using System.Runtime.CompilerServices;
using System.Threading;

namespace CPTool.Implementations
{
    public class DTOManager<TDTO, T> : IDTOManager<TDTO, T>, IDisposable
        where TDTO : class, IAuditableEntityDTO,  new() 
          where T : IAuditableEntity
    {

        readonly IUnitOfWork _unitofwork;
        readonly IMapper _mapper;
       
        public List<TDTO> List { get; set; } = new();
        public DTOManager(IUnitOfWork unitofwork, IMapper mapper)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;
        }


        public async Task<IResult<TDTO>> AddUpdate(IAuditableEntityDTO dto, CancellationToken cancellationToken)
        {
            dto=await OnPriorSave(dto);
            
            var table = _mapper.Map<T>(dto);

            var request = dto.Id == 0 ? await _unitofwork.Repository<T>().AddAsync(table) : _unitofwork.Repository<T>().UpdateAsync(table);
            var result = await _unitofwork.CommitAndRemoveCache(cancellationToken, null);
            if (!result.Succeeded)
                return await Result<TDTO>.FailAsync("Not created!");
            var mppeddto = _mapper.Map<TDTO>(request) as IAuditableEntityDTO;
           var  responsdto = await OnPostSave(mppeddto) as TDTO;
           
        
         
            return await Result<TDTO>.SuccessAsync(responsdto!, "Updated");


        }
        async Task<IAuditableEntityDTO> OnPriorSave(IAuditableEntityDTO dto)
        {
            if (PriorSave != null)
            {
                var resultchild = await PriorSave.Invoke(dto);
                if (resultchild.Succeeded)
                {
                    return resultchild.Data;
                }
            }
            return dto;
        }
        async Task<IAuditableEntityDTO> OnPostSave(IAuditableEntityDTO dto)
        {
            if (PostSave != null)
            {
                var resultchild = await PostSave.Invoke(dto);
                if (resultchild.Succeeded)
                {
                    return resultchild.Data;
                }
            }
            return dto;
        }

        public async Task<IResult<int>> Delete(int id, CancellationToken cancellationToken)
        {

            var table = await _unitofwork.Repository<T>().GetByIdAsync(id);

            if (table != null)
            {
                string retorno = $"{table.Name!} removed succesfully";
                await _unitofwork.Repository<T>().DeleteAsync(table);
                var result = await _unitofwork.CommitAndRemoveCache(cancellationToken, null);
                if (!result.Succeeded)
                {
                    return await Result<int>.FailAsync("Not Delete!");
                }
             
                return await Result<int>.SuccessAsync(result.Data, retorno);
            }
            return await Result<int>.FailAsync("Not Found!");

        }
        public async Task<IResult<int>> Delete(TDTO dto, CancellationToken cancellationToken)
        {
            var table = await _unitofwork.Repository<T>().GetByIdAsync(dto.Id);

            if (table != null)
            {
                string retorno = $"{table.Name!} removed succesfully";
                await _unitofwork.Repository<T>().DeleteAsync(table);
                var result = await _unitofwork.CommitAndRemoveCache(cancellationToken, null);
                if (!result.Succeeded)
                {
                    return await Result<int>.FailAsync("Not Delete!");
                }
                await UpdateList();
                return await Result<int>.SuccessAsync(result.Data, retorno);
            }
            return await Result<int>.FailAsync("Not Found!");
        }
        public async Task<IResult<TDTO>> GetById(int id)
        {
            var table = await _unitofwork.Repository<T>().GetByIdAsync(id);

            var dto = _mapper.Map<TDTO>(table);

            return dto == null ? await Result<TDTO>.FailAsync("Not found!") : await Result<TDTO>.SuccessAsync(dto, "row returned");


        }

        public async Task UpdateList()
        {
            var list = await _unitofwork.Repository<T>().GetAllAsync();
            List = _mapper.Map<List<TDTO>>(list);
           

            if (PostUpdateListEvent != null) await PostUpdateListEvent.Invoke();


           
        }

        public void Dispose()
        {


        }

       public Func<Task> PostUpdateListEvent { get; set; }
 
        public Func<IAuditableEntityDTO, Task<IResult<IAuditableEntityDTO>>> PriorSave { get; set; } = null!;
        public Func<IAuditableEntityDTO, Task<IResult<IAuditableEntityDTO>>> PostSave { get; set; } = null!;
      
    }
}