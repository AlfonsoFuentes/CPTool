using MediatR;

namespace CPTool.ApplicationCQRSFeatures.Brands.Commands.Delete
{
    public class DeleteBrandCommand : IRequest<DeleteBrandCommandResponse>
    {
        public int Id { get; set; }
    }
}
