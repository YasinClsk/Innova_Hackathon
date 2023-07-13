using MediatR;
using ProjectTemplate.Application.Abstractions.Repositories;
using ProjectTemplate.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTemplate.Application.Features.Queries.UserChargeQueries.GetUserCharge
{
    public class GetUserChargeQueryHandler
        : IRequestHandler<GetUsersChargeQueryRequest, GetUsersChargeQueryResponse>
    {
        private readonly IUserChargeRepository _userChargeRepository;

        public GetUserChargeQueryHandler(IUserChargeRepository userChargeRepository)
        {
            _userChargeRepository = userChargeRepository;
        }

        public async Task<GetUsersChargeQueryResponse> Handle(GetUsersChargeQueryRequest request, CancellationToken cancellationToken)
        {
            var userCharge = await _userChargeRepository.GetAsync(request.UserId,request.DateTime ,request.ChargeInterval);

            if (userCharge is null)
                throw new Exception("Kayıt bulunamadı");

            return new GetUsersChargeQueryResponse
                                (userCharge.StartDate,
                                 userCharge.EndDate,
                                 userCharge.UserId,
                                 userCharge.Cost,
                                 userCharge.ChargeInterval);
        }
    }

    public record GetUsersChargeQueryRequest(int UserId,
                                             DateTime DateTime,
                                             ChargeInterval ChargeInterval)

        : IRequest<GetUsersChargeQueryResponse>;
    public record GetUsersChargeQueryResponse(DateTime StartDate,
                                              DateTime EndDate,
                                              int UserId,
                                              decimal Cost,
                                              ChargeInterval ChargeInterval);
}
