using MediatR;
using System.Text.Json.Serialization;

namespace ProjectTemplate.Application.Features.Queries.UserQueries.GetByIdUser
{
    public record GetByIdProductQueryRequest(int Id) : IRequest<GetByIdProductQueryResponse>;
}
