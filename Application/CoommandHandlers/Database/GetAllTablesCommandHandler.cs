namespace Application.CoommandHandlers
{
    public class GetAllTablesCommandHandler : IRequestHandler<GetAllTablesCommand, List<string>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllTablesCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<string>> Handle(GetAllTablesCommand request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(_context.GetTableNames());
        }
    }
}
