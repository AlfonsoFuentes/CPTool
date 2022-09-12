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
            var table = _mapper.Map<T>(dto);

            var request = dto.Id == 0 ? await _unitofwork.Repository<T>().AddAsync(table) : _unitofwork.Repository<T>().UpdateAsync(table);
            var result = await _unitofwork.CommitAndRemoveCache(cancellationToken, null);
            if (!result.Succeeded)
                return await Result<TDTO>.FailAsync("Not created!");

            var responsdto = _mapper.Map<TDTO>(request);
            await UpdateList();
         
            return await Result<TDTO>.SuccessAsync(responsdto, "Updated");


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
                await UpdateList();
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

        public async Task<List<TDTO>> UpdateList()
        {
            var list = await _unitofwork.Repository<T>().GetAllAsync();
            List = _mapper.Map<List<TDTO>>(list);
           

            if (PostEvent != null) PostEvent.Invoke();


            return List;
        }

        public void Dispose()
        {


        }
        //public async Task Test1(CancellationToken cancellationToken)
        //{
        //    var mwotypelist = await _unitofwork.Repository<MWOType>().GetAllAsync();
        //    var mwotype = mwotypelist.FirstOrDefault(x => x.Id == 2);
        //    var mwotypedto = _mapper.Map<MWOTypeDTO>(mwotype);

        //    var mwolist = await _unitofwork.Repository<MWO>().GetAllAsync(); ;
        //    var mwo = mwolist.FirstOrDefault(x => x.Id == 3);
        //    var mwodto = _mapper.Map<MWODTO>(mwo);
        //    mwodto.MWOTypeDTO = mwotypedto;
        //    mwodto.Name = "MWO test update";
        //    mwodto.Number = 12345;

        //    mwo = _mapper.Map<MWO>(mwodto);


        //    var request = mwo.Id == 0 ? await _unitofwork.Repository<MWO>().AddAsync(mwo) : _unitofwork.Repository<MWO>().UpdateAsync(mwo);

        //    var result = await _unitofwork.CommitAndRemoveCache(cancellationToken, null);
        //    if (result.Succeeded)
        //    {

        //    }
        //}
        //public async Task Test2(CancellationToken cancellationToken)
        //{
        //    var mwotypelist = await _unitofwork.Repository<MWOType>().GetAllAsync();
        //    var mwotype = mwotypelist.FirstOrDefault(x => x.Id == 2);
        //    var mwotypedto = _mapper.Map<MWOTypeDTO>(mwotype);


        //    var mwodto = new CreateMWODTO();
        //    mwodto.MWOTypeDTO = mwotypedto;
        //    mwodto.Name = "MWO test update";
        //    mwodto.Number = 12345;

        //    var mwo = _mapper.Map<MWO>(mwodto);

        //    //await _unitofwork.Repository<MWO>().AddAsync(mwo);
        //    var request = mwo.Id == 0 ? await _unitofwork.Repository<MWO>().AddAsync(mwo) : _unitofwork.Repository<MWO>().UpdateAsync(mwo);

        //    var result = await _unitofwork.CommitAndRemoveCache(cancellationToken, null);
        //    if (result.Succeeded)
        //    {

        //    }
        //}
        public Action PostEvent { get; set; } = null!;
    }
}