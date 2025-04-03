using AutoMapper;
using MediatR;
using MorelyTrends.Application.DTOs;
using MorelyTrends.Domain.Entities;
using MorelyTrends.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorelyTrends.Application.Commands
{
    public record AddSellerCommand(CreateEditSellerDto Seller) : IRequest<Seller>
    {
    }

    public class AddSellerHandler(ISellerRepository sellerRepository, IMapper mapper) : IRequestHandler<AddSellerCommand, Seller>
    {
        public async Task<Seller> Handle(AddSellerCommand request, CancellationToken cancellationToken)
        {
            var res = mapper.Map<Seller>(request.Seller);

            return await sellerRepository.AddSeller(res, request.Seller.Password, request.Seller.Role);
        }
    }
}
