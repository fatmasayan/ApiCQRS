﻿using MediatR;

namespace Api.Application.Features.Products.Queries.GetAllProducts
{
    public class GetAllProductsQueryRequest :IRequest<List<GetAllProductsQueryResponse>>
    {
    }
}
