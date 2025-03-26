using BuildingBlocks.CQRS;
using Catalog.API.Exceptions;
using Catalog.API.Models;
using Catalog.API.Products.GetProductById;
using Marten;
using MediatR;

namespace Catalog.API.Products.GetProductByCatergory
{

    public record GetProductByCategoryQuery(string Category):IQuery<GetProductByCategoryResult>;

    public record GetProductByCategoryResult(IEnumerable<Product> Products);

    internal class GetProductByCategoryHandler(IDocumentSession documentSession, ILogger<GetProductByCategoryHandler> logger) : IQueryHandler<GetProductByCategoryQuery, GetProductByCategoryResult>
    {
        public async Task<GetProductByCategoryResult> Handle(GetProductByCategoryQuery query, CancellationToken cancellationToken)
        {
            logger.LogInformation($"Querying product by category: {query.Category}");
            var result = await documentSession.Query<Product>().Where(x=> x.Category.Equals(query.Category)).ToListAsync();

            if (result is null)
                throw new ProductNotFoundException();

            return new GetProductByCategoryResult(result);
        }
    }
}
