

using CPTool.Application.Features.Base.Delete;

namespace CPTool.Application.Features.Base
{
    public class Manager
    {
       
        public GetByIdQuery GetByIdQuery { get; set; } = null!;
        public GetListQuery GetListQuery { get; set; } = null!;
        public DeleteCommand DeleteCommand { get; set; } = null!;
    }
    public class ManagerCommand< TGetList, TGetById, TDelete>: Manager
        
         where TGetById : GetByIdQuery, new()
         where TGetList : GetListQuery, new()
         where TDelete : DeleteCommand, new()

    {
        public ManagerCommand()
        {
          
            GetByIdQuery = new TGetById();
            GetListQuery = new TGetList();
            DeleteCommand = new TDelete();
        }
    }

}
