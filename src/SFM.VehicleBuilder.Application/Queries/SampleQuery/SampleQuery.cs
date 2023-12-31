﻿using MediatR;
using SFM.VehicleBuilder.Domain.Correlation;

namespace SFM.VehicleBuilder.Application.Queries.SampleQuery
{
    public class SampleQuery : QueryBase<int[]>
    {
        public SampleQuery(CorrelationId correlationId)
            : base(correlationId)
        {
        }
    }
}